using Newtonsoft.Json;
using UnityEngine;

namespace Serialization.Json.Convertors;

// Custom JsonConverter for Quaternion
internal class QuaternionConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Quaternion quaternion = (Quaternion)value;
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(quaternion.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(quaternion.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(quaternion.z);
        writer.WritePropertyName("W");
        writer.WriteValue(quaternion.w);
        writer.WriteEndObject();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Read the quaternion data from JSON
        float x = 0, y = 0, z = 0, w = 0;

        while (reader.Read())
        {
            if (reader.TokenType == JsonToken.PropertyName)
            {
                string propertyName = reader.Value.ToString();
                reader.Read();
                switch (propertyName)
                {
                    case "X":
                        x = (float)(reader.Value ?? 0);
                        break;
                    case "Y":
                        y = (float)(reader.Value ?? 0);
                        break;
                    case "Z":
                        z = (float)(reader.Value ?? 0);
                        break;
                    case "W":
                        w = (float)(reader.Value ?? 0);
                        break;
                }
            }

            if (reader.TokenType == JsonToken.EndObject)
            {
                break;
            }
        }

        return new Quaternion(x, y, z, w);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Quaternion);
    }
}