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

        public InstanceData( dynamic instance )
        {
            // RGBA format
            Colour = new Vector4(
                instance.PermutationData.PrimaryColor.R / 255f,
                instance.PermutationData.PrimaryColor.G / 255f,
                instance.PermutationData.PrimaryColor.B / 255f,
                1.0f );
            worldMatrix = ScenarioExtensions.CreateWorldMatrix( instance.ObjectData );
        }
    }
}