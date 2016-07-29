using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Query
{
    public class NodeQueryHandle: IQueryHandler<NodeQuery,NodeQueryResult>
    {
        public NodeQueryResult Handle(NodeQuery query)
        {
            return new NodeQueryResult();
        }
    }
}
