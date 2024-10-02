using UnityEngine;

namespace Transformer.Model;

[Serializable]
public class TransformDto
{
    public Vector3 Position { get; set; }
    
    public Quaternion Rotation { get; set; }
    
    public Vector3 Scale { get; set; }
}