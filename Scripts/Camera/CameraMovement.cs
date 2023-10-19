using Camera;
using Godot;
using System;

public class CameraMovement
{
    private Player _player;
    private float _speed;
    private Node3D _cameraDefaultPosition;
    float _rotationX = 0, _rotationY = 0;
    private Camera3D _camera;

    public CameraMovement(Player player, float speed, Node3D cameraDefaultPosition, Camera3D camera)
    {
        _player = player;
        _speed = speed;
        _cameraDefaultPosition = cameraDefaultPosition;
        _camera = camera;
    }

    public void HandleCameraMovement(InputEvent inputEventMouse)
    {
        Node3D parent = _camera.GetParent() as Node3D;
        Vector3 parentPosition = parent.Position;
        if (inputEventMouse is InputEventMouseMotion eventMouseMotion)
        {

            parent.RotateObjectLocal(Vector3.Up, eventMouseMotion.Relative.X * _speed);

            _rotationX += -eventMouseMotion.Relative.X * _speed;
            _rotationY += _rotationY * _speed;

            // reset rotation
            Transform3D transform = new()
            {
                Basis = Basis.Identity
            };
            parent.Transform = transform;

            parent.RotateObjectLocal(Vector3.Up, _rotationX); // first rotate about Y
            parent.RotateObjectLocal(Vector3.Right, _rotationY); // then rotate about X
            parent.Position = parentPosition;
        }
    }


}
