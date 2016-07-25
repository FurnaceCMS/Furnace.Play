using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public class IntMetaFactory : MetaFactory, ITypedMetaFactory<int>
    {
        public override Type FactoryType => typeof(int);

        public IMeta CreateMeta(string name, dynamic value)
        {
            return CreateTypedMeta(name, value);
        }

        public ITypedMeta<int> CreateTypedMeta(string name, int value)
        {
            return new IntMeta
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
