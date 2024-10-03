using Transformer.Model;

namespace Transformer.Generator;

/// <summary>
/// Provides functionality for creating game objects from data transfer objects (DTOs).
/// </summary>
public interface IGameObjectFactory
{
     /// <summary>
     /// Creates a new game object based on the provided game object data transfer object.
     /// </summary>
     /// <param name="dto">The game object data transfer object used to create a new game object.</param>
     /// <returns>A new instance of <see cref="IGameObject"/>.</returns>
     IGameObject Create(GameObjectDto dto);
}