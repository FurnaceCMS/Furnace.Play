﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Furnace.Core.Play.Kernal.Middleware;
using Furnace.Core.Play.Kernal.Module;
using Microsoft.Extensions.DependencyModel;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Play
{
    public class CompositionRootBuilder
    {
        public static Container Build()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            var moduleAssemblies = GetModuleAssemblies().ToList();

            ConfigureContainers(moduleAssemblies, container);
            RegisterMiddleware(moduleAssemblies, container);

            return container;
        }

        private static IEnumerable<Assembly> GetModuleAssemblies()
        {
            return from library in DependencyContext.Default.CompileLibraries
                where library.Dependencies.Any(x => x.Name == "Furnace.Core.Play")
                select Assembly.Load(new AssemblyName(library.Name));
        }

        private static void ConfigureContainers(IEnumerable<Assembly> moduleAssemblies, Container container)
        {
            var modules = from ti in GetFurnaceModules(moduleAssemblies)
                select ti.UnderlyingSystemType;

            foreach (var module in modules)
            {
                var instance = (IFurnaceModule) Activator.CreateInstance(module);
                instance.ConfigureContainer(container);
            }
        }

        private static void RegisterMiddleware(IEnumerable<Assembly> moduleAssemblies, Container container)
        {
            var middleware = from ti in GetFurnaceMiddleware(moduleAssemblies)
                select ti.UnderlyingSystemType;

            container.RegisterCollection<IFurnaceMiddleware>(middleware);
        }

        private static IEnumerable<TypeInfo> GetFurnaceMiddleware(IEnumerable<Assembly> assemblies)
        {
            //Don't get Decorators as these should be regestered byt the module
            return from a in assemblies
                from d in a.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceMiddleware))
                      && !d.ImplementedInterfaces.Contains(typeof(IFurnaceMiddlewareDecorator))
                select d;
        }

        private static IEnumerable<TypeInfo> GetFurnaceModules(IEnumerable<Assembly> assemblies)
        {
            return from a in assemblies
                from d in a.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceModule))
                select d;
        }
    }
}
