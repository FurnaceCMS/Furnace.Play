using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public interface IMetaRelationship : IMeta
    {
        IMetaCollection MasterMetaCollection { get; set; }
        IList<IMetaCollection> RelatedMetaCollections { get; set; }
    }
}