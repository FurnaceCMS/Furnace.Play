using Furnace.Core.Play.Kernal.Query;
using Microsoft.Extensions.DependencyModel;
using System.Linq;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries
{
    public class FurnaceModuleLibrariesQueryHandler:IQueryHandler<FurnaceModuleLibrariesQuery, FurnaceModuleLibrariesQueryResult>
    {
        public FurnaceModuleLibrariesQueryResult Handle(FurnaceModuleLibrariesQuery query)
        {
            var libraries = from library in DependencyContext.Default.CompileLibraries
                            where library.Dependencies.Any(x => x.Name == "Furnace.Core.Play")
                            select library;

            return new FurnaceModuleLibrariesQueryResult(libraries);
        }
    }
}
