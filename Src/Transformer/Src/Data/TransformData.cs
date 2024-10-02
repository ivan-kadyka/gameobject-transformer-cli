using UnityEngine;

namespace Transformer.Data;

public class TransformData
{
    public string Name { get; set; }
    public Vector3 Position { get; set; }

    public TransformData(string name, Vector3 position)
    {
        Name = name;
        Position = position;
    }
}