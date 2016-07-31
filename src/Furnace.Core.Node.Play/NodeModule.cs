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
           
            Get("/collection/{collectionId}", parameters => HandleCollection(parameters));
            //Get("/relationship/{relationshipId}", parameters => HandleRelationship(parameters));
        }

        //private Response HandleRelationship(dynamic parameters)
        //{
        //    try
        //    {
        //        var nodeQuery = new NodeQuery
        //        {
        //            NodeId = parameters.relationshipId
        //        };

        //        var nodeQueryResult = _nodeQueryHandeler.Handle(nodeQuery);

        //        return "Relationship is " + nodeQueryResult;
        //    }
        //    catch (MetaCollectionNotFoundException)
        //    {
        //        return new NotFoundResponse();
        //    }
        //}

        private Response HandleCollection(dynamic parameters)
        {
            try
            {
                var nodeQuery = new NodeQuery
                {
                    NodeId = parameters.collectionId
                };

                var nodeQueryResult = _nodeQueryHandeler.Handle(nodeQuery);

                return "Collection is " + nodeQueryResult;
            }
            catch (MetaCollectionNotFoundException)
            {
                return new NotFoundResponse();
            }
        }
    }
}
