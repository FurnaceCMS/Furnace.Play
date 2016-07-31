using System;
using Furnace.Core.Data.Play.Metas;
using Furnace.Core.Data.Play.Metas.Typed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Furnace.Core.Data.Play.Persistence
{
    public class MetaConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.FullName == typeof(IMeta).FullName;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);
            if (jo["Type"].Value<string>() == typeof(StringMeta).FullName)
                return jo.ToObject<StringMeta>(serializer);

            if (jo["Type"].Value<string>() == typeof(IntMeta).FullName)
                return jo.ToObject<IntMeta>(serializer);

            if (jo["Type"].Value<string>() == typeof(DateTimeMeta).FullName)
                return jo.ToObject<DateTimeMeta>(serializer);

            throw new NotSupportedException(string.Format("Type {0} unexpected.", objectType));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
