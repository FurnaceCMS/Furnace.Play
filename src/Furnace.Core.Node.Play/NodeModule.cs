using Furnace.Core.Play.Module;

namespace Furnace.Core.Node.Play
{
    public sealed class NodeModule: FurnaceModule
    {
        public NodeModule()
        {
            Get("/node/{nodeId}", parameters => "nodeId is " + parameters.nodeId);
        }
    }
}
