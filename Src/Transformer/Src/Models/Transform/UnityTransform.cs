using UnityEngine;

namespace Transformer.Model;

public class UnityTransform : ITransform
{
    public Vector3 Position
    {
        get => _transform.position;
        set => _transform.position = value;
    }

    public Quaternion Rotation
    {
        get => _transform.rotation;
        set => _transform.rotation = value;
    }

    public Vector3 Scale
    {
        get => _transform.localScale;
        set => _transform.localScale = value;
    }

    private readonly UnityEngine.Transform _transform;
    
    public UnityTransform(UnityEngine.Transform transform)
    {
        _transform = transform;
    }
}