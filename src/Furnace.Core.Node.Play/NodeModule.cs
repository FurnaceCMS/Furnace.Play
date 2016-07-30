using Furnace.Core.Data.Play.Metas.Typed;
using Furnace.Core.Node.Play.Query;
using Furnace.Core.Play.Module;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play
{
    public sealed class NodeModule: FurnaceModule
    {
        public NodeModule(IQueryHandler<NodeQuery, NodeQueryResult> nodeQueryHandeler)
        {
            var node = nodeQueryHandeler.Handle(new NodeQuery()).MetaCollection;
            Get("/node/{nodeId}", parameters => "nodeId is " + node.GetMeta<StringMeta>("Title").ToString());
        }
    }
}
