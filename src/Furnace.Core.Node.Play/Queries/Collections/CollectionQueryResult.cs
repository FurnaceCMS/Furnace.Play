using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Queries.Collections
{
    public class CollectionQueryResult : QueryResult
    {
        public readonly IMetaCollection MetaCollection;

        public CollectionQueryResult(IMetaCollection metaCollection)
        {
            MetaCollection = metaCollection;
        }
    }
}
