using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Query
{
    public class NodeRelationshipQueryResult : QueryResult
    {
        public readonly IMetaRelationship Relationship;

        public NodeRelationshipQueryResult(IMetaRelationship relationship)
        {
            Relationship = relationship;
        }
    }
}
