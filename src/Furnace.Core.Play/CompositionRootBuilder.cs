using System;
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

            var moduleAssemblies = GetModuleAssemblies();

            ConfigureContainers(moduleAssemblies, container);
            RegisterMiddleware(moduleAssemblies, container);

            return container;
        }

        private static List<Assembly> GetModuleAssemblies()
        {
            return DependencyContext.Default.CompileLibraries
                .Where(library => library.Dependencies.Any(x => x.Name == "Furnace.Core.Play"))
                .Select(x => Assembly.Load(new AssemblyName(x.Name)))
                .ToList();
        }

        private static void ConfigureContainers(IEnumerable<Assembly> moduleAssemblies, Container container)
        {
            var modules = GetFurnaceModules(moduleAssemblies);
            foreach (var module in modules)
            {
                var instance = (IFurnaceModule) Activator.CreateInstance(module);
                instance.ConfigureContainer(container);
            }
        }

        private static void RegisterMiddleware(IEnumerable<Assembly> moduleAssemblies, Container container)
        {
            var middleware = GetFurnaceMiddleware(moduleAssemblies);
            container.RegisterCollection<IFurnaceMiddleware>(middleware);
        }

        private static IEnumerable<Type> GetFurnaceMiddleware(IEnumerable<Assembly> assemblies)
        {
            //Don't get decreates as these should be regestered byt the module
            return GetFurnaceModules(assemblies).Where(t => t.DeclaringType != typeof(FurnaceMiddlewareDecorator));
        }

        private static IEnumerable<Type> GetFurnaceModules(IEnumerable<Assembly> assemblies)
        {
            return from a in assemblies
                from d in a.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceModule))
                select d.UnderlyingSystemType;
        }
    }
}
