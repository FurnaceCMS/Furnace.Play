using System;
using System.Collections.Generic;

namespace Furnace.Core.Data.Play.Metas
{
    public interface IMetaCollection
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }
        List<IMeta> Metas { get; set; }

        IEnumerable<TMetaType> GetMeta<TMetaType>() where TMetaType : IMeta;
        TMetaType GetMeta<TMetaType>(string name) where TMetaType : IMeta;
    }
}