using System.Collections.Generic;
using Furnace.Core.Play.Kernal.Query;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.CompileLibraries
{
    public class CompileLibrariesQueryResult:QueryResult
    {
        public CompileLibrariesQueryResult(IEnumerable<CompilationLibrary> compileLibraries)
        {
            CompileLibraries = compileLibraries;
        }

        public IEnumerable<CompilationLibrary> CompileLibraries { get; }
    }
}
