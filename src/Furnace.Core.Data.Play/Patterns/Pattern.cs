using System;
using Furnace.Core.Data.Play.Metas;
using System.Linq;

namespace Furnace.Core.Data.Play.Patterns
{
    public abstract class Pattern : IPattern
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public abstract string Type { get; }
        public IMetaCollection RawData { get; }

        protected Pattern(string name, IMetaCollection metaCollection)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
            RawData = metaCollection;
        }


    }
}
