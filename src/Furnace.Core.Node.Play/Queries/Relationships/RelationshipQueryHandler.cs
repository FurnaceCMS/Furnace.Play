using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Queries.Relationships
{
    public class RelationshipQueryHandler : IQueryHandler<RelationshipQuery, RelationshipQueryResult>
    {
        private readonly IMetaRelationshipFactory _factory;

        public RelationshipQueryHandler(IMetaRelationshipFactory factory)
        {
            _factory = factory;
        }

        public RelationshipQueryResult Handle(RelationshipQuery query)
        {
            var metaCollection = _factory.GetMetaRelationship(query.MasterMetaCollectionId);
            return new RelationshipQueryResult(metaCollection);
        }
    }
}