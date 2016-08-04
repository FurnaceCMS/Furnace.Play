using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Persistence;
using System.Linq;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public class MetaRelationshipFactory : IMetaRelationshipFactory
    {
        private readonly IPersistence<IMetaCollectionRelationship> _persistence;
        private readonly IMetaCollectionFactory _metaCollectionFactory;

        public MetaRelationshipFactory(IPersistence<IMetaCollectionRelationship> persistence, IMetaCollectionFactory metaCollectionFactory)
        {
            _persistence = persistence;
            _metaCollectionFactory = metaCollectionFactory;
        }

        public IMetaCollectionRelationship GetMetaRelationship(Guid masterMetaId)
        {
            var metaCollectionRelationship = _persistence.Load(masterMetaId);
            return metaCollectionRelationship != null ? PopulateRelationshipMetaCollections(metaCollectionRelationship) : null;
        }

        private IMetaCollectionRelationship PopulateRelationshipMetaCollections(IMetaCollectionRelationship metaCollectionRelationship)
        {
            metaCollectionRelationship.MasterMetaCollection = _metaCollectionFactory.GetMetaCollection(metaCollectionRelationship.MasterMetaCollectionId);
            foreach (var relatedId in metaCollectionRelationship.RelatedMetaCollectionIds)
            {
                var relatedMetaCollection = _metaCollectionFactory.GetMetaCollection(relatedId);
                if(relatedMetaCollection == null)
                    continue;
                
                metaCollectionRelationship.RelatedMetaCollections.Add(relatedMetaCollection);
            }
            return metaCollectionRelationship;
        }

        public IMetaCollectionRelationship CreateMetaRelationsip(Guid masterMetaId, Guid relatedMetaId)
        {
            var metaRelationship = GetMetaRelationship(masterMetaId);
            if (metaRelationship == null)
            {
                var masterMetaCollection = _metaCollectionFactory.GetMetaCollection(masterMetaId);
                if (masterMetaCollection == null)
                {
                    throw new MetaCollectionNotFoundException();
                }

                metaRelationship = new MetaCollectionRelationship(masterMetaCollection);
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

        public IMetaCollectionRelationship DeleteMetaRelationsip(Guid masterMetaId, Guid relatedMetaId)
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

        private static bool DoesMetaRelationshipExist(IMetaCollectionRelationship metaCollectionRelationship, Guid relatedMetaId)
        {
            return metaCollectionRelationship.RelatedMetaCollections.Any(x => x.Id == relatedMetaId);
        }
    }
}
