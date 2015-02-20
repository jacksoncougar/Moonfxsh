using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    public class Node
    {
        public Node()
        {
            Position = Vector3.Zero;
            Rotation = Quaternion.Identity;
            Scale = 1.0f;
        }

        public virtual Vector3 Position { get; set; }
        public virtual Quaternion Rotation { get; set; }
        public virtual float Scale { get; set; }

        public virtual Matrix4 WorldMatrix
        {
            get
            {
                var translation_matrix = Matrix4.CreateTranslation(Position);
                var rotation_matrix = Matrix4.CreateFromQuaternion(Rotation);
                var scale_matrix = Matrix4.CreateScale(Scale);

                return translation_matrix * rotation_matrix * scale_matrix;
            }
        }
    }
}
