using OpenTK;

namespace Moonfish.Graphics
{
    /// <summary>
    ///     Contains instance data ( colour, orientation, etc )
    /// </summary>
    public struct InstanceData
    {
        private Vector4 Colour;
        public Matrix4 worldMatrix;

        public InstanceData( dynamic instance, bool supportsPermutations )
        {
            if ( supportsPermutations )
            {
                // RGBA format
                Colour = new Vector4(
                    instance.PermutationData.PrimaryColor.R / 255f,
                    instance.PermutationData.PrimaryColor.G / 255f,
                    instance.PermutationData.PrimaryColor.B / 255f,
                    1.0f );
            }
            else Colour = Vector4.Zero;

           worldMatrix = ScenarioExtensions.CreateWorldMatrix( instance.ObjectData );
        }
    }
}