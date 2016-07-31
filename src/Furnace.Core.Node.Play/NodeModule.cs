using System.Text;
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
        private readonly IQueryHandler<NodeRelationshipQuery, NodeRelationshipQueryResult> _nodeRelationshipHandler;

        public NodeModule(IQueryHandler<NodeQuery, NodeQueryResult> nodeQueryHandeler, IQueryHandler<NodeRelationshipQuery, NodeRelationshipQueryResult> nodeRelationshipHandler)
        {
            _nodeQueryHandeler = nodeQueryHandeler;
            _nodeRelationshipHandler = nodeRelationshipHandler;

            Get("/collection/{collectionId}", parameters => HandleCollection(parameters));
            Get("/relationship/{relationshipId}", parameters => HandleRelationship(parameters));
        }

        private Response HandleRelationship(dynamic parameters)
        {
            try
            {
                var nodeRelationshipQuery = new NodeRelationshipQuery()
                {
                    MasterNodeId = parameters.relationshipId
                };

                var nodeQueryResult = _nodeRelationshipHandler.Handle(nodeRelationshipQuery);

                var output = new StringBuilder($"Meta Relationship - MasterMetaId:{nodeQueryResult.Relationship.MasterMetaCollection.Id}");
                foreach (var relatedMeta in nodeQueryResult.Relationship.RelatedMetaCollections)
                {
                    output.Append($", Related ID: {relatedMeta.Id}");
                }

                return output.ToString();
            }
            catch (MetaCollectionNotFoundException)
            {
                return new NotFoundResponse();
            }
            catch (MetaRelationshipNotFoundException)
            {
                return new NotFoundResponse();
            }
        }

        private Response HandleCollection(dynamic parameters)
        {
            try
            {
                var nodeQuery = new NodeQuery
                {
                    NodeId = parameters.collectionId
                };

                var nodeQueryResult = _nodeQueryHandeler.Handle(nodeQuery);

                return $"Collection is {nodeQueryResult}";
            }
            catch (MetaCollectionNotFoundException)
            {
                return new NotFoundResponse();
            }
        }
    }
}
