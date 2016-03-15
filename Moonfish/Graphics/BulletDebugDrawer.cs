using System.Drawing;
using BulletSharp;
using Moonfish.Graphics.Primitives;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    internal class BulletDebugDrawer : DebugDraw
    {
        private readonly Program debugProgram;

        public BulletDebugDrawer(Program program)
        {
            debugProgram = program;
        }

        public override DebugDrawModes DebugMode
        {
            get { return DebugDrawModes.MaxDebugDrawMode; }
            set { }
        }

        public override void DrawBox(ref Vector3 bbMin, ref Vector3 bbMax, Color4 color)
        {
            //using (debugProgram.Use())
            //{
            //    var worldMatrixUniform = debugProgram.GetUniformLocation("worldMatrix");
            //    debugProgram.SetUniform(worldMatrixUniform, OpenTK.Matrix4.Identity);
            //    using (Box box = new Box(bbMin, bbMax))
            //    {
            //        box.Render(new[] { debugProgram });
            //    }
            //}
        }

        private Vector3 bbmin, bbmax;
        private Box box = new Box(Vector3.Zero, Vector3.Zero);

        public override void DrawTransform( ref Matrix4 transform, float orthoLen )
        {
            var origin = transform.ExtractTranslation( );
            var x = origin + transform.Row0.Xyz.Normalized(  ) * orthoLen;
            var y = origin + transform.Row1.Xyz.Normalized() * orthoLen;
            var z = origin + transform.Row2.Xyz.Normalized() * orthoLen;
            GLDebug.QueueLineDraw(ref origin, ref x);
            GLDebug.QueueLineDraw(ref origin, ref y);
            GLDebug.QueueLineDraw(ref origin, ref z);
        }

        public override void DrawLine( ref Vector3 @from, ref Vector3 to, Color4 fromColor, Color4 toColor )
        {
            GLDebug.QueueLineDraw(ref from, ref to);
        }

        public override void DrawAabb( ref Vector3 @from, ref Vector3 to, Color4 color )
        {
            if (bbmin != @from || bbmax != to)
            {
                bbmin = @from;
                bbmax = to;
                box.Resize(@from, to);
            }

            debugProgram.Assign();
            {
                var worldMatrixUniform = debugProgram.GetUniformLocation("WorldMatrixUniform");
                debugProgram.SetUniform(worldMatrixUniform, Matrix4.Identity);
                GL.BindVertexArray(box.VertexArrayObjectIdent);
                GL.DrawElements(box.PrimitiveType, box.ElementCount, DrawElementsType.UnsignedShort, 0);
            }
        }

        public override void DrawBox(ref Vector3 bbMin, ref Vector3 bbMax, ref Matrix4 trans, Color4 color)
        {
            if (bbmin != bbMin || bbmax != bbMax)
            {
                bbmin = bbMin;
                bbmax = bbMax;
                box.Resize(bbMin, bbMax);
            }

            debugProgram.Assign(  );
            {
                var worldMatrixUniform = debugProgram.GetUniformLocation("WorldMatrixUniform");
                debugProgram.SetUniform(worldMatrixUniform, trans);
                GL.BindVertexArray(box.VertexArrayObjectIdent);
                GL.DrawElements(box.PrimitiveType, box.ElementCount, DrawElementsType.UnsignedShort, 0);
            }
        }

        public override void DrawSphere(float radius, ref Matrix4 transform, Color4 color)
        {
            var min = -radius;
            var max = radius;
            var minVector = new Vector3(min, min, min);
            var maxVector = new Vector3(max, max, max);
            DrawBox(ref minVector, ref maxVector, ref transform, color);
        }

        public override void Draw3dText(ref Vector3 location, string textString)
        {
        }

        public override void DrawContactPoint(ref Vector3 pointOnB, ref Vector3 normalOnB, float distance, int lifeTime,
            Color4 color)
        {
        }

        public override void DrawLine(ref Vector3 from, ref Vector3 to, Color4 color)
        {
            GLDebug.QueueLineDraw( ref from, ref to );
        }

        public override void ReportErrorWarning(string warningString)
        {
        }
    }
}