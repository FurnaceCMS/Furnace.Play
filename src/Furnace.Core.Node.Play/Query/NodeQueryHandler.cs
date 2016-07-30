using System;
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
            var data = new Dictionary<string, dynamic>
            {
                {"Title", "test"},
            };
            var metaCollection  = _metaCollectionFactory.CreateMetaCollection("test", data);

            return new NodeQueryResult(metaCollection);
        }
    }
}
