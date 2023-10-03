using Godot;
using Scripts.Configs;
using System;

public partial class CameraFacade : Camera3D
{

	[Export]
	private Player _player;
	[Export]
	private float _speed = 0.001f;
	private CameraMovement _cameraMovement;
	private Timer _timer;
	private Node3D _cameraDefaultPosition;
	private MainConfigs _mainConfigs;

	public override void _Ready()
	{
		_timer = GetNode("Timer") as Timer;
		_cameraDefaultPosition = GetNode("CameraDefaultPos") as Node3D;
		_cameraMovement = new CameraMovement(this, _speed, _timer, _cameraDefaultPosition);
		_mainConfigs = new MainConfigs();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public override void _Input(InputEvent e)
	{
		_cameraMovement.HandleCameraMovement(e);
		_mainConfigs.ChangeMouseModeOnKeyPressed(e);
	}
}
