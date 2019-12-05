using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Kronos.WFD.Serializers
{
    public class DataRootEntityConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var value = new DataRootEntity();
            if (reader.TokenType == JsonToken.String)
            {
                value.Name = (string)reader.Value;
            }
            else if (reader.TokenType == JsonToken.Null)
            {
                value = null;
            }
            else
            {
                JObject jObject = JObject.Load(reader);
                serializer.Populate(jObject.CreateReader(), value);
            }

            return value;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
