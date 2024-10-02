using Transformer.Model;

namespace Transformer;

public class GameObjectTransformer : IGameObjectTransformer
{
    public GameObjectTransformer()
    {
      
    }

    public Task Execute()
    {
        GameObject gameObject = new GameObject(new Transform());
        
        return Task.CompletedTask;
    }
}