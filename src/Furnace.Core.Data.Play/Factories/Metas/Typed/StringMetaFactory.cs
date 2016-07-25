using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public class StringMetaFactory : MetaFactory, ITypedMetaFactory<string>
    {
        public override Type FactoryType => typeof(string);

        public IMeta CreateMeta(string name, dynamic value)
        {
            return CreateTypedMeta(name, value);
        }

        public ITypedMeta<string> CreateTypedMeta(string name, string value)
        {
            return new StringMeta
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
