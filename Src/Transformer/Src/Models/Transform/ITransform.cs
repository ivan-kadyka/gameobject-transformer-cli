using UnityEngine;

namespace Transformer.Model;

public interface ITransform
{
    Vector3 Position { get; set; }
    
    Quaternion Rotation { get; set; }
    
    Vector3 Scale { get; set; }
}