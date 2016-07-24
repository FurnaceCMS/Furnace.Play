using System;

namespace Furnace.Core.Data.Play.Metas
{
    public abstract class Meta<TValueType> : IMeta
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public TValueType Value { get; set; }

        public override string ToString()
        {
            return $"Furnace {typeof(TValueType)} meta. ID: {Id}. Name: {Name}";
        }
    }
}
