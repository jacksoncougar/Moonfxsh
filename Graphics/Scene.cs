using System;
using System.Diagnostics;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Moonfish.Graphics
{
    public class Scene
    {
        public Performance Performance { get; private set; }
        public MeshManager ObjectManager { get; set; }
        public ProgramManager ProgramManager { get; set; }
        private Stopwatch Timer { get; set; }
        public Camera Camera { get; set; }

        private Vector3 lightPosition = new Vector3( 3.8f, 3.0F, 3.5f );
        private float rotation = 0;

        public event EventHandler OnFrameReady;

        private CoordinateGrid Grid;

        public Scene( )
        {
            Initialize( );
        }

        public virtual void Initialize( )
        {
            Console.WriteLine( GL.GetString( StringName.Version ) );
            Timer = new Stopwatch( );
            Camera = new Camera( );
            ObjectManager = new MeshManager( );
            ProgramManager = new ProgramManager( );
            Performance = new Performance( );
            Grid = new CoordinateGrid( 2, 2 );

            Camera.ViewProjectionMatrixChanged += Camera_ViewProjectionMatrixChanged;
            Camera.ViewMatrixChanged += Camera_ViewMatrixChanged;
            Camera.Viewport.ViewportChanged += Viewport_ViewportChanged;

            OpenGL.ReportError( );
            GL.ClearColor( Color.FromArgb( ~Colours.Green.ToArgb( ) ) );
            OpenGL.ReportError( );
            GL.FrontFace( FrontFaceDirection.Ccw );
            OpenGL.ReportError( );
            GL.Enable( EnableCap.CullFace );
            OpenGL.ReportError( );
            GL.Enable( EnableCap.DepthTest );
            OpenGL.ReportError( );
        }

        private void Viewport_ViewportChanged( object sender, Viewport.ViewportEventArgs e )
        {
            GL.Viewport( 0, 0, e.Viewport.Width, e.Viewport.Height );

#if DEBUG
            if ( ProgramManager.ScreenProgram != null )
            {
                var viewMatrixUniform = ProgramManager.ScreenProgram.GetUniformLocation( "OrthoProjectionMatrixUniform" );
                ProgramManager.ScreenProgram.SetUniform( viewMatrixUniform,
                    Matrix4.CreateOrthographicOffCenter( 0, e.Viewport.Width, e.Viewport.Height, 0, 0.0f, 100.0f ) );
                //ProgramManager.ScreenProgram.SetUniform(viewMatrixUniform, Matrix4.CreateOrthographic(e.Viewport.Width, -e.Viewport.Height, 0.0f, 100.0f));
            }
#endif
        }

        private void Camera_ViewMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            foreach ( var program in ProgramManager )
            {
                program.Use( );
                var viewMatrixUniform = program.GetUniformLocation( "ViewMatrixUniform" );
                program.SetUniform( viewMatrixUniform, ref e.Matrix );
            }
        }

        private void Camera_ViewProjectionMatrixChanged( object sender, MatrixChangedEventArgs e )
        {
            foreach ( var program in ProgramManager )
            {
                program.Use( );
                var viewProjectionMatrixUniform = program.GetUniformLocation( "ViewProjectionMatrixUniform" );
                program.SetUniform( viewProjectionMatrixUniform, ref e.Matrix );
            }
        }

        public virtual void RenderFrame( )
        {
            //Console.WriteLine("RenderFrame()");
            BeginFrame( );
            Draw( Performance.Delta );
            EndFrame( );
        }

        private void EndFrame( )
        {
            //Console.WriteLine("EndFrame()");
            GL.Finish( );
            Performance.EndFrame( );
            if ( OnFrameReady != null ) OnFrameReady( this, new EventArgs( ) );
            GL.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );
        }

        private void BeginFrame( )
        {
            //Console.WriteLine("BeginFrame()");
            Performance.BeginFrame( );
        }

        public virtual void Draw( float delta )
        {
            //Console.WriteLine("Draw()");

            ObjectManager.Draw( ProgramManager );
            var program = ProgramManager.GetProgram( new ShaderReference( ShaderReference.ReferenceType.System, 0 ) );
            using ( program.Use( ) )
            {
                var colourUniform = program.GetUniformLocation( "Colour" );
                program.SetUniform( colourUniform, new ColorF( Color.Black ).RGBA );
                //Grid.Draw();
            }
        }

        public virtual void Update( )
        {
            GL.PointSize( 1.0f );
            //Console.WriteLine("Update()");

            //var R = OpenTK.Matrix4.CreateRotationX( rotation );
            //rotation += OpenTK.MathHelper.DegreesToRadians( 0.03f );
            //rotation = rotation > Maths.Pi2 ? 0 : rotation;
            //var l = OpenTK.Vector3.Transform( lightPosition, R ); //Console.WriteLine(rotation);
            foreach ( var program in ProgramManager )
            {
                var lightPositionAttribute = program.GetUniformLocation( "LightPositionUniform" );

                using ( program.Use( ) )
                    program.SetUniform( lightPositionAttribute, new Vector4( lightPosition ) );
            }
            Camera.Update( );
        }
    };
}