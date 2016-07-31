using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Persistence;
using System.Linq;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public class MetaRelationshipFactory : IMetaRelationshipFactory
    {
        private readonly IPersistence<IMetaRelationship> _persistence;
        private readonly IMetaCollectionFactory _metaCollectionFactory;

        public MetaRelationshipFactory(IPersistence<IMetaRelationship> persistence, IMetaCollectionFactory metaCollectionFactory)
        {
            _persistence = persistence;
            _metaCollectionFactory = metaCollectionFactory;
        }

        public IMetaRelationship GetMetaRelationship(Guid masterMetaId)
        {
            return _persistence.Load(masterMetaId);
        }

        public IMetaRelationship CreateMetaRelationsip(Guid masterMetaId, Guid relatedMetaId)
        {
            var metaRelationship = GetMetaRelationship(masterMetaId);
            if (metaRelationship == null)
            {
                var masterMetaCollection = _metaCollectionFactory.GetMetaCollection(masterMetaId);
                if (masterMetaCollection == null)
                {
                    throw new MetaCollectionNotFoundException();
                }

                metaRelationship = new MetaRelationship(masterMetaCollection);
            }

            if (DoesMetaRelationshipExist(metaRelationship, relatedMetaId))
            {
                return metaRelationship;
            }

            var relatedMetaCollection = _metaCollectionFactory.GetMetaCollection(relatedMetaId);
            if (relatedMetaCollection == null)
            {
                throw new MetaCollectionNotFoundException();
            }

            metaRelationship.RelatedMetaCollections.Add(relatedMetaCollection);
            _persistence.Save(metaRelationship);
            return metaRelationship;
        }

        public IMetaRelationship DeleteMetaRelationsip(Guid masterMetaId, Guid relatedMetaId)
        {
            var metaRelationship = GetMetaRelationship(masterMetaId);
            if (metaRelationship == null)
            {
                throw new MetaRelationshipNotFoundException();
            }

            if (!DoesMetaRelationshipExist(metaRelationship, relatedMetaId))
            {
                return metaRelationship;
            }

            metaRelationship.RelatedMetaCollections.Remove(metaRelationship.RelatedMetaCollections.First(x => x.Id == relatedMetaId));
            _persistence.Save(metaRelationship);
            return metaRelationship;
        }

        private static bool DoesMetaRelationshipExist(IMetaRelationship metaRelationship, Guid relatedMetaId)
        {
            return metaRelationship.RelatedMetaCollections.Any(x => x.Id == relatedMetaId);
        }
    }
}
