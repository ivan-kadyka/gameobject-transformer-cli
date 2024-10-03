namespace Transformer.Model;

public class UnityGameObject : IGameObject
{
    private readonly UnityEngine.GameObject _gameObject;

    public string Name
    {
        get => _gameObject.name;
        set => _gameObject.name = value;
    }

    public UnityGameObject(UnityEngine.GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public ITransform Transform { get; set; }
}