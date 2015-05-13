using OpenTK;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioNetgameEquipmentBlock
    {
        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation(this.Position);
                var rotationXMatrix = Matrix4.CreateRotationX(this.Orientation.Orientation.Z);
                var rotationYMatrix = Matrix4.CreateRotationY(-this.Orientation.Orientation.Y);
                var rotationZMatrix = Matrix4.CreateRotationZ(this.Orientation.Orientation.X);
                var rotationMatrix = rotationZMatrix*rotationYMatrix*rotationXMatrix;
                return Matrix4.CreateScale(1)*rotationMatrix*translationMatrix;
            }
        }
    };
}