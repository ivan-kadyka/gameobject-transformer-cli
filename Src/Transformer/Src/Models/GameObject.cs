namespace Transformer.Model;

public class GameObject : IGameObject
{
    public string Name { get; set; }

    public ITransform Transform
    {
        get => _transform;
        set => _transform = value ?? throw new ArgumentNullException(nameof(value));
    }

    private ITransform _transform;
    
    public GameObject(ITransform transform, string name = "")
    {
        _transform = transform;
        Name = name;
    }

    public GameObject(GameObjectDto dto)
    {
        Name = string.Empty;
        _transform = new Transform(dto.Transform);
    }
}