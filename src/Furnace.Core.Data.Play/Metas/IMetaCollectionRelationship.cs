using System;
using System.Collections.Generic;
using Furnace.Core.Data.Play.Persistence;

namespace Furnace.Core.Data.Play.Metas
{
    public interface IMetaCollectionRelationship : IMeta
    {
        [DontPersist]
        IMetaCollection MasterMetaCollection { get; set; }

        [DontPersist]
        IList<IMetaCollection> RelatedMetaCollections { get; set; }

        Guid MasterMetaCollectionId { get; set; }
        IList<Guid> RelatedMetaCollectionIds { get; set; }
    }
}