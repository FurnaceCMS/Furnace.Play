using Furnace.Core.Data.Play.Persistence;
using Furnace.Core.Play.Query;
using Nancy;
using System.Text;
using Furnace.Core.Nancy.Play.Module;
using Furnace.Core.Node.Play.Queries.Collections;
using Furnace.Core.Node.Play.Queries.Patterns;
using Furnace.Core.Node.Play.Queries.Relationships;

namespace Furnace.Core.Node.Play
{
    public sealed class NodeModule: NancyFurnaceModule
    {
        private readonly IQueryHandler<CollectionQuery, CollectionQueryResult> _queryHandeler;
        private readonly IQueryHandler<RelationshipQuery, RelationshipQueryResult> _relationshipHandler;
        private readonly IQueryHandler<PatternQuery, PatternQueryResult> _patterHandler;

        public NodeModule(IQueryHandler<CollectionQuery, CollectionQueryResult> queryHandeler, IQueryHandler<RelationshipQuery, RelationshipQueryResult> relationshipHandler, IQueryHandler<PatternQuery, PatternQueryResult> patterHandler)
        {
            _queryHandeler = queryHandeler;
            _relationshipHandler = relationshipHandler;
            _patterHandler = patterHandler;

            Get("/collection/{collectionId}", parameters => HandleCollection(parameters));
            Get("/CollectionRelationship/{relationshipId}", parameters => HandleRelationship(parameters));
            Get("/PagePattern/{collectionId}", parameters => HandlePagePattern(parameters));
        }

        private Response HandlePagePattern(dynamic parameters)
        {
            try
            {
                var nodeQuery = new PatternQuery
                {
                    CollectionId = parameters.collectionId
                };

                var patternQueryResult = _patterHandler.Handle(nodeQuery);

                var output = new StringBuilder($"Pattern - Id:{patternQueryResult.Pattern.Id}");
                output.Append($", Title: {patternQueryResult.Pattern.Title}");
                output.Append($", Body: {patternQueryResult.Pattern.Body}");
                output.Append($", MetaAuthor: {patternQueryResult.Pattern.MetaAuthor}");
                output.Append($", MetaDescription: {patternQueryResult.Pattern.MetaDescription}");
                output.Append($", MetaKeywords: {patternQueryResult.Pattern.MetaKeywords}");
                output.Append($", MetaTitle: {patternQueryResult.Pattern.MetaTitle}");
                return output.ToString();
            }
            catch (MetaCollectionNotFoundException)
            {
                return new NotFoundResponse();
            }
        }

        private Response HandleRelationship(dynamic parameters)
        {
            try
            {
                var nodeRelationshipQuery = new RelationshipQuery()
                {
                    MasterMetaCollectionId = parameters.relationshipId
                };

                var nodeRelationshipQueryResult = _relationshipHandler.Handle(nodeRelationshipQuery);

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
                var nodeQuery = new CollectionQuery
                {
                    CollectionId = parameters.collectionId
                };

                var nodeQueryResult = _queryHandeler.Handle(nodeQuery);

                return $"Collection is {nodeQueryResult}";
            }
            catch (MetaCollectionNotFoundException)
            {
                return new NotFoundResponse();
            }
        }
    }
}
