using Storage;
using Transformer.Model;

namespace Transformer;

public class GameObjectGenerator : IGameObjectGenerator
{
    private readonly IStorage _storage;

    public GameObjectGenerator(IStorage storage)
    {
        _storage = storage;
    }

    public async Task Convert(string filePath, CancellationToken token = default)
    {
        var result = await _storage.Load<GameObjectsData>(filePath, token);
        
        GameObject gameObject = new GameObject(new Transform());
        
        await _storage.Save("testData1.json", result, token);
        
        Console.WriteLine("Successfully completed");
    }
}