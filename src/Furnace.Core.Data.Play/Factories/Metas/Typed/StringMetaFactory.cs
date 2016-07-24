using System;
using Furnace.Core.Data.Play.Metas.Typed;

namespace Furnace.Core.Data.Play.Factories.Metas.Typed
{
    public class StringMetaFactory : MetaFactory, ITypedMetaFactory<string>
    {
        public ITypedMeta<string> CreateMeta(string name, string value)
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
