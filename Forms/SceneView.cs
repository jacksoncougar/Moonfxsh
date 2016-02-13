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

namespace Moonfish.Forms
{
    public partial class SceneView : DockContent
    {
        private CacheStream _cacheStream;
        private GLControl _glControl1;

        public SceneView( CacheStream cacheStream )
        {
            SceneClock = new SceneClock( );
            SceneClock.timer.Start( );
            _cacheStream = cacheStream;
            InitializeComponent( );
            LoadGLControl( );
            _glControl1.Load += glControl1_Load;
        }

        public SceneView( )
        {
            SceneClock = new SceneClock( );
            SceneClock.timer.Start( );
            InitializeComponent( );
            GuerillaBlockPropertyViewer blockPropertyViewer = new GuerillaBlockPropertyViewer(  );
            blockPropertyViewer.DockTo( FloatPane, DockStyle.Right, 0 );
        }

        private DynamicScene Scene { get; set; }

        private SceneClock SceneClock { get; }

        private void ChangeViewport( int width, int height )
        {
            Scene.Camera.Viewport.Size = new Size( width, height );
        }

        private void glControl1_Load( object sender, EventArgs e )
        {
            //  create a new dynamic scene and pass this control as the scene owner to hook control
            //  then load the selected map into the scene
            Scene = new DynamicScene( _glControl1 );
            Scene.Manager.Load( _cacheStream );
            //var tagDatum  = _cacheStream.Index.SingleOrDefault(u => u.Class == TagClass.Bloc && u.Path.Contains("fusion"));

            //  application idle will handle the render and update loop
            Application.Idle += HandleApplicationIdle;
            Scene.OnFrameReady += Scene_OnFrameReady;
            _glControl1.Resize += glControl1_Resize;

            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera before the first draw can be called
            glControl1_Resize( this, new EventArgs( ) );
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

                Scene.Update( );
                Scene.RenderFrame( ( float ) alpha );
            }
        }

        private static bool IsApplicationIdle( )
        {
            SceneView.NativeMessage result;
            return PeekMessage( out result, IntPtr.Zero, 0, 0, 0 ) == 0;
        }

        private void LoadGLControl( )
        {
#if DEBUG
            // ReSharper disable once UseObjectOrCollectionInitializer
            _glControl1 = new GLControl( new GraphicsMode( new ColorFormat( 32 ), 24, 8, 8 ), 3, 3,
                GraphicsContextFlags.Debug | GraphicsContextFlags.ForwardCompatible );
#else
            _glControl1 = new GLControl( new GraphicsMode(new ColorFormat(32), 24, 8, 8), 3, 3, GraphicsContextFlags.Default);
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
            _glControl1.VSync = false;

            Controls.Add( _glControl1 );
        }

        private void openMapToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var dialog = new OpenFileDialog
            {
                Filter = @"Blam! Map File (.map)|*.map"
            };
            if ( dialog.ShowDialog( ) != DialogResult.OK ) return;
            _cacheStream = CacheStream.Open( dialog.FileName );
            LoadGLControl( );
            _glControl1.Load += glControl1_Load;
            glControl1_Load( null, null );
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
            lblRenderTime.Text = string.Format( lblRenderTime.Tag.ToString( ),
                TimeSpan.FromTicks( SceneClock.totalTime ).TotalMilliseconds, TimeSpan.FromTicks( SceneClock.updateTime ).TotalMilliseconds,
                TimeSpan.FromTicks( Scene.Performance.FrameTime ).TotalMilliseconds );
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