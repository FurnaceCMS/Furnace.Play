using Furnace.Core.Node.Play.Query;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play
{
    public sealed class NodeModule: FurnaceModule
    {
        public NodeModule(IQueryHandler<NodeQuery, NodeQueryResult> nodeQueryHandeler)
        {
            Get("/node/{nodeId}", parameters => "nodeId is " + parameters.nodeId);
        }
    }
}
