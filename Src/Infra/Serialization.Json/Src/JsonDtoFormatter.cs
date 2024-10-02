using Newtonsoft.Json;

namespace Serialization.Json;

public class JsonDtoFormatter : IDtoFormatter
{
    private readonly JsonSerializerSettings _settings;
        
    public JsonDtoFormatter()
    {
        // example how to possible setup settings
        _settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }
        
    public string Serialize<T>(T value)
    {
        try
        {
            return JsonConvert.SerializeObject(value, _settings);
        }
        catch (Exception e)
        {
            throw new DtoFormatterException(DtoFormatterErrorType.Encoding, $"Failed to encode with object type '{value?.GetType().FullName}'", e);
        }
    }

    public T Deserialize<T>(string value)
    {
        try
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
        catch (Exception e)
        {
            throw new DtoFormatterException(DtoFormatterErrorType.Decoding, $"Failed to deserialize string '{value}' to type {typeof(T)}", e);
        }
    }
}