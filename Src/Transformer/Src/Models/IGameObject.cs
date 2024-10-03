namespace Transformer.Model;

/// <summary>
/// Represents a game object with a name and transform properties.
/// </summary>
public interface IGameObject
{
    /// <summary>
    /// Gets or sets the name of the game object.
    /// </summary>
    string Name { get; set; }

    /// <summary>
    /// Gets or sets the transformation properties of the game object, including position, rotation, and scale.
    /// </summary>
    ITransform Transform { get; set; }
}