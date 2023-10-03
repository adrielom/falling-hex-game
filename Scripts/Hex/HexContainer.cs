using Godot;
using Hex;
using System.Collections.Generic;

public partial class HexContainer : Node3D
{
    private List<Node3D> _floor = new();
    [Export]
    private int numberOfRings = 10;
    IFloorBuilder floorBuilder;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PackedScene piece = (PackedScene)ResourceLoader.Load("res://Scenes/hex.tscn");
        floorBuilder = new HexFloorBuilder(_floor, piece, this, numberOfRings);
        floorBuilder.Build(null);

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
