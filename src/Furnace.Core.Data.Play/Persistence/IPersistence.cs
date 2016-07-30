using System;
using Furnace.Core.Data.Play.Metas;

namespace Furnace.Core.Data.Play.Persistence
{
    public interface IPersistence
    {
        void Save(IMetaCollection metaCollection);
        IMetaCollection Load(Guid id);
    }
}
