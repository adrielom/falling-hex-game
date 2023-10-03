using System.Collections.Generic;
using Godot;

namespace Hex
{

    public interface IFloorBuilder
    {
        void Build(Node3D entry);
    }

    public class HexFloorBuilder : IFloorBuilder
    {
        private const string NEIGHBOURS_POSITIONS = "NeighbourPositions";
        List<Node3D> _floor;
        PackedScene _scene;
        Node3D _parent;
        int _size;
        public static IFloorBuilder hexFloorBuiler;

        public HexFloorBuilder(List<Node3D> floor, PackedScene scene, Node3D parent, int size = 4)
        {
            Floor = floor;
            _scene = scene;
            _parent = parent;
            _size = size;
            if (hexFloorBuiler == null) hexFloorBuiler = this;
        }

        public List<Node3D> Floor { get => _floor; set => _floor = value; }

        public void Build(Node3D entry = null)
        {
            Node3D instance = entry;
            Label3D label = null;
            if (instance == null)
            {
                instance = (Node3D)_scene.Instantiate();
                Floor.Add(instance);
                instance.Position = Vector3.Zero;
                _parent.AddChild(instance);
                instance.PrintTree();

                label = instance.GetNode("positionLabel") as Label3D;
                label.Text = $"{instance.Position.X} {instance.Position.Y} {instance.Position.Z}";

            }
            GD.Print("oi");
            Node3D neighbourPositionParent = instance.GetNode(NEIGHBOURS_POSITIONS) as Node3D;

            GD.Print(neighbourPositionParent);
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < neighbourPositionParent.GetChildCount(); j++)
                {
                    instance = (Node3D)_scene.Instantiate();
                    Floor.Add(instance);
                    instance.Position = (neighbourPositionParent.GetChild(j) as Node3D).Position * i;
                    label = instance.GetNode("positionLabel") as Label3D;
                    label.Text = $"{instance.Position.X} {instance.Position.Y} {instance.Position.Z}";
                    _parent.AddChild(instance);
                }
            }
        }


    }
}