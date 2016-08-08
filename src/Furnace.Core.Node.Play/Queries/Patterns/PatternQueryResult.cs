using Furnace.Core.Data.Play.Patterns;
using Furnace.Core.Data.Play.Patterns.Core;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Queries.Patterns
{
    public class PatternQueryResult : QueryResult
    {
        public readonly IPagePattern Pattern;

        public PatternQueryResult(IPattern collectionRelationship)
        {
            Pattern = collectionRelationship as IPagePattern;
        }
    }
}
