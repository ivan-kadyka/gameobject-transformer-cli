namespace Transformer.Model;

public interface IGameObject
{
    string Name { get; set; }
    
    ITransform Transform { get; set; }
}