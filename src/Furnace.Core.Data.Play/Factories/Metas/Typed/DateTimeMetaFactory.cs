using System;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public class DateTimeMetaFactory : MetaFactory, ITypedMetaFactory<DateTime>
    {
        public ITypedMeta<DateTime> CreateMeta(string name, DateTime value)
        {
            return new DateTimeMeta()
            {
                DateCreated = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                LastUpdated = DateTime.UtcNow,
                Name = name,
                Value = value
            };
        }
    }
}
