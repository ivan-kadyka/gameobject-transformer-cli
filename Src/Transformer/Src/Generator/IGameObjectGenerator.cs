using Transformer.Model;

namespace Transformer.Generator;

public interface IGameObjectGenerator
{
    Task<IReadOnlyCollection<GameObject>> Generate(GameObjectDto[] dtos, CancellationToken token = default);
}