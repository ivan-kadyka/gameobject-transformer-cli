using Newtonsoft.Json;
using Serialization.Json;
using Serialization.Json.Convertors;
using Storage.FileSystem;
using Transformer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var jsonConvertors = new JsonConverter[]
        {
           new Vector3Converter(),
           new QuaternionConverter(),
        };
        var jsonDtoFormatter = new JsonDtoFormatter(jsonConvertors);
        var fileSystemStorage = new FileSystemStorage(jsonDtoFormatter);
        
        var transformer = new GameObjectTransformer(fileSystemStorage);

        await transformer.Convert("testData.json", "outputData.json");
        
    }
}

