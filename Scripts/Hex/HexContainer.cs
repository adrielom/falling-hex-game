using Godot;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class HexContainer : Node3D
{
    private List<IHex> _floor;
    [Export]
    private int numberOfRings = 4;

    private void CreateFloor(PackedScene piece, out List<IHex> floor)
    {
        floor = new();
        Node3D instance = (Node3D)piece.Instantiate();
        floor.Add(new Hex(instance));
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        PackedScene piece = (PackedScene)ResourceLoader.Load("res://Scenes/hex.tscn");
        CreateFloor(piece, out _floor);

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
}
