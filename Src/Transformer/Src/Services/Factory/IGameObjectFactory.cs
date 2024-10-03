using Transformer.Model;

namespace Transformer.Generator;

public interface IGameObjectFactory
{
     IGameObject Create(GameObjectDto dto);
}