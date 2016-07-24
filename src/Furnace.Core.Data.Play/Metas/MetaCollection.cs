using System;
using System.Collections.Generic;
using System.Linq;

namespace Furnace.Core.Data.Play.Metas
{
    public class MetaCollection : IMetaCollection
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public List<IMeta> Metas { get; set; }

        public IMeta this[string name]
        {
            get { return Metas.FirstOrDefault(x => x.Name == name); }
        }

        public MetaCollection()
        {
            Metas = new List<IMeta>();
        }
    }
}
