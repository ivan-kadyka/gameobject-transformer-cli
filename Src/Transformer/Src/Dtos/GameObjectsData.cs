namespace Transformer.Model;

[Serializable]
public class GameObjectsData
{
    public IReadOnlyCollection<GameObjectDto> GameObjects { get; set; }
}