using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.CompileLibraries;
using Furnace.Core.Play.Kernal.Middleware;
using Furnace.Core.Play.Kernal.Module;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Play.Kernal.CompositionRoot
{
    public class CompositionRootBuilder
    {
        public static Container Build()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            var compileLibrariesQueryHandler = new CompileLibrariesQueryHandler();

            var moduleLibraries = compileLibrariesQueryHandler.Handle(library => library.Dependencies.Any(x => x.Name == "Furnace.Core.Play"));

            var moduleAssemblies = moduleLibraries.CompileLibraries
                .Select(x => Assembly.Load(new AssemblyName(x.Name)))
                .ToList();

            var modules = GetFurnaceModules(moduleAssemblies);
            foreach (var module in modules)
            {
                var instance = (IFurnaceModule)Activator.CreateInstance(module);
                instance.ConfigureContainer(container);
            }

            var middleware = GetFurnaceMiddleware(moduleAssemblies);
            container.RegisterCollection<IFurnaceMiddleware>(middleware);

            return container;
        }

        private static IEnumerable<Type> GetFurnaceModules(IEnumerable<Assembly> assemblies)
        {
            return from t in assemblies
                from d in t.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceModule))
                select d.UnderlyingSystemType;
        }

        private static IEnumerable<Type> GetFurnaceMiddleware(IEnumerable<Assembly> assemblies)
        {
            return from t in assemblies
                from d in t.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceMiddleware))
                      && d.BaseType != typeof(FurnaceMiddlewareDecorator)
                select d.UnderlyingSystemType;
        }
    }
}
