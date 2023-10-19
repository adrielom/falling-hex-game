namespace Camera;

using System;
using Godot;

public class CameraLockHeight
{

    private Camera3D _camera;
    private Node3D _target;

    public CameraLockHeight(Camera3D camera, Node3D target)
    {
        this._camera = camera;
        this._target = target;
    }

    public void Follow()
    {
    }

}