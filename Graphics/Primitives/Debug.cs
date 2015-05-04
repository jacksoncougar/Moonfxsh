using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics.Primitives
{
    public static class GLDebug
    {
        public static Program DebugProgram { private get; set; }
        public static Program ScreenspaceProgram { private get; set; }

        public static void DrawNormal(this Vector3 normal, float length, Color color)
        {
            DrawLine(normal, normal + normal*length, color, 3.0f);
        }

        public static void DrawLine(Vector3 from, Vector3 to, Color color, float lineWidth)
        {
            DrawLine(ref from, ref to, ref color, lineWidth);
        }

        public static void Draw2DPoint(Vector2 point, Color color, float pointSize = 1.0f)
        {
            var vao = GL.GenVertexArray();
            var arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr) Vector2.SizeInBytes, ref point,
                BufferUsageHint.StreamDraw);
            GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(0);
            var colourAttribute = ScreenspaceProgram.GetAttributeLocation("Colour");
            GL.PointSize(pointSize);
            GL.Enable(EnableCap.VertexProgramPointSize);
            var worldMatrixUniform = ScreenspaceProgram.GetUniformLocation("WorldMatrixUniform");
            using (ScreenspaceProgram.Use())
            {
                ScreenspaceProgram.SetUniform(worldMatrixUniform, Matrix4.Identity);
                Program.SetAttribute(colourAttribute, new ColorF(Color.FromArgb(color.ToArgb())).RGBA);
                GL.DrawArrays(PrimitiveType.Points, 0, 1);
            }
            GL.PointSize(1.0f);
            GL.DeleteBuffer(arrayBuffer);
            GL.DeleteVertexArray(vao);
            OpenGL.ReportError();
        }

        public static void DrawPoint(Vector3 point, Color color, float pointSize)
        {
            var vao = GL.GenVertexArray();
            var arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr) Vector3.SizeInBytes, ref point,
                BufferUsageHint.StreamDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(0);
            GL.PointSize(pointSize);
            var colourAttribute = DebugProgram.GetAttributeLocation("Colour");
            using (DebugProgram.Use())
            {
                Program.SetAttribute(colourAttribute, new ColorF(Color.FromArgb(color.ToArgb())).RGBA);
                GL.DrawArrays(PrimitiveType.Points, 0, 1);
            }
            GL.PointSize(1);
            GL.Finish();
            GL.DeleteBuffer(arrayBuffer);
            GL.DeleteVertexArray(vao);
        }

        public static void Draw2DLine(Vector2 from, Vector2 to, Color color, float lineWidth = 1.0f)
        {
            var line = new Line(new Vector3(from.X, from.Y, 0), new Vector3(to.X, to.Y, 0));
            var colourAttribute = ScreenspaceProgram.GetAttributeLocation("Colour");
            var worldMatrixUniform = ScreenspaceProgram.GetUniformLocation("WorldMatrixUniform");
            using (ScreenspaceProgram.Use())
            {
                ScreenspaceProgram.SetUniform(worldMatrixUniform, Matrix4.Identity);
                GL.BindVertexArray(line.VertexArrayObjectIdent);
                Program.SetAttribute(colourAttribute, new ColorF(Color.FromArgb(color.ToArgb())).RGBA);
                GL.LineWidth(lineWidth);
                GL.DrawArrays(PrimitiveType.Lines, 0, 2);
                GL.LineWidth(1.0f);
            }
            line.Dispose();
        }

        public static void DrawLine(ref Vector3 from, ref Vector3 to, ref Color color, float lineWidth)
        {
            var line = new Line(from, to);
            var colourAttribute = DebugProgram.GetAttributeLocation("Colour");
            var worldMatrixUniform = DebugProgram.GetUniformLocation("WorldMatrixUniform");
            using (DebugProgram.Use())
            {
                GL.BindVertexArray(line.VertexArrayObjectIdent);
                Program.SetAttribute(colourAttribute, new ColorF(Color.FromArgb(color.ToArgb())).RGBA);
                DebugProgram.SetUniform(worldMatrixUniform, Matrix4.Identity);
                GL.LineWidth(lineWidth);
                GL.DrawArrays(PrimitiveType.Lines, 0, 2);
                GL.Finish();
                GL.LineWidth(1.0f);
            }
            line.Dispose();
        }
    }
}