using System.Collections.Generic;
using Furnace.Core.Play.Kernal.Query;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries
{
    public class FurnaceModuleLibrariesQueryResult:QueryResult
    {
        public FurnaceModuleLibrariesQueryResult(IEnumerable<CompilationLibrary> moduleLibraries)
        {
            ModuleLibraries = moduleLibraries;
        }

        public IEnumerable<CompilationLibrary> ModuleLibraries { get; }
    }
}
