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

        public IEnumerable<TMetaType> GetMeta<TMetaType>() where TMetaType : IMeta
        {
            return Metas.Where(x => x is TMetaType)
                        .Cast<TMetaType>();
        }

        public TMetaType GetMeta<TMetaType>(string name) where TMetaType : IMeta
        {
            return Metas.Where(x => x is TMetaType && x.Name == name)
                        .Cast<TMetaType>()
                        .FirstOrDefault();
        }

        public MetaCollection()
        {
            Metas = new List<IMeta>();
        }

        public override string ToString()
        {
            var metas = string.Empty;
            foreach (var meta in Metas)
            {
                metas += meta + "\n";
            }
            
            return $"Furnace ID: {Id}. Name: {Name} Metas: {metas} ";
        }
    }
}
