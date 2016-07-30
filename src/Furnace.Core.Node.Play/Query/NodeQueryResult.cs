using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Query
{
    public class NodeQueryResult:QueryResult
    {
        public readonly IMetaCollection MetaCollection;

        public NodeQueryResult(IMetaCollection metaCollection)
        {
            MetaCollection = metaCollection;
        }
    }
}
