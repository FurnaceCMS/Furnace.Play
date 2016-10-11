using System;
using Furnace.Core.Data.Play.Query.Configuration.MetaTypeMaping;
using Newtonsoft.Json;
using System.Reflection;

namespace Furnace.Core.Nancy.Play.Module.JSON
{
    public class MetaTypeMapingSerializer: JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var metaTypeMaping = value as MetaTypeMapingQueryResult;
            writer.WriteStartObject();

            if (metaTypeMaping != null)
                foreach (var mapping in metaTypeMaping)
                {
                    writer.WritePropertyName(mapping.Key);
                    serializer.Serialize(writer, mapping.Value);
                }

            writer.WriteEndObject(); 
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(MetaTypeMapingQueryResult).IsAssignableFrom(objectType);
        }
    }
}
