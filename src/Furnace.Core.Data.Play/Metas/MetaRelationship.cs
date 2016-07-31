using System;
using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public class MetaRelationship : IMetaRelationship
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Type => GetType().FullName;
        public IMetaCollection MasterMetaCollection { get; set; }
        public IList<IMetaCollection> RelatedMetaCollections { get; set; }

        public MetaRelationship()
        {
            RelatedMetaCollections = new List<IMetaCollection>();
        }

        public MetaRelationship(IMetaCollection masterMetaCollection) : this()
        {
            MasterMetaCollection = masterMetaCollection;
        }
    }
}
