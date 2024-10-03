using Storage;
using Transformer.Exceptions;
using Transformer.Generator;
using Transformer.Model;
using UnityEngine;

namespace Transformer;

public class GameObjectService : IGameObjectService
{
    private readonly IStorage _storage;
    private readonly IGameObjectFactory _gameObjectFactory;

    public GameObjectService(IStorage storage, IGameObjectFactory gameObjectFactory)
    {
        _storage = storage;
        _gameObjectFactory = gameObjectFactory;
    }

    public async Task Transform(string input, string output, CancellationToken token = default)
    {
        var inputData = await _storage.Load<GameObjectsData>(input, token);

        if (inputData == null || inputData.GameObjects.Length == 0)
        {
            throw new GameObjectServiceException("GameObjects not found");
        }
        
        var gameObjects = inputData.GameObjects.Select(_gameObjectFactory.Create)
            .OrderBy(it => Vector3.Distance(it.Transform.Position, Vector3.zero));

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