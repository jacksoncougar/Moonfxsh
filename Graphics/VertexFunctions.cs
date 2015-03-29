using OpenTK;

namespace Moonfish.Graphics
{
    public static class VertexFunctions
    {
        private static Vector3 UnpackVectorInt(int packedVector)
        {
            var xComponent = (packedVector & 0x7ff);
            if ((xComponent & 0x400) == 0x400)
            {
                xComponent = -(~xComponent & 0x3ff);
            }
            var yComponent = (packedVector >> 11) & 0x7FF;
            if ((yComponent & 0x400) == 0x400)
            {
                yComponent = -(~yComponent & 0x3FF);
            }
            var zComponent = (packedVector >> 22) & 0x3FF;
            if ((zComponent & 0x200) == 0x200)
            {
                zComponent = -(~zComponent & 0x1FF);
            }

            var x = xComponent / 1023.0f;
            var y = yComponent / 1023.0f;
            var z = zComponent / 511.0f;

            return new Vector3(x, y, z);
        }
    }
}