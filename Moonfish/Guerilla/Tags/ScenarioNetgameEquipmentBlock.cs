using OpenTK;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioNetgameEquipmentBlock : IH2ObjectPalette
    {
        public Matrix4 WorldMatrix
        {
            get
            {
                var translationMatrix = Matrix4.CreateTranslation(Position);
                var rotationXMatrix = Matrix4.CreateRotationX(Orientation.Orientation.Z);
                var rotationYMatrix = Matrix4.CreateRotationY(-Orientation.Orientation.Y);
                var rotationZMatrix = Matrix4.CreateRotationZ(Orientation.Orientation.X);
                var rotationMatrix = rotationZMatrix*rotationYMatrix*rotationXMatrix;
                return Matrix4.CreateScale(1)*rotationMatrix*translationMatrix;
            }
        }

        Moonfish.Tags.TagReference IH2ObjectPalette.ObjectReference
        {
            get { return ItemVehicleCollection; }
        }
    };
}