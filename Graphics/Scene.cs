using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace Moonfish.Graphics
{
    public class Scene
    {
        public Performance Performance { get; private set; }
        public MeshManager ObjectManager { get; set; }
        ProgramManager ProgramManager { get; set; }
        Stopwatch Timer { get; set; }
        public Camera Camera { get; set; }

        OpenTK.Vector3 lightPosition = new OpenTK.Vector3(0.8f, 0.0F, 0.5f);
        float rotation = 0;

        public event EventHandler OnFrameReady;

        int NormalMapPaletteTexture;
        CoordinateGrid Grid;

        public Scene()
        {
            Initialize();
        }

        public virtual void Initialize()
        {
            Console.WriteLine(GL.GetString(StringName.Version));
            Timer = new Stopwatch();
            Camera = new Camera();
            ObjectManager = new MeshManager();
            ProgramManager = new ProgramManager();
            Performance = new Performance();
            Grid = new CoordinateGrid();

            Camera.ViewProjectionMatrixChanged += Camera_ViewProjectionMatrixChanged;
            Camera.ViewMatrixChanged += Camera_ViewMatrixChanged;
            Camera.Viewport.ViewportChanged += Viewport_ViewportChanged;

            OpenGL.ReportError();
            GL.ClearColor(Colours.Green);
            OpenGL.ReportError();
            GL.FrontFace(FrontFaceDirection.Ccw);
            OpenGL.ReportError();
            GL.Enable(EnableCap.CullFace);
            OpenGL.ReportError();
            GL.Enable(EnableCap.DepthTest);
            OpenGL.ReportError();
        }

        void Viewport_ViewportChanged(object sender, Viewport.ViewportEventArgs e)
        {
            GL.Viewport(0, 0, e.Viewport.Width, e.Viewport.Height);
        }

        void Camera_ViewMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            foreach (var program in ProgramManager)
            {
                program.Use();
                var viewMatrixUniform = program.GetUniformLocation("ViewMatrixUniform");
                program.SetUniform(viewMatrixUniform, ref e.Matrix);
            }
        }

        void Camera_ViewProjectionMatrixChanged(object sender, MatrixChangedEventArgs e)
        {
            foreach (var program in ProgramManager)
            {
                program.Use();
                var viewProjectionMatrixUniform = program.GetUniformLocation("ViewProjectionMatrixUniform");
                program.SetUniform(viewProjectionMatrixUniform, ref e.Matrix);
            }
        }

        public virtual void RenderFrame()
        {
            //Console.WriteLine("RenderFrame()");
            BeginFrame();
            Draw(Performance.Delta);
            EndFrame();
        }

        private void EndFrame()
        {
            //Console.WriteLine("EndFrame()");
            GL.Finish();
            Performance.EndFrame();
            if (OnFrameReady != null) OnFrameReady(this, new EventArgs());
        }

        private void BeginFrame()
        {
            //Console.WriteLine("BeginFrame()");
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Performance.BeginFrame();
        }

        public virtual void Draw(float delta)
        {
            //Console.WriteLine("Draw()");

            ObjectManager.Draw(ProgramManager);
        }



        public virtual void Update()
        {
            //Console.WriteLine("Update()");

            var R = OpenTK.Matrix4.CreateRotationX(rotation);
            rotation += OpenTK.MathHelper.DegreesToRadians(0.03f);
            rotation = rotation > Maths.Pi2 ? 0 : rotation;
            var l = OpenTK.Vector3.Transform(lightPosition, R); //Console.WriteLine(rotation);
            foreach (var program in ProgramManager)
            {
                var lightPositionAttribute = program.GetUniformLocation("LightPositionUniform");

                using (program.Use())
                    program.SetUniform(lightPositionAttribute, new OpenTK.Vector4(l));

            }
            Camera.Update();
        }
    };
}
