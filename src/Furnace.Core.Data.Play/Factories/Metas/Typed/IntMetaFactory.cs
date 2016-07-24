using System;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public class IntMetaFactory : MetaFactory, ITypedMetaFactory<int>
    {
        public ITypedMeta<int> CreateMeta(string name, int value)
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
