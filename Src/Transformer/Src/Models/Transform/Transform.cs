using UnityEngine;

namespace Transformer.Model;

public class Transform : ITransform
{
    public Vector3 Position
    {
        get => _position;
        set => _position = value;
    }

    public Quaternion Rotation
    {
        get => _rotation;
        set => _rotation = value;
    }

    public Vector3 Scale
    {
        get => _scale;
        set => _scale = value;
    }
    
    private Vector3 _position = Vector3.zero;
    private Quaternion _rotation = Quaternion.identity;
    private Vector3 _scale = Vector3.one;
}