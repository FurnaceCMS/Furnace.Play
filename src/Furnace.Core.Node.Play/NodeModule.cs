using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Persistence;
using Furnace.Core.Node.Play.Query;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;
using Nancy;

namespace Furnace.Core.Node.Play
{
    public sealed class NodeModule: FurnaceModule
    {
        private readonly IQueryHandler<NodeQuery, NodeQueryResult> _nodeQueryHandeler;

        public NodeModule(IQueryHandler<NodeQuery, NodeQueryResult> nodeQueryHandeler)
        {
            _nodeQueryHandeler = nodeQueryHandeler;
           
            Get("/node/{nodeId}", parameters => Handel(parameters));
        }

        private Response Handel(dynamic parameters)
        {
            try
            {
                var nodeQuery = new NodeQuery
                {
                    NodeId = parameters.nodeId
                };

                var nodeQueryResult = _nodeQueryHandeler.Handle(nodeQuery);

                return "node is " + nodeQueryResult;
            }
            catch (MetaCollectionNotFoundException)
            {
                return new NotFoundResponse();
            }
        }
    }
}
