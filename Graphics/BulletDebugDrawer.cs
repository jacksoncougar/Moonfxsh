using BulletSharp;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{

    class BulletDebugDrawer : DebugDraw
    {
        readonly Program debugProgram;

        public BulletDebugDrawer(Program program)
        {
            debugProgram = program;
        }

        public override DebugDrawModes DebugMode
        {
            get
            {
                return DebugDrawModes.MaxDebugDrawMode;
            }
            set
            {
            }
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

        Vector3 bbmin, bbmax;
        Box box = new Box(Vector3.Zero, Vector3.Zero);
        public override void DrawBox(ref Vector3 bbMin, ref Vector3 bbMax, ref Matrix4 trans, Color4 color)
        {
            if (bbmin != bbMin || bbmax != bbMax)
            {
                bbmin = bbMin; bbmax = bbMax;
                box.Resize(bbMin, bbMax);
            }

            using (debugProgram.Use())
            using (OpenGL.Disable(EnableCap.DepthTest))
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

        public override void DrawContactPoint(ref Vector3 pointOnB, ref Vector3 normalOnB, float distance, int lifeTime, Color4 color)
        {
        }

        public override void DrawLine(ref Vector3 from, ref Vector3 to, Color4 color)
        {
        }

        public override void ReportErrorWarning(string warningString)
        {
        }
    }
}
