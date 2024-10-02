using Storage;
using Transformer.Model;

namespace Transformer;

public class GameObjectTransformer : IGameObjectTransformer
{
    private readonly IStorage _storage;

    public GameObjectTransformer(IStorage storage)
    {
        _storage = storage;
    }

    public Task Execute()
    {
        GameObject gameObject = new GameObject(new Transform());
        
        
        Console.WriteLine("Successfully completed");
        
        return Task.CompletedTask;
    }
}