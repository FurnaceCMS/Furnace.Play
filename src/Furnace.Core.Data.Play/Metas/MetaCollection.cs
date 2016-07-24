using System;
using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public class MetaCollection : IMetaCollection, IMeta
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public IList<IMeta> Metas { get; set; }
    }
}
