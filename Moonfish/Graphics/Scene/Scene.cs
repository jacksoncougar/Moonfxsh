using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Scene
    {
        public Scene( )
        {
            Initialize( );
        }

        public Camera Camera { get; set; }
        public ScenarioManager Manager { get; set; }
        public Performance Performance { get; private set; }
        public ProgramManager ProgramManager { get; set; }
        private Stopwatch Timer { get; set; }

        public event EventHandler OnFrameReady;

        public void RenderFrame( float timeStep )
        {
            BeginFrame( );
            Draw(timeStep);
            EndFrame( );
        }

        public virtual void Update( float delta, float beta )
        {
            Camera.Update( delta, beta );
        }

        protected virtual void Draw( float delta )
        {
            Manager.DrawScenario(Camera, ProgramManager);
        }

        private void BeginFrame( )
        {
            Performance.BeginFrame( );
        }

        private void Camera_ViewMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            foreach ( var program in ProgramManager )
            {
                program.Assign(  );
                var viewMatrixUniform = program.GetUniformLocation("ViewMatrixUniform");
                program.SetUniform( viewMatrixUniform,  e.Matrix  );
            }
        }

        private void Camera_ViewProjectionMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            foreach ( var program in ProgramManager )
            {
                program.Use( );
                var viewProjectionMatrixUniform = program.GetUniformLocation("ViewProjectionMatrixUniform");
                program.SetUniform(viewProjectionMatrixUniform, ref e.Matrix);
            }
        }

        private void EndFrame( )
        {
            Performance.EndFrame( );
            OnFrameReady?.Invoke( this, new EventArgs( ) );
            GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        }

        private void Initialize( )
        {
            Console.WriteLine( GL.GetString( StringName.Version ) );
            Timer = new Stopwatch( );
            Camera = new Camera( );
            Manager = new ScenarioManager();
            ProgramManager = new ProgramManager( );
            Performance = new Performance( );

            Camera.ViewProjectionMatrixChanged += Camera_ViewProjectionMatrixChanged;
            Camera.ViewMatrixChanged += Camera_ViewMatrixChanged;
            Camera.Viewport.ViewportChanged += Viewport_ViewportChanged;

            GL.ClearColor( Color.FromArgb( ~Colours.Green.ToArgb( ) ) );
            GL.FrontFace( FrontFaceDirection.Ccw );
            GL.Disable( EnableCap.CullFace );
            GL.Enable( EnableCap.DepthTest );
            GL.PointSize( 5.0f );
        }

        private void Viewport_ViewportChanged( object sender, Viewport.ViewportEventArgs e )
        {
            GL.Viewport( 0, 0, e.Viewport.Width, e.Viewport.Height );
            foreach (var program in ProgramManager)
            {
                program.Assign();
                var viewMatrixUniform = program.GetUniformLocation("ViewportMatrixUniform");
                var viewportMatrix = new Matrix2(new Vector2(2.0f / e.Viewport.Width, 0.0f), new Vector2(0.0f, 2.0f/e.Viewport.Height) );
                program.SetUniform( viewMatrixUniform, viewportMatrix );
            }
        }
    };
}