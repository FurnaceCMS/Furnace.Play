using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public interface IMetaRelationship
    {
        IMetaCollection Parent { get; set; }
        IList<IMetaCollection> Children { get; set; }
    }
}