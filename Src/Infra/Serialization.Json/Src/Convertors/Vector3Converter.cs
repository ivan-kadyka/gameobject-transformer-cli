namespace Serialization.Json.Convertors;

using System;
using Newtonsoft.Json;
using UnityEngine;

// Custom JsonConverter for Vector3
internal class Vector3Converter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Vector3 vector = (Vector3)value;
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(vector.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(vector.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(vector.z);
        writer.WriteEndObject();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        // Read the vector data from JSON
        float x = 0, y = 0, z = 0;

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
                }
            }

            if (reader.TokenType == JsonToken.EndObject)
            {
                break;
            }
        }

        return new Vector3(x, y, z);
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Vector3);
    }
}