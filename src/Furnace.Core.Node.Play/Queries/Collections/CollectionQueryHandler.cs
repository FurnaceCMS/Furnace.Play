using Furnace.Core.Data.Play.Factories.Metas;
using Furnace.Core.Play.Query;

namespace Furnace.Core.Node.Play.Queries.Collections
{
    public class CollectionQueryHandler : IQueryHandler<CollectionQuery,CollectionQueryResult>
    {
        private readonly IMetaCollectionFactory _metaCollectionFactory;

        public CollectionQueryHandler(IMetaCollectionFactory metaCollectionFactory)
        {
            _metaCollectionFactory = metaCollectionFactory;
        }

        public CollectionQueryResult Handle(CollectionQuery collectoinQuery)
        {
            var metaCollection = _metaCollectionFactory.GetMetaCollection(collectoinQuery.CollectionId);
            return new CollectionQueryResult(metaCollection);
        }
    }
}
