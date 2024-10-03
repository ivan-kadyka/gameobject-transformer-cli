namespace Transformer;

public interface IGameObjectService
{
    Task Transform(string input, string output, CancellationToken token = default);
}