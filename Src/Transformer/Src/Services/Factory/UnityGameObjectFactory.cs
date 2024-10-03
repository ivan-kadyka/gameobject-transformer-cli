using Transformer.Model;
using Transform = UnityEngine.Transform;

namespace Transformer.Generator;

// Simplified prototype implementation
public class UnityGameObjectFactory : IGameObjectFactory
{
    public IGameObject Create(GameObjectDto dto)
    {
        UnityEngine.GameObject unityGameObject = new UnityEngine.GameObject();
        
        // Transform is always added to the GameObject that is being created. 
        var transformComponent = unityGameObject.GetComponent<Transform>();

        transformComponent.position = dto.Transform.Position;
        transformComponent.rotation = dto.Transform.Rotation;
        transformComponent.localScale = dto.Transform.Scale;
        
        return new UnityGameObject(unityGameObject);
    }
}