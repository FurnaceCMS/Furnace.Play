using System;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public interface IMetaFactory
    {
        Type FactoryType { get; }
        IMeta CreateMeta(string name, dynamic value);
    }
}