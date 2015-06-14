using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Graphics;
using Moonfish.Tags;
using OpenTK;
using OpenTK.Graphics;
using WeifenLuo.WinFormsUI.Docking;
using Point = System.Drawing.Point;

namespace Moonfish.Forms
{
    public partial class SceneView : DockContent
    {
        private GLControl _glControl1;
        private readonly CacheStream _cacheStream;

        public SceneView( CacheStream cacheStream)
        {
            _cacheStream = cacheStream;
            InitializeComponent( );
            LoadGLControl( );
            _glControl1.Load += glControl1_Load;
        }

        private DynamicScene Scene { get; set; }

        private void ChangeViewport( int width, int height )
        {
            Scene.Camera.Viewport.Size = new Size( width, height );
        }

        private void glControl1_Load( object sender, EventArgs e )
        {
            Scene = new DynamicScene( );
            Application.Idle += HandleApplicationIdle;
            Scene.OnFrameReady += Scene_OnFrameReady;
            
            _glControl1.Resize += glControl1_Resize;
            _glControl1.MouseDown += Scene.Camera.OnMouseDown;
            _glControl1.MouseMove += Scene.Camera.OnMouseMove;
            _glControl1.MouseUp += Scene.Camera.OnMouseUp;
            _glControl1.MouseCaptureChanged += Scene.Camera.OnMouseCaptureChanged;

            _glControl1.MouseDown += Scene.OnMouseDown;
            _glControl1.MouseMove += Scene.OnMouseMove;
            _glControl1.MouseUp += Scene.OnMouseUp;
            _glControl1.MouseClick += Scene.OnMouseClick;
            _glControl1.KeyDown += Scene.caster.OnKeyDown;

            Scene.ObjectManager.ProgramManager = Scene.ProgramManager;
            Scene.ObjectManager.Collision = Scene.CollisionManager;
            Scene.ObjectManager.LoadScenario( _cacheStream );

            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera
            glControl1_Resize( this, new EventArgs( ) );
        }

        protected override void OnPaintBackground( PaintEventArgs e )
        {
            //base.OnPaintBackground( e );
        }

        private void glControl1_Resize( object sender, EventArgs e )
        {
            ChangeViewport( _glControl1.Width, _glControl1.Height );
            Scene.RenderFrame();
        }

        public void HandleApplicationIdle( object sender, EventArgs e )
        {
            while ( IsApplicationIdle( ) )
            {
                UpdateState( );
                Scene.Update( );
                Scene.RenderFrame( );
            }
        }

        private static bool IsApplicationIdle( )
        {
            NativeMessage result;
            return PeekMessage( out result, IntPtr.Zero, 0, 0, 0 ) == 0;
        }

        private void LoadGLControl( )
        {
#if DEBUG
            _glControl1 = new GLControl( GraphicsMode.Default, 3, 3, GraphicsContextFlags.Debug );
#else
            _glControl1 = new GLControl( GraphicsMode.Default );
#endif
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
            _glControl1.VSync = true;

            Controls.Add( _glControl1 );
        }

        private void Scene_OnFrameReady( object sender, EventArgs e )
        {
            _glControl1.SwapBuffers( );
        }

        private void UpdateState( )
        {
            lblRenderTime.Text = string.Format( lblRenderTime.Tag.ToString( ),
                TimeSpan.FromTicks( ( long ) Scene.Performance.FrameTime ).TotalMilliseconds );
        }

        #region Peek Message Native

        [StructLayout( LayoutKind.Sequential )]
        public struct NativeMessage
        {
            private readonly IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public Point Location;
        }

        [DllImport( "user32.dll" )]
        public static extern int PeekMessage( out NativeMessage message, IntPtr window, uint filterMin, uint filterMax,
            uint remove );

        #endregion

        public void AddSceneObject( TagIdent ident )
        {
            int instanceIdent;
            ScenarioObject instanceScenarioObject;
            Scene.ObjectManager.AddInstance( ident, out instanceIdent, out instanceScenarioObject );
            var collisionObject =
                Scene.CollisionManager.World.CollisionObjectArray.First(x => x.UserIndex == instanceIdent && x.UserObject == instanceScenarioObject);
            Scene.SelectedObject( collisionObject );
        }
    }
}