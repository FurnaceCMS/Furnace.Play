using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Node.Play.Query;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play
{
    public sealed class NodeModule: FurnaceModule
    {
        private readonly IQueryHandler<NodeQuery, NodeQueryResult> _nodeQueryHandeler;

        public NodeModule(IQueryHandler<NodeQuery, NodeQueryResult> nodeQueryHandeler)
        {
            _nodeQueryHandeler = nodeQueryHandeler;
           
            Get("/node/{nodeId}", parameters => "node is "  + Handel(parameters.nodeId).ToString());
        }

        private IMetaCollection Handel(Guid nodeId)
        {
            var nodeQuery = new NodeQuery
            {
                NodeId = nodeId
            };

            var nodeQueryResult = _nodeQueryHandeler.Handle(nodeQuery);
            return nodeQueryResult.MetaCollection;
        }
    }
}
