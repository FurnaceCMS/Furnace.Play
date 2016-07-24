using System;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public abstract class MetaFactory : IMetaFactory
    {
        protected IMeta PopulateStandardValues(IMeta meta, string name)
        {
            meta.DateCreated = DateTime.UtcNow;
            meta.Id = Guid.NewGuid();
            meta.LastUpdated = DateTime.UtcNow;
            meta.Name = name;
            return meta;
        }
    }
}
