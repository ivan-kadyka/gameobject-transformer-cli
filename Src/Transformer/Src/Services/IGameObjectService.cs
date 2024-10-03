using Transformer.Model;

namespace Transformer;

public interface IGameObjectService
{
    Task Transform(string input, string output, CancellationToken token = default);
    
    Task<IReadOnlyCollection<GameObjectDto>> Transform(IReadOnlyCollection<GameObjectDto> gameObjectDtos, CancellationToken token = default);
}