using Storage;
using Transformer.Model;
using UnityEngine;
using GameObject = Transformer.Model.GameObject;

namespace Transformer;

public class GameObjectTransformer : IGameObjectTransformer
{
    private readonly IStorage _storage;

    public GameObjectTransformer(IStorage storage)
    {
        _storage = storage;
    }

    public async Task Convert(string input, string output, CancellationToken token = default)
    {
        var inputData = await _storage.Load<GameObjectsData>(input, token);
        
        if (inputData == null || inputData.GameObjects.Length == 0) 
            return;
        
        var gameObjects = inputData.GameObjects.Select(it => new GameObject(it))
            .OrderBy(it => Vector3.Distance(it.Transform.Position, Vector3.zero))
            .ToArray();

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