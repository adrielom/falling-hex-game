using Godot;
using System;

public partial class CameraFacade : Camera3D
{
	[Export]
	private Player player;
	private CameraMovement _cameraMovement;

	public override void _Ready()
	{
		_cameraMovement = new CameraMovement(this, player);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public override void _Input(InputEvent e)
	{
		_cameraMovement.HandleCameraMovement(e);
	}
}
