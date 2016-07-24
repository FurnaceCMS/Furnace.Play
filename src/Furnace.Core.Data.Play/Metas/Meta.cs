using System;

namespace Furnace.Core.Data.Play.Metas
{
    public abstract class Meta<TMetaType> : IMeta
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
        public TMetaType Value { get; set; }

        public TValueType GetValue<TValueType>() where TValueType : class
        {
            if (typeof(TMetaType) != typeof(TValueType))
            {
                throw new Exception("Ivalid type");
            }

            return Value as TValueType;
        }

        public override string ToString()
        {
            return $"Furnace {typeof(TMetaType)} meta. ID: {Id}. Name: {Name}";
        }
    }
}
