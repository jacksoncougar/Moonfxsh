using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public static class MoonGL
    {
        public static void VertexAttribArray( int index, int bindingIndex, int count, VertexAttribType type,
            bool normalised = false, int offset = 0, int divisor = 0 )
        {
            GL.VertexAttribFormat( index, count, type, normalised, offset );
            GL.VertexAttribBinding( index, bindingIndex );
            GL.VertexBindingDivisor(index, divisor);
            GL.EnableVertexAttribArray( index );
        }
    }
}