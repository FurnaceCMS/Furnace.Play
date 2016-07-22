using System;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.CompileLibraries
{
    public class CompileLibrariesQuery:Query.Query
    {
        public CompileLibrariesQuery(Func<CompilationLibrary, bool> wherePredicate)
        {
            WherePredicate = wherePredicate;
        }

        public Func<CompilationLibrary, bool> WherePredicate { get; }
    }
}
