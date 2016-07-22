using System;
using System.Linq;
using Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.CompileLibraries;
using Furnace.Core.Play.Kernal.Query;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.Assemblies
{
    public class AssembliesQueryHandler:IQueryHandler<CompileLibrariesQuery, AssembliesQueryResult>
    {
        public AssembliesQueryResult Handle(CompileLibrariesQuery query)
        {
            var compilationLibraries = DependencyContext.Default.CompileLibraries.Where(query.WherePredicate);

            return new AssembliesQueryResult(compilationLibraries);
        }

        public AssembliesQueryResult Handle(Func<CompilationLibrary, bool> wherePredicate)
        {
            var query = new CompileLibrariesQuery(wherePredicate);
            return Handle(query);
        }
    }
}
