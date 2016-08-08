using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Queries.Relationships
{
    public class RelationshipQueryResult : QueryResult
    {
        public readonly IMetaCollectionRelationship CollectionRelationship;

        public RelationshipQueryResult(IMetaCollectionRelationship collectionRelationship)
        {
            CollectionRelationship = collectionRelationship;
        }
    }
}
