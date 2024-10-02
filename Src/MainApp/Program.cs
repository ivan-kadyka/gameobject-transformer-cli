using Serialization.Json;
using Transformer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var jsonDtoFormatter = new JsonDtoFormatter();
        var transformer = new GameObjectTransformer();

        await transformer.Execute();
    }
}

