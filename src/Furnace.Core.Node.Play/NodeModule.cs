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
            Get("/CollectionRelationship/{relationshipId}", parameters => HandleRelationship(parameters));
        }

        private Response HandleRelationship(dynamic parameters)
        {
            try
            {
                var nodeRelationshipQuery = new NodeRelationshipQuery()
                {
                    MasterNodeId = parameters.relationshipId
                };

                var nodeRelationshipQueryResult = _nodeRelationshipHandler.Handle(nodeRelationshipQuery);

                var output = new StringBuilder($"Meta Relationship - MasterMetaId:{nodeRelationshipQueryResult.CollectionRelationship.MasterMetaCollectionId}");
                foreach (var relatedMetaId in nodeRelationshipQueryResult.CollectionRelationship.RelatedMetaCollectionIds)
                {
                    output.Append($", Related ID: {relatedMetaId}");
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
