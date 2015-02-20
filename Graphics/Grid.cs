using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Moonfish.Graphics
{
    class Grid : IDisposable
    {
        protected int array_buffer_id;
        protected int index_buffer_id;
        protected int vertex_array_buffer_id;

        protected Vector3[] Vertices;
        protected ushort[] Indices;

        public virtual Vector3[] GenerateUnitCoordinates(int count)
        {

            // initialize vertices array
            Vector3[] vertices = new Vector3[count * 2];

            // invariant: we have processed i vertices thus far
            int k = 0;
            for (int i = 0; i != count; ++i)
            {
                int unit = i % count;

                // map 'unit' to the range [0.0 .. 1.0]
                float a = (float)unit / (count - 1);

                // assign calculated position
                vertices[k++] = new Vector3(a, 0, 0);
                vertices[k++] = new Vector3(a, 1, 0);
            }
            return vertices;
        }

        public Grid() : this(new Vector3(-1.0f, -1.0f, 0.0f), new Vector2(2.0f, 2.0f), 10, 10) { }
        public Grid(Vector3 origin, Vector2 size, int x_cell_count, int y_cell_count)
        {
            #region Generate Vertices

            // initialize our vertex count for height (h) and width (w)
            int w = x_cell_count + 1;
            int h = y_cell_count + 1;

            // total number of vertices
            int count = 2 * (w + h);

            // initialize vertices array
            Vertices = new Vector3[count];
            var column_vertices = GenerateUnitCoordinates(w);
            var row_vertices = GenerateUnitCoordinates(h).Select(x => x.Yxz).ToArray<Vector3>();
            Array.Copy(column_vertices, Vertices, 2 * w);
            Array.Copy(row_vertices, 0, Vertices, 2 * w, 2 * h);

            // scale the unit coordinates to size and move origin
            for (int i = 0; i < Vertices.Length; ++i)
            {
                var s = new Vector3(size);
                var v = Vertices[i];
                Vector3.Multiply(ref v, ref s, out v);
                Vector3.Add(ref v, ref origin, out v);
                Vertices[i] = v;
            }

            #endregion
            #region Generate Line Indices

            int line_count = w + h;

            // index_count = (2) indices per line
            int index_count = 2 * line_count;

            Indices = new ushort[index_count];

            int j = 0;
            for (ushort i = 0; i != index_count; ++i)
            {
                Indices[j++] = i;
            }

            #endregion

            GenerateOpenGLBuffers();
        }

        private void GenerateOpenGLBuffers()
        {
            
            // generate buffers
            vertex_array_buffer_id = GL.GenVertexArray();
            OpenGL.ReportError();
            array_buffer_id = GL.GenBuffer();
            OpenGL.ReportError();
            index_buffer_id = GL.GenBuffer();
            OpenGL.ReportError();

            // bind VAO
            GL.BindVertexArray(vertex_array_buffer_id);
            OpenGL.ReportError();

            // bind and buffer array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, array_buffer_id);
            OpenGL.ReportError();
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(this.Vertices.Length * 12), this.Vertices, BufferUsageHint.StaticDraw);
            OpenGL.ReportError();

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            // bind and buffer element array
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, index_buffer_id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(ushort) * this.Indices.Length), this.Indices, BufferUsageHint.StaticDraw);

            GL.EnableVertexAttribArray(0);

            // unbind buffers
            GL.BindVertexArray(0);
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        }

        public void Draw()
        {
            GL.BindVertexArray(vertex_array_buffer_id);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, index_buffer_id);
            GL.DrawElements(PrimitiveType.Lines, Indices.Length, DrawElementsType.UnsignedShort, IntPtr.Zero);
            GL.BindVertexArray(0);
        }

        void IDisposable.Dispose()
        {
            GL.DeleteVertexArray(vertex_array_buffer_id);
            GL.DeleteBuffer(array_buffer_id);
            GL.DeleteBuffer(index_buffer_id);
        }
    }

    class CoordinateGrid : Grid
    {
        Vector3[] DiffuseColours;


        public CoordinateGrid()
            : base(new Vector3(-4, -4, 0), new Vector2(8, 8), 16, 16)
        {
            // generate diffuse colours
            int count = 2 * (17 + 17);
            DiffuseColours = new Vector3[count];
            for (int i = 0; i < count; ++i)
            {
                DiffuseColours[i] = new Vector3(0.22f, 0.22f, 0.22f);
            }
            DiffuseColours[50] = new Vector3(132f / 255f, 32f / 255f, 32f / 255f);
            DiffuseColours[51] = new Vector3(132f / 255f, 32f / 255f, 32f / 255f);
            DiffuseColours[16] = new Vector3(22f / 255f, 132f / 255f, 22f / 255f);
            DiffuseColours[17] = new Vector3(22f / 255f, 132f / 255f, 22f / 255f);

            GenerateOpenGLBuffers();
        }

        private void GenerateOpenGLBuffers()
        {
            // generate buffers
            base.vertex_array_buffer_id = GL.GenVertexArray();
            base.array_buffer_id = GL.GenBuffer();
            base.index_buffer_id = GL.GenBuffer();

            // bind VAO
            GL.BindVertexArray(vertex_array_buffer_id);

            // bind and buffer array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, array_buffer_id);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(base.Vertices.Length * 12 + DiffuseColours.Length * 12), (IntPtr)null, BufferUsageHint.StaticDraw);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)0, (IntPtr)(12 * base.Vertices.Length), base.Vertices);
            GL.BufferSubData(BufferTarget.ArrayBuffer, (IntPtr)(12 * base.Vertices.Length), (IntPtr)(12 * DiffuseColours.Length), DiffuseColours);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 12, 0);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 12, base.Vertices.Length * 12);

            GL.EnableVertexAttribArray(0);
            GL.EnableVertexAttribArray(1);

            // bind and buffer element array
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, index_buffer_id);
            GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(sizeof(ushort) * base.Indices.Length), base.Indices, BufferUsageHint.StaticDraw);

            // unbind buffers
            GL.BindVertexArray(0);
            OpenGL.ReportError();
        }

        public void Draw()
        {
            GL.BindVertexArray(vertex_array_buffer_id);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, index_buffer_id);
            GL.DrawElements(PrimitiveType.Lines, Indices.Length, DrawElementsType.UnsignedShort, (IntPtr)0);
            GL.BindVertexArray(0);
        }
    }
}
