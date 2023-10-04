using Godot;
using System;

public class CameraMovement
{
    private Camera3D _camera;
    private float _speed;
    private Timer _timer;
    private Node3D _cameraDefaultPosition;
    float _rotationX = 0, _rotationY = 0;

    public CameraMovement(Camera3D camera, float speed, Timer timer, Node3D cameraDefaultPosition)
    {
        _camera = camera;
        _speed = speed;
        _timer = timer;
        _cameraDefaultPosition = cameraDefaultPosition;
        _timer.Timeout += OnTimerTimeOutResetPosition;

    }

    public void HandleCameraMovement(InputEvent inputEventMouse)
    {

        Node3D parent = _camera.GetParent() as Node3D;
        Vector3 parentPosition = parent.Position;
        if (inputEventMouse is InputEventMouseMotion eventMouseMotion)
        {

            parent.RotateObjectLocal(Vector3.Up, eventMouseMotion.Relative.X * _speed);
            _timer.Start();

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
            // if (parent.Rotation.Y <= 3 && parent.Rotation.Y > 0)
            parent.Position = parentPosition;
        }
    }

    public void OnTimerTimeOutResetPosition()
    {
        // Tween tween = new();
        // tween.SetTrans(Tween.TransitionType.Sine);
        // tween.SetEase(Tween.EaseType.InOut);
        // tween.TweenProperty(_camera, "rotation", new Vector3(-25f, -180f, 0f), 1f);
        // GD.Print(tween.IsRunning());
    }

}
