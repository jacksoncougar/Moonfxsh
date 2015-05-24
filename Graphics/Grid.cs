using System;
using System.Linq;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    internal class Grid : IDisposable
    {
        protected int ArrayBufferId;
        protected int IndexBufferId;
        protected ushort[] Indices;
        protected int VertexArrayBufferId;
        protected Vector3[] Vertices;

        public Grid() : this(new Vector3(-1.0f, -1.0f, 0.0f), new Vector2(2.0f, 2.0f), 10, 10)
        {
        }

        public Grid(Vector3 origin, Vector2 size, int xCellCount, int yCellCount)
        {
            #region Generate Vertices

            // initialize our vertex count for height (h) and width (w)
            var w = xCellCount + 1;
            var h = yCellCount + 1;

            // total number of vertices
            var count = 2*(w + h);

            // initialize vertices array
            Vertices = new Vector3[count];
            var columnVertices = GenerateUnitCoordinates(w);
            var rowVertices = GenerateUnitCoordinates(h).Select(x => x.Yxz).ToArray();
            Array.Copy(columnVertices, Vertices, 2*w);
            Array.Copy(rowVertices, 0, Vertices, 2*w, 2*h);

            // scale the unit coordinates to size and move origin
            for (var i = 0; i < Vertices.Length; ++i)
            {
                var s = new Vector3(size);
                var v = Vertices[i];
                Vector3.Multiply(ref v, ref s, out v);
                Vector3.Add(ref v, ref origin, out v);
                Vertices[i] = v;
            }

            #endregion

            #region Generate Line Indices

            var lineCount = w + h;

            // index_count = (2) indices per line
            var indexCount = 2*lineCount;

            Indices = new ushort[indexCount];

            var j = 0;
            for (ushort i = 0; i != indexCount; ++i)
            {
                Indices[j++] = i;
            }

            #endregion

            GenerateOpenGlBuffers();
        }

        void IDisposable.Dispose()
        {
            GL.DeleteVertexArray(VertexArrayBufferId);
            GL.DeleteBuffer(ArrayBufferId);
            GL.DeleteBuffer(IndexBufferId);
        }

        public Vector3[] GenerateUnitCoordinates(int count)
        {
            // initialize vertices array
            var vertices = new Vector3[count*2];

            // invariant: we have processed i vertices thus far
            var k = 0;
            for (var i = 0; i != count; ++i)
            {
                var unit = i%count;

                // map 'unit' to the range [0.0 .. 1.0]
                var a = (float) unit/(count - 1);

                // assign calculated position
                vertices[k++] = new Vector3(a, 0, 0);
                vertices[k++] = new Vector3(a, 1, 0);
            }
            return vertices;
        }

        private void GenerateOpenGlBuffers()
        {
            // generate buffers
            VertexArrayBufferId = GL.GenVertexArray();
            ArrayBufferId = GL.GenBuffer();
            IndexBufferId = GL.GenBuffer();

            // bind VAO
            GL.BindVertexArray(VertexArrayBufferId);

            // bind and buffer array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, ArrayBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr) (Vertices.Length*12), Vertices,
                BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            // bind and buffer element array
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferId);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (sizeof (ushort)*Indices.Length), Indices,
                BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);

            // unbind buffers
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public virtual void Draw()
        {
            GL.BindVertexArray(VertexArrayBufferId);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferId);
            GL.DrawElements(PrimitiveType.Lines, Indices.Length, DrawElementsType.UnsignedShort, IntPtr.Zero);
            GL.BindVertexArray(0);
        }
    }

    internal class CoordinateGrid : Grid
    {
        private readonly Vector3[] _diffuseColours;

        public CoordinateGrid(int width, int height)
            : base(new Vector3(-width/2.0f, -height/2.0f, 0), new Vector2(width, height), 16, 16)
        {
            // generate diffuse colours
            const int count = 2*(17 + 17);
            _diffuseColours = new Vector3[count];
            for (var i = 0; i < count; ++i)
            {
                _diffuseColours[i] = new Vector3(0.22f, 0.22f, 0.22f);
            }
            _diffuseColours[50] = new Vector3(132f/255f, 32f/255f, 32f/255f);
            _diffuseColours[51] = new Vector3(132f/255f, 32f/255f, 32f/255f);
            _diffuseColours[16] = new Vector3(22f/255f, 132f/255f, 22f/255f);
            _diffuseColours[17] = new Vector3(22f/255f, 132f/255f, 22f/255f);

            GenerateOpenGlBuffers();
        }

        public CoordinateGrid()
            : this(8, 8)
        {
        }

        private void GenerateOpenGlBuffers()
        {
            // generate buffers
            VertexArrayBufferId = GL.GenVertexArray();
            ArrayBufferId = GL.GenBuffer();
            IndexBufferId = GL.GenBuffer();

            // bind VAO
            GL.BindVertexArray(VertexArrayBufferId);

            // bind and buffer array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, ArrayBufferId);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr) (Vertices.Length*12 + _diffuseColours.Length*12),
                (IntPtr) null, BufferUsageHint.StaticDraw);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr) 0, (IntPtr) (12*Vertices.Length), Vertices);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr) (12*Vertices.Length),
                (IntPtr) (12*_diffuseColours.Length), _diffuseColours);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 12, 0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 12, Vertices.Length*12);

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            // bind and buffer element array
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferId);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr) (sizeof (ushort)*Indices.Length), Indices,
                BufferUsageHint.StaticDraw);

            // unbind buffers
            GL.BindVertexArray(0);
        }

        public override void Draw()
        {
            GL.BindVertexArray(VertexArrayBufferId);
            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, index_buffer_id);
            GL.DrawElements(PrimitiveType.Lines, Indices.Length, DrawElementsType.UnsignedShort, (IntPtr) 0);
            GL.BindVertexArray(0);
        }
    }
}