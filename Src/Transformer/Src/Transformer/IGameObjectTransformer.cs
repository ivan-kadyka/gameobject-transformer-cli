namespace Transformer;

public interface IGameObjectTransformer
{
    Task Convert(string input, string output, CancellationToken token = default);
}