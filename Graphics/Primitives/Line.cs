using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.Primitives
{
    internal class Line : TriangleBatch
    {
        public Line( Vector3 start, Vector3 end )
        {
            using ( Begin( ) )
            {
                BindBuffer( BufferTarget.ArrayBuffer, GenerateBuffer( ) );
                VertexAttribArray( 0, 3, VertexAttribPointerType.Float );
                BufferVertexAttributeData( new[] {start, end} );
                BindBuffer( BufferTarget.ElementArrayBuffer, GenerateBuffer( ) );
                BufferElementArrayData( new short[] {0, 1} );
            }
        }
    }
}