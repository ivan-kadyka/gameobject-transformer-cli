using Serialization.Json;
using Storage.FileSystem;
using Transformer;
using Transformer.Generator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var jsonDtoFormatter = new JsonDtoFormatter();
        var fileSystemStorage = new FileSystemStorage(jsonDtoFormatter);

        var gameObjectGenerator = new GameObjectGenerator();
        var transformer = new GameObjectTransformer(fileSystemStorage, gameObjectGenerator);

        await transformer.Convert("testData.json", "outputData.json");
        
    }
}

