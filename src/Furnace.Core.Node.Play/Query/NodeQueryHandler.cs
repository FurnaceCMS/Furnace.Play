using System.Collections.Generic;
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
            //var data = new Dictionary<string, dynamic>
            //{
            //    {"Title", "metaString1Value"}
            //};

            //_metaCollectionFactory.CreateMetaCollection("test", data);

            var metaCollection = _metaCollectionFactory.GetMetaCollection(query.NodeId);

            return new NodeQueryResult(metaCollection);
        }
    }
}
