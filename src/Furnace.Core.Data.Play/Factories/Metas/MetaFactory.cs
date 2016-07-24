using System;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public abstract class MetaFactory : IMetaFactory
    {
        public abstract Type FactoryType { get; }
    }
}
