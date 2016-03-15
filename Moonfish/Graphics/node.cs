using OpenTK;

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
                var T = Matrix4.CreateTranslation(Position);
                var R = Matrix4.CreateFromQuaternion(Rotation);
                var S = Matrix4.CreateScale(Scale);

                return S * R * T;
            }
        }
    }
}