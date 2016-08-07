using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Query
{
    public class NodeRelationshipQueryResult : QueryResult
    {
        public readonly IMetaCollectionRelationship CollectionRelationship;

        public NodeRelationshipQueryResult(IMetaCollectionRelationship collectionRelationship)
        {
            CollectionRelationship = collectionRelationship;
        }
    }
}
