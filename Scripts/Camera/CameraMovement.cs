using Godot;
using System;

public class CameraMovement
{
    private Camera3D _camera;
    private Node3D _player;

    public CameraMovement(Camera3D camera, Node3D player)
    {
        _camera = camera;
        _player = player;
    }

    public void HandleCameraMovement(InputEvent inputEventMouse)
    {
        if (inputEventMouse is InputEventMouseMotion eventMouseMotion)
        {
            GD.Print("Mouse Motion at: ", eventMouseMotion.Position);
            Node3D cameraParent = (Node3D)_camera.GetParent();
            // cameraParent.LookAt(_player.Position);
            // float changeV = -eventMouseMotion.Relative.Y * mouseSens;
            // if (cameraAngle + changeV > -50 && cameraAngle + changeV < 50)
            // {
            //     cameraAngle += changeV;
            //     _camera.RotateX(Mathf.DegToRad(changeV));
            // }
        }

        // if event is InputEventMouseMotion:
        //     $Camera.rotate_y(deg2rad(-event.relative.x*mouse_sens))
        //     var changev=-event.relative.y*mouse_sens
        //     if camera_anglev+changev>-50 and camera_anglev+changev<50:
        //         camera_anglev+=changev
        //         $Camera.rotate_x(deg2rad(changev))
    }
}
