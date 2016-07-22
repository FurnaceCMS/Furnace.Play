using System;
using System.Linq;
using Furnace.Core.Play.Kernal.Query;
using Microsoft.Extensions.DependencyModel;

namespace Furnace.Core.Play.Kernal.CompositionRoot.FurnaceModuleLibraries.CompileLibraries
{
    public class CompileLibrariesQueryHandler:IQueryHandler<CompileLibrariesQuery, CompileLibrariesQueryResult>
    {
        public CompileLibrariesQueryResult Handle(CompileLibrariesQuery query)
        {
            var compilationLibraries = DependencyContext.Default.CompileLibraries.Where(query.WherePredicate);

            return new CompileLibrariesQueryResult(compilationLibraries);
        }

        public CompileLibrariesQueryResult Handle(Func<CompilationLibrary, bool> wherePredicate)
        {
            var query = new CompileLibrariesQuery(wherePredicate);
            return Handle(query);
        }
    }
}
