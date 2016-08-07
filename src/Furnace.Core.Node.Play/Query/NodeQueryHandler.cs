using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Query
{
    public class NodeQueryHandler: IQueryHandler<NodeQuery,NodeQueryResult>
    {
        private readonly IMetaCollectionFactory _metaCollectionFactory;

        public NodeQueryHandler(IMetaCollectionFactory metaCollectionFactory)
        {
            _metaCollectionFactory = metaCollectionFactory;
        }

        public NodeQueryResult Handle(NodeQuery query)
        {
            var metaCollection = _metaCollectionFactory.GetMetaCollection(query.NodeId);
            return new NodeQueryResult(metaCollection);
        }
    }
}
