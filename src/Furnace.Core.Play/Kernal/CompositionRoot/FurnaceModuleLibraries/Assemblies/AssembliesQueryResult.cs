using System.Collections.Generic;
using Furnace.Core.Play.Kernal.Query;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.Assemblies
{
    public class AssembliesQueryResult:QueryResult
    {
        public AssembliesQueryResult(IEnumerable<CompilationLibrary> compileLibraries)
        {
            CompileLibraries = compileLibraries;
        }

        public IEnumerable<CompilationLibrary> CompileLibraries { get; }
    }
}
