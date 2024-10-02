namespace Transformer.Model;

public class GameObject : IGameObject
{
    public string Name { get; set; }
    public ITransform Transform { get; set; }

    public GameObject(ITransform transform, string name = "")
    {
        Transform = transform;
        Name = name;
    }

    public GameObject()
    {
        Name = string.Empty;
        Transform = new Transform();
    }
}