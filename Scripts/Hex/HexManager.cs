using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class HexManager : Node3D
{
	List<Node3D> allHexes = new List<Node3D>();
	public override void _Ready()
	{
		this.GetChildren().ToList().ForEach(el =>
		{
			el.GetChildren().ToList().ForEach(e =>
			{
				allHexes.Add(e as Node3D);
			});
		});
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
