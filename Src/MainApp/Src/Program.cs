using MainApp.Options;
using Newtonsoft.Json;
using Serialization.Json;
using Serialization.Json.Convertors;
using Storage.FileSystem;
using Transformer;
using Transformer.Generator;

public static class Program
{
    public static async Task Main(string[] args)
    {
        IOptions options = new Options
        {
            Input = "testData.json",
            Output = "outputData.json"
        };
        
        var jsonConvertors = new JsonConverter[]
        {
           new Vector3Converter(),
           new QuaternionConverter(),
        };
        var jsonDtoFormatter = new JsonDtoFormatter(jsonConvertors);
        var fileSystemStorage = new FileSystemStorage(jsonDtoFormatter);

        var gameObjectFactory = new GameObjectFactory();
        var gameObjectService = new GameObjectService(fileSystemStorage, gameObjectFactory);

        await gameObjectService.Transform(options.Input, options.Output);
    }
}

