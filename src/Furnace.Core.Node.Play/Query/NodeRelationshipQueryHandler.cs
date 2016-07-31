using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Query
{
    public class NodeRelationshipQueryHandler : IQueryHandler<NodeRelationshipQuery, NodeRelationshipQueryResult>
    {
        private readonly IMetaRelationshipFactory _factory;

        public NodeRelationshipQueryHandler(IMetaRelationshipFactory factory)
        {
            _factory = factory;
        }

        public NodeRelationshipQueryResult Handle(NodeRelationshipQuery query)
        {
            var metaCollection = _factory.GetMetaRelationship(query.MasterNodeId);
            return new NodeRelationshipQueryResult(metaCollection);
        }
    }
}