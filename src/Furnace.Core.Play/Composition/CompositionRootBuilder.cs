using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Furnace.Core.Play.Middleware;
using Furnace.Core.Play.Module;
using Microsoft.Extensions.DependencyModel;
using Nancy;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Play.Composition
{
    public class CompositionRootBuilder : IFurnaceCompositionRootBuilder
    {
        public Container Container { get; }

        public CompositionRootBuilder()
        {
            Container = new Container();
            Container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();
        }

        public ICompositionRoot Build()
        {   
            var moduleAssemblies = GetModuleAssemblies().ToList();

            ConfigureContainers(moduleAssemblies, Container);
            RegisterMiddleware(moduleAssemblies, Container);
            
            return new CompositionRoot(Container.GetAllInstances<IFurnaceMiddleware>().OrderBy(mw => mw.Weight));
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
                var instance = (FurnaceModule) Activator.CreateInstance(module);
                instance.ConfigureContainer(container);

                container.Register(module, () => instance);
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
