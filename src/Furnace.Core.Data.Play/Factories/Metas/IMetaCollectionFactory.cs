using System;
using System.Collections.Generic;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Factories.Metas
{
    public interface IMetaCollectionFactory
    {
        IDictionary<Type, IMetaFactory> TypedMetaFactories { get; set; }
        IMetaCollection GetMetaCollection(Guid id);
        IMetaCollection CreateMetaCollection(string name, IDictionary<string, object> data);
    }
}