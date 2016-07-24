using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public class MetaRelationship : IMetaRelationship
    {
        public IMetaCollection Parent { get; set; }
        public IList<IMetaCollection> Children { get; set; }
    }
}
