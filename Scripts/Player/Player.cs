using Godot;

public partial class Player : CharacterBody3D
{
	// How fast the player moves in meters per second.
	[Export]
	public float Speed { get; set; } = 14;
	// The downward acceleration when in the air, in meters per second squared.
	[Export]
	public float FallAcceleration { get; set; } = 9.8f;

	private Vector3 _targetVelocity = Vector3.Zero;
	private Node3D pivot;

	public override void _Ready()
	{
		pivot = GetNode<Node3D>("Pivot");
	}


	public override void _PhysicsProcess(double delta)
	{
		if (!IsOnFloor())
		{
			GD.Print("here");
			Velocity -= new Vector3(Velocity.X, FallAcceleration * (float)delta, Velocity.Z);
		}

		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			Velocity = new Vector3(Velocity.X, Speed, Velocity.Z);
		}

		var verticalDir = Input.GetAxis("ui_down", "ui_up");
		var horizontalDir = Input.GetAxis("ui_left", "ui_right");
		var direction = (Transform.Basis * new Vector3(-horizontalDir, 0, verticalDir)).Normalized();
		if (direction != Vector3.Zero)
		{
			Velocity = new Vector3(direction.X * Speed, 0, direction.Z * Speed);
		}
		else
		{

			Velocity = Vector3.Zero;
		}

		MoveAndSlide();

	}
}