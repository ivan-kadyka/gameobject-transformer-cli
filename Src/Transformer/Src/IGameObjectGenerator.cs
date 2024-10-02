namespace Transformer;

public interface IGameObjectGenerator
{
    Task Convert(string filePath, CancellationToken token = default);
}