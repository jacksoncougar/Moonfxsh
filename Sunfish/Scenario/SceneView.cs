using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics;
using WeifenLuo.WinFormsUI.Docking;
using Point = System.Drawing.Point;

namespace Sunfish.Forms
{
    public partial class SceneView : DockContent
    {
        public event EventHandler SceneInitialized;

        private GLControl _glControl1;

        public SceneView( )
        {
            SceneClock = new SceneClock( );
            SceneClock.timer.Start( );
            InitializeComponent( );

            LoadGLControl();

        }

        public DynamicScene Scene { get; set; }

        public SceneClock SceneClock { get; }

        private void ChangeViewport( int width, int height )
        {
            Scene.Camera.Viewport.Size = new Size( width, height );
        }

        private void glControl1_Load( object sender, EventArgs e )
        {
            //  create a new dynamic scene and pass this control as the scene owner to hook control
            //  then load the selected map into the scene
            Scene = new DynamicScene(_glControl1);

            //  application idle will handle the render and update loop
            Application.Idle += HandleApplicationIdle;
            Scene.OnFrameReady += Scene_OnFrameReady;
            _glControl1.Resize += glControl1_Resize;

            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera before the first draw can be called
            glControl1_Resize( this, new EventArgs( ) );
            SceneInitialized?.Invoke( this, null );

            OpenGL.EnableDebugging();

        }

        private void glControl1_Resize( object sender, EventArgs e )
        {
            ChangeViewport( _glControl1.Width, _glControl1.Height );
            Scene.RenderFrame( 0f );
        }

        private void HandleApplicationIdle( object sender, EventArgs e )
        {
            while ( IsApplicationIdle( ) )
            {
                Step( );
            }
        }

        public void UpdateScene( )
        {
            Step( );
        }

        private void Step( )
        {
            SceneClock.Tick( );

            if ( SceneClock.Sleep )
            {
                Thread.Sleep( ( int ) ( SceneClock.MinFrameTime * 1000 ) );
            }

            SceneClock.Tock( );

            while ( SceneClock.TimeForUpdate( ) )
            {
                UpdateState( );
                Scene.UpdatePhysics( );
                SceneClock.IntegrateUpdate( );
            }
            var alpha = SceneClock.accumulator / SceneClock.DeltaTime;

            Scene.Update( ( float ) alpha, (float)SceneClock.currentTime);
            Scene.RenderFrame( ( float ) alpha );
        }

        private static bool IsApplicationIdle( )
        {
            NativeMessage result;
            return PeekMessage( out result, IntPtr.Zero, 0, 0, 0 ) == 0;
        }

        private void LoadGLControl( )
        {
#if DEBUG
            // ReSharper disable once UseObjectOrCollectionInitializer
            _glControl1 = new GLControl( new GraphicsMode( new ColorFormat( 32 ), 24, 8, 8 ), 4, 4,
                GraphicsContextFlags.Debug | GraphicsContextFlags.ForwardCompatible );
#else
            _glControl1 = new GLControl( new GraphicsMode(new ColorFormat(32), 24, 8, 8), 4, 4, GraphicsContextFlags.Default);
#endif
            _glControl1.Load += glControl1_Load;
            
            // 
            // glControl1
            // 

            _glControl1.BackColor = Color.Black;
            _glControl1.Dock = DockStyle.Fill;
            _glControl1.Location = new Point( 0, 0 );
            _glControl1.Margin = new System.Windows.Forms.Padding( 0 );
            _glControl1.Name = "glControl1";
            _glControl1.Size = new Size( 686, 425 );
            _glControl1.TabIndex = 6;
            _glControl1.VSync = false;

            Controls.Add( _glControl1 );
        }

        private void Scene_OnFrameReady( object sender, EventArgs e )
        {
            _glControl1.SwapBuffers( );
        }

        private void SceneView_DragDrop( object sender, DragEventArgs e )
        {
            
        }

        private void UpdateState( )
        {
        }

        #region Peek Message Native

        [StructLayout( LayoutKind.Sequential )]
        private struct NativeMessage
        {
            private readonly IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport( "user32.dll" )]
        private static extern int PeekMessage( out SceneView.NativeMessage message, IntPtr window, uint filterMin, uint filterMax,
            uint remove );

        #endregion
    }
}