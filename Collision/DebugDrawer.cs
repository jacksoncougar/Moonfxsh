using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using OpenTK;
using OpenTK.Graphics.ES30;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Moonfish.Collision
{

    public class Line : IRenderable, IDisposable
    {
        int vao, arrayBuffer;

        public Line(Vector3 start, Vector3 end)
        {
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            var data = new []{ start, end };
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(Vector3.SizeInBytes * 2), data , BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(0);
        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Lines, 0, 2);
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(arrayBuffer);
        }
    }

    public class Point : IRenderable, IDisposable
    {
        int vao, arrayBuffer;

        public Point(Vector3 position)
        {
            vao = GL.GenVertexArray();
            arrayBuffer = GL.GenBuffer();

            GL.BindVertexArray(vao);
            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)Vector3.SizeInBytes, ref position, BufferUsageHint.StaticDraw);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(0);
        }

        public void Render(IEnumerable<Program> shaderPasses)
        {
            GL.BindVertexArray(vao);
            GL.DrawArrays(PrimitiveType.Points, 0, 1);
        }

        public void Render(IEnumerable<Program> shaderPasses, IList<IH2ObjectInstance> instances)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GL.DeleteVertexArray(vao);
            GL.DeleteBuffer(arrayBuffer);
        }
    }

    static class DebugDrawer
    {
        public static Program debugProgram;

        public static void DrawBox(ref OpenTK.Vector3 bbMin, ref OpenTK.Vector3 bbMax, ref OpenTK.Matrix4 trans, OpenTK.Graphics.Color4 color)
        {
            //using (debugProgram.Using("object_matrix", trans))
            using (Box box = new Box(bbMin, bbMax))
            {
                GL.VertexAttrib3(1, new[] { 1f, 1f, 1f });
                box.Render(new[] { debugProgram });
            }
        }

        public static void DrawPoint(Vector3 coordinate)
        {
            using(debugProgram.Use())
            using (Point point = new Point(coordinate))
            {
                point.Render(new[] { debugProgram });
            }
        }

        internal static void DrawPoint(Vector3 coordinate, float pointSize)
        {
            DrawPoint(coordinate);
        }

        public static void DrawLine(Vector3 lineStart, Vector3 lineEnd)
        {
            using (debugProgram.Use())
            using (Line line = new Line(lineStart, lineEnd))
            {
                line.Render(new[] { debugProgram });
            }
        }


        public static void DrawPlane(Plane plane)
        {
            var x = Vector3.Dot(plane.Normal, Vector3.UnitZ);
            var axis = plane.Normal;
            if (x != 1)
            {
                axis = Vector3.Cross(plane.Normal, Vector3.UnitZ);
                x = (float)Math.Acos(x);
            }

            var rotation = Matrix4.Identity * Matrix4.CreateFromAxisAngle(axis, x);
            var translation = Matrix4.Identity * Matrix4.CreateTranslation(plane.Normal * plane.Distance);
            var worldMatrix = translation * rotation;
            using (debugProgram.Use())
            {
                var objectMatrixUniform = debugProgram.GetUniformLocation("object_matrix");
                debugProgram.SetUniform(objectMatrixUniform, ref worldMatrix);
                using (Grid grid = new Grid(new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector2(1, 1), 8, 8))
                {
                    grid.Draw();
                }
                debugProgram.SetUniform(objectMatrixUniform, Matrix4.Identity);
            }

        }

        internal static void DrawFrame(Vector3 origin, Quaternion rotation)
        {
            var rotationMatrix = Matrix4.CreateFromQuaternion(rotation);
            var axisUp = Vector3.Transform(Vector3.UnitZ, Quaternion.Identity);
            var axisRight = Vector3.Transform(Vector3.UnitX, Quaternion.Identity);
            var axisForward = Vector3.Transform(Vector3.UnitY, Quaternion.Identity);
            var coordinates = new[] { origin, origin, origin, axisUp, axisRight, axisForward };

            for (var i = 3; i < coordinates.Length; ++i)
            {
                coordinates[i] = Vector3.Transform(coordinates[i], Matrix4.CreateScale(0.1f));
                coordinates[i] += coordinates[0];
            }


            var indices = new short[] { 
                0, 3, 
                1, 4,  
                2, 5};
            var colours = Color.Blue.ToFloatRgb().Concat(Color.Red.ToFloatRgb()).Concat(Color.Green.ToFloatRgb())
                .Concat(Color.Blue.ToFloatRgb()).Concat(Color.Red.ToFloatRgb()).Concat(Color.Green.ToFloatRgb()).ToArray();

            int arrayBuffer = GL.GenBuffer(),
                elementBuffer = GL.GenBuffer(),
                colourBuffer = GL.GenBuffer(),
                vao = GL.GenVertexArray();

            GL.BindVertexArray(vao);

            GL.BindBuffer(BufferTarget.ArrayBuffer, arrayBuffer);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                (IntPtr)(Vector3.SizeInBytes * coordinates.Length), coordinates, BufferUsageHint.DynamicDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, IntPtr.Zero);
            GL.EnableVertexAttribArray(0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, colourBuffer);
            GL.BufferData<float>(BufferTarget.ArrayBuffer,
                (IntPtr)(sizeof(float) * colours.Length), colours, BufferUsageHint.DynamicDraw);
            //GL.VertexAttribFormat(1, 3, VertexAttribType.Float, false, 0);
            //GL.VertexAttribBinding(1, 1);
            //GL.BindVertexBuffer(1, arrayBuffer, (IntPtr)0, 3 * sizeof(float));
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, sizeof(float) * 3, 0);
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBuffer);
            GL.BufferData<short>(BufferTarget.ElementArrayBuffer,
                (IntPtr)(sizeof(short) * indices.Length), indices, BufferUsageHint.DynamicDraw);
            //GL.LineWidth(2);
            using (debugProgram.Use())
            {
                GL.DrawElements(PrimitiveType.Lines, indices.Length, DrawElementsType.UnsignedShort, IntPtr.Zero);
            }
            GL.DeleteBuffers(2, new[] { arrayBuffer, elementBuffer, colourBuffer });
            GL.DeleteVertexArray(vao);

        }
    }
}
