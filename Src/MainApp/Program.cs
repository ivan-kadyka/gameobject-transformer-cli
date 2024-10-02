using Transformer;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var transformer = new GameObjectTransformer();

        await transformer.Execute();
    } 
}

