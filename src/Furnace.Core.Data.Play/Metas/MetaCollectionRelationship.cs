using System;
using System.Collections.Generic;
using Furnace.Core.Data.Play.Persistence;

namespace Furnace.Core.Data.Play.Metas
{
    public class MetaCollectionRelationship : IMetaCollectionRelationship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Type => GetType().FullName;
        public Guid MasterMetaCollectionId { get; set; }
        public IList<Guid> RelatedMetaCollectionIds { get; set; }

        [DontPersist]
        public IMetaCollection MasterMetaCollection { get; set; }

        [DontPersist]
        public IList<IMetaCollection> RelatedMetaCollections { get; set; }
        
        public MetaCollectionRelationship()
        {
            RelatedMetaCollections = new List<IMetaCollection>();
            RelatedMetaCollectionIds = new List<Guid>();
        }

        public MetaCollectionRelationship(IMetaCollection masterMetaCollection) : this()
        {
            MasterMetaCollection = masterMetaCollection;
            MasterMetaCollectionId = masterMetaCollection.Id;
        }
    }
}
