﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using SimpleInjector;
using System.Linq;
using System.Reflection;
using Furnace.Core.Play;
using Furnace.Core.Play.GraphTheory.Algorithms;
using Furnace.Core.Play.GraphTheory.Graphs;
using SimpleInjector.Extensions.ExecutionContextScoping;

namespace Furnace.Core.Owin.Play
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            var moduleLibraries = GetFurnaceModuleLibraries();

            var sortedModuleLibraries = SortLibraries(moduleLibraries);

            var moduleAssemblies = GetAssemblies(sortedModuleLibraries);

            var modules = GetFurnaceModules(moduleAssemblies);
            foreach (var module in modules)
            {
                var instance = (IFurnaceModule)Activator.CreateInstance(module);
                instance.ConfigureContainer(container);
            }

            var middleware = GetFurnaceMiddleware(moduleAssemblies);
            container.RegisterCollection<IFurnaceMiddleware>(middleware);

            app.UseFurnace(container);
        }

        private static IEnumerable<CompilationLibrary> SortLibraries(IEnumerable<CompilationLibrary> moduleLibraries)
        {
            var graph = new DirectedAcyclicGraph<string>();

            var compilationLibraries = moduleLibraries as CompilationLibrary[] ?? moduleLibraries.ToArray();
            foreach (var library in compilationLibraries)
            {
                if (!graph.Vertices.Contains(library.Name))
                {
                    graph.InsertVertex(library.Name);
                }

                foreach (var dependency in library.Dependencies)
                {
                    if (!graph.Vertices.Contains(dependency.Name))
                    {
                        graph.InsertVertex(dependency.Name);
                    }
                    graph.InsertEdge(dependency.Name, library.Name);
                }
            }
            var sort = new TopologicalSortAlgorithm<string>(graph);

            var sortedModuleLibraries = new List<CompilationLibrary>();
            foreach (var sortedVertex in sort.SortedVertices)
            {
                var library = compilationLibraries.SingleOrDefault(x => x.Name == sortedVertex);

                if (library != null)
                {
                    sortedModuleLibraries.Add(library);
                }
            }
            return sortedModuleLibraries;
        }

        private static IList<Assembly> GetAssemblies(IEnumerable<CompilationLibrary> moduleLibraries)
        {
            var moduleAssemblies = from library in moduleLibraries
                select Assembly.Load(new AssemblyName(library.Name));

            return moduleAssemblies as IList<Assembly> ?? moduleAssemblies.ToList();
        }

        private static IEnumerable<CompilationLibrary> GetFurnaceModuleLibraries()
        {
            var libraries = from library in DependencyContext.Default.CompileLibraries
                where library.Dependencies.Any(x => x.Name == "Furnace.Core.Play")
                select library;

            return libraries;
        }

        private static IEnumerable<Type> GetFurnaceModules(IList<Assembly> assemblies)
        {
            var furnaceModules = from t in assemblies
                from d in t.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceModule))
                select d.UnderlyingSystemType;

            return furnaceModules as IList<Type> ?? furnaceModules.ToList();
        }

        private static IEnumerable<Type> GetFurnaceMiddleware(IList<Assembly> assemblies)
        {
            var furnaceMiddleware =  from t in assemblies
                from d in t.DefinedTypes
                where d.ImplementedInterfaces.Contains(typeof(IFurnaceMiddleware))
                select d.UnderlyingSystemType;

            return furnaceMiddleware as IList<Type> ?? furnaceMiddleware.ToList();
        }
    }
}
