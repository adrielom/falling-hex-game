using Camera;
using Godot;

public partial class Player : CharacterBody3D
{
	// How fast the player moves in meters per second.
	[Export]
	public float Speed { get; set; } = 4;
	// The downward acceleration when in the air, in meters per second squared.
	[Export]
	public float FallAcceleration { get; set; } = 240f;
	[Export]
	private Camera3D camera;
	private Vector3 _targetVelocity = Vector3.Zero;
	private Node3D pivot;
	private CameraLockHeight cameraLock;
	[Export]
	private float jumpSpeed;
	private Vector3 initialPosition = new();

	public override void _Ready()
	{
		pivot = GetNode<Node3D>("Pivot");
		cameraLock = new CameraLockHeight(camera, this);
	}


	public override void _PhysicsProcess(double delta)
	{
		Movement((float)delta);
	}

	private void SetVelocity(Vector3 vel)
	{
		initialPosition = Position;
		Velocity = vel;
		MoveAndSlide();
		var distance = Position.DistanceTo(initialPosition);
	}

	public void Movement(float delta)
	{
		Vector3 velocity = new Vector3();
		if (!IsOnFloor())
		{
			velocity.Y = -FallAcceleration * delta * 10;
		}
		var verticalDir = Input.GetAxis("ui_down", "ui_up");
		var horizontalDir = Input.GetAxis("ui_left", "ui_right");
		var direction = (Transform.Basis * new Vector3(-horizontalDir, velocity.Y, verticalDir)).Normalized();
		if (direction != Vector3.Zero)
		{
			velocity = new Vector3(direction.X * Speed, velocity.Y, direction.Z * Speed) * delta;
		}
		else
		{

			velocity = Vector3.Zero;
		}
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = Speed * delta * jumpSpeed;
			velocity.X *= Speed * delta;
			velocity.Z *= Speed * delta;
			velocity *= Speed * delta * jumpSpeed;

			// cameraLock.Follow();
		}
		Velocity = velocity;
		SetVelocity(velocity);

	}
}