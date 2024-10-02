using Transformer.Model;

namespace Transformer.Generator;

public class GameObjectGenerator : IGameObjectGenerator
{
    public Task<IReadOnlyCollection<GameObject>> Generate(GameObjectDto[] dtos, CancellationToken token = default)
    {
        var gameObjects = dtos.Select(it => new GameObject(it))
            .ToArray();
        
        return Task.FromResult<IReadOnlyCollection<GameObject>>(gameObjects);
    }
}