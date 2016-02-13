using Moonfish.Guerilla.Tags;
using OpenTK;

namespace Moonfish.Graphics
{
    public static class ScenarioExtensions
    {
        /// <summary>
        ///     Creates a WorldMatrix from the transforms in the ScenarioObjectDatumStructBlock
        /// </summary>
        /// <param name="objectData">ScenarioObjectDatumStructBlock to create WorldMatrix from</param>
        /// <returns></returns>
        public static Matrix4 CreateWorldMatrix( this ScenarioObjectDatumStructBlock objectData )
        {
            var translationMatrix = Matrix4.CreateTranslation( objectData.Position );
            var rotationXMatrix = Matrix4.CreateRotationX( objectData.Rotation.Z );
            var rotationYMatrix = Matrix4.CreateRotationY( -objectData.Rotation.Y );
            var rotationZMatrix = Matrix4.CreateRotationZ( objectData.Rotation.X );
            var scaleMatrix = Matrix4.CreateScale( objectData.Scale.NearlyEqual( 0 ) ? 1 : objectData.Scale );
            return rotationZMatrix * rotationYMatrix * rotationXMatrix * translationMatrix * scaleMatrix;
        }
    }
}