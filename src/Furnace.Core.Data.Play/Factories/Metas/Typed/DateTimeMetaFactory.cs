using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public class DateTimeMetaFactory : MetaFactory, ITypedMetaFactory<DateTime>
    {
        public override Type FactoryType => typeof(DateTime);

        public IMeta CreateMeta(string name, dynamic value)
        {
            return CreateTypedMeta(name, value);
        }

        public ITypedMeta<DateTime> CreateTypedMeta(string name, DateTime value)
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
