using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;

namespace Moonfish.Collision
{

    public class Line : IRenderable, IDisposable
    {
        int vao, arrayBuffer;

        public Line( Vector3 start, Vector3 end )
        {
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray( vao );
            GL.BindBuffer( BufferTarget.ArrayBuffer, arrayBuffer );
            var data = new[] { start, end };
            GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr )( Vector3.SizeInBytes * 2 ), data, BufferUsageHint.StaticDraw );

            GL.VertexAttribPointer( 0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero );
            GL.EnableVertexAttribArray( 0 );
        }

        public void Render( IEnumerable<Program> shaderPasses )
        {
            GL.BindVertexArray( vao );
            GL.DrawArrays( PrimitiveType.Lines, 0, 2 );
        }

        public void Render( IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances )
        {
            throw new NotImplementedException();
        }

        public void Dispose( )
        {
            GL.DeleteVertexArray( vao );
            GL.DeleteBuffer( arrayBuffer );
        }
    }


    public class Point : IRenderable, IDisposable
    {
        int vao, arrayBuffer;

        public Point( Vector3 position )
        {
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray( vao );
            GL.BindBuffer( BufferTarget.ArrayBuffer, arrayBuffer );
            GL.BufferData( BufferTarget.ArrayBuffer, ( IntPtr )Vector3.SizeInBytes, ref position, BufferUsageHint.StreamDraw );

            GL.VertexAttribPointer( 0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero );
            GL.EnableVertexAttribArray( 0 );
        }

        public void Render( IEnumerable<Program> shaderPasses )
        {
            GL.BindVertexArray( vao );
            GL.DrawArrays( PrimitiveType.Points, 0, 1 );
        }

        public void Render( IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances )
        {
            throw new NotImplementedException();
        }

        public void Dispose( )
        {
            GL.DeleteVertexArray( vao );
            GL.DeleteBuffer( arrayBuffer );
        }
    }

}
