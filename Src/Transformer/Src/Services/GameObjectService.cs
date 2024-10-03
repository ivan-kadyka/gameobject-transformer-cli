using Microsoft.Extensions.Logging;
using Storage;
using Transformer.Exceptions;
using Transformer.Generator;
using Transformer.Model;
using UnityEngine;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Transformer;

public class GameObjectService : IGameObjectService
{
    private readonly IStorage _storage;
    private readonly IGameObjectFactory _gameObjectFactory;
    private readonly ILogger _logger;

    public GameObjectService(
        IStorage storage,
        IGameObjectFactory gameObjectFactory,
        ILoggerFactory loggerFactory)
    {
        _storage = storage;
        _gameObjectFactory = gameObjectFactory;
        _logger = loggerFactory.CreateLogger(nameof(GameObjectService));
    }

    public async Task Transform(string input, string output, CancellationToken token = default)
    {
        _logger.LogTrace($"Transforming GameObjects... input='{input}', output='{output}'");
        
        var inputData = await _storage.Load<GameObjectsData>(input, token);

        if (inputData == null)
        {
            throw new GameObjectServiceException("GameObjects not found");
        }

        token.ThrowIfCancellationRequested();

        var gameObjectDtos = await Transform(inputData.GameObjects, token);

        var outputData = new GameObjectsData
        {
            GameObjects = gameObjectDtos
        };

        token.ThrowIfCancellationRequested();

        await _storage.Save(output, outputData, token);

    }

    public Task<IReadOnlyCollection<GameObjectDto>> Transform(IReadOnlyCollection<GameObjectDto> gameObjectDtos, CancellationToken token = default)
    {
        if (gameObjectDtos.Count == 0)
        {
            throw new GameObjectServiceException("GameObjects not found");
        }

        var gameObjects = gameObjectDtos.Select(_gameObjectFactory.Create)
            .OrderBy(it => Vector3.Distance(it.Transform.Position, Vector3.zero));

        token.ThrowIfCancellationRequested();

        IReadOnlyCollection<GameObjectDto> gameObjectsDtos = gameObjects.Select(it => new GameObjectDto
        {
            Transform = new TransformDto()
            {
                Position = it.Transform.Position,
                Rotation = it.Transform.Rotation,
                Scale = it.Transform.Scale
            }
        }).ToArray();

        return Task.FromResult(gameObjectsDtos);
    }

   
}