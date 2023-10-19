using System.Collections.Generic;
using System.Linq;
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
        float _offset = 4f;
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
            int id = 0;
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
            Node3D neighbourPositionParent = instance.GetNode(NEIGHBOURS_POSITIONS) as Node3D;
            GD.Print(instance.Name);

            for (int i = 1; i < _size; i++)
            {
                for (int j = 0; j < neighbourPositionParent.GetChildCount(); j++)
                {
                    Vector3 offsetRingPos = Vector3.Zero;
                    if (i % 2 == 0)
                    {
                        // offsetRingPos = Vector3.One * 1.5f;
                        // offsetRingPos.Y = 0;
                    }
                    Vector3 neighbourPos = (neighbourPositionParent.GetChild(j) as Node3D).Position;
                    Vector3 targetPos = neighbourPos * i * _offset;

                    // if (Floor.Find(el => el.Position == targetPos) != null) break;

                    instance = (Node3D)_scene.Instantiate();
                    instance.Position = targetPos;
                    Floor.Add(instance);
                    label = instance.GetNode("positionLabel") as Label3D;
                    label.Text = $"ID = {id} {instance.Position.X} {instance.Position.Y} {instance.Position.Z}";
                    _parent.AddChild(instance);
                }
            }
        }


    }
}