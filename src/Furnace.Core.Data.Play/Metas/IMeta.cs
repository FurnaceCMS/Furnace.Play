using System;

namespace Furnace.Core.Data.Play.Metas
{
    public interface IMeta
    {
        Guid Id { get; set; }
        string Name { get; set; }
        DateTime DateCreated { get; set; }
        DateTime LastUpdated { get; set; }

        TValueType GetValue<TValueType>() where TValueType : class;
    }
}