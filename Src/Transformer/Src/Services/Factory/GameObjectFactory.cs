using Transformer.Model;

namespace Transformer.Generator;

public class GameObjectFactory : IGameObjectFactory
{
    public IGameObject Create(GameObjectDto dto)
    {
        var gameObject = new GameObject(dto);
        
        return gameObject;
    }
}