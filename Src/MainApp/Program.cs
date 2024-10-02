using Serialization.Json;
using Storage.FileSystem;
using Transformer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var jsonDtoFormatter = new JsonDtoFormatter();
        var fileSystemStorage = new FileSystemStorage(jsonDtoFormatter);
        var transformer = new GameObjectGenerator(fileSystemStorage);

        await transformer.Convert("testData.json");
        
    }
}

