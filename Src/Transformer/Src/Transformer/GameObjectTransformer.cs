using Storage;
using Transformer.Generator;
using Transformer.Model;

namespace Transformer;

public class GameObjectTransformer : IGameObjectTransformer
{
    private readonly IStorage _storage;
    private readonly IGameObjectGenerator _gameObjectGenerator;

    public GameObjectTransformer(IStorage storage, IGameObjectGenerator gameObjectGenerator)
    {
        _storage = storage;
        _gameObjectGenerator = gameObjectGenerator;
    }

    public async Task Convert(string input, string output, CancellationToken token = default)
    {
        var inputData = await _storage.Load<GameObjectsData>(input, token);
        
        if (inputData == null || inputData.GameObjects.Length == 0) 
            return;
        
        var gameObjects = await _gameObjectGenerator.Generate(inputData.GameObjects, token);


        var outputData = new GameObjectsData();
        outputData.GameObjects = gameObjects.Select(it => new GameObjectDto()
        {
            Transform = new TransformDto()
            {
                Position = it.Transform.Position,
                Rotation = it.Transform.Rotation,
                Scale = it.Transform.Scale
            }
        }).ToArray();
        
        await _storage.Save(output, outputData, token);
    }
}