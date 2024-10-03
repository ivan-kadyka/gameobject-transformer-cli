using Transformer.Model;
using Transform = UnityEngine.Transform;

namespace Transformer.Generator;

public class UnityGameObjectFactory : IGameObjectFactory
{
    public IGameObject Create(GameObjectDto dto)
    {
        UnityEngine.GameObject unityGameObject = new UnityEngine.GameObject();
        
        var transformComponent = unityGameObject.GetComponent<Transform>();

        transformComponent.position = dto.Transform.Position;
        transformComponent.rotation = dto.Transform.Rotation;
        transformComponent.localScale = dto.Transform.Scale;
        
        return new UnityGameObject(unityGameObject);
    }
}