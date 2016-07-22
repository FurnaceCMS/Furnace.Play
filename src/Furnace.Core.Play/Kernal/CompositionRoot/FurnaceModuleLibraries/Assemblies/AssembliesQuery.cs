using System;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.Assemblies
{
    public class AssembliesQuery:Query.Query
    {
        public AssembliesQuery(Func<CompilationLibrary, bool> wherePredicate)
        {
            WherePredicate = wherePredicate;
        }

        public Func<CompilationLibrary, bool> WherePredicate { get; }
    }
}
