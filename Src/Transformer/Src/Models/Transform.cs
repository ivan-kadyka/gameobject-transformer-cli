using UnityEngine;

namespace Transformer.Model;

public class Transform : ITransform
{
    public Vector3 Position { get; set; } = Vector3.zero;
    public Quaternion Rotation { get; set; } = Quaternion.identity;
    public Vector3 Scale { get; set; } = Vector3.one;
}