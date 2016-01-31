using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        private readonly Stopwatch _timer = new Stopwatch( );
        private CacheStream _cacheStream;
        private GLControl _glControl1;
        private long _totalTime;
        private long _updateTime;
        private double _accumulator;
        private double _currentTime;
        private readonly double _deltaTime = 0.09f;

        private double _lastUpdate;
        private double _minUpdateFreq = 1f / 50f;

        public SceneView( CacheStream cacheStream )
        {
            _timer.Start( );
            _cacheStream = cacheStream;
            InitializeComponent( );
            LoadGLControl( );
            _glControl1.Load += glControl1_Load;
        }

        public SceneView( )
        {
            _timer.Start( );
            InitializeComponent( );
        }

        private DynamicScene Scene { get; set; }

        public void AddSceneObject( TagIdent ident )
        {
            //int instanceIdent;
            //ScenarioObject instanceScenarioObject;
            //if ( Scene.ObjectManager.Contains( ident ) )
            //    Scene.ObjectManager.AddInstance( ident, out instanceIdent, out instanceScenarioObject,
            //        Matrix4.CreateTranslation( Scene.CurrentMouseWorldPosition ) );
            //else
            //{
            //    var objectBlock = ( ObjectBlock ) _cacheStream.Deserialize( ident );
            //    var modelBlock = objectBlock.Model.Get<ModelBlock>( );
            //    if ( modelBlock == null ) return;
            //    instanceScenarioObject = new ScenarioObject( modelBlock );
            //    instanceScenarioObject.AssignInstanceMatrices( new Matrix4[0] );
            //    Scene.ObjectManager.Add( ident, instanceScenarioObject );
            //    Scene.ObjectManager.AddInstance( ident, out instanceIdent, out instanceScenarioObject,
            //        Matrix4.CreateTranslation( Scene.CurrentMouseWorldPosition ) );

            //    var renderModel = instanceScenarioObject.Model.RenderModel.Get<RenderModelBlock>( );
            //    if ( renderModel != null )
            //        Scene.ProgramManager.LoadMaterials( renderModel.Materials, _cacheStream );
            //}

            //var collisionObject =
            //    Scene.CollisionManager.World.CollisionObjectArray.First(
            //        x => x.UserIndex == instanceIdent && x.UserObject == instanceScenarioObject );
            //Scene.SelectObject( collisionObject );
        }
        
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
            _glControl1.KeyDown +=
                delegate( object sender1, KeyEventArgs e1 )
                {
                    if ( e1.KeyCode == Keys.X )
                        Scene.Camera.LookAt( Scene.GetLocationOf( Scene.SelectedObject ) );
                    if ( e1.KeyCode == Keys.Z )
                        Scene.Camera.ZoomTo( Scene.SelectedObject );
                };

            _glControl1.MouseDown += Scene.OnMouseDown;
            _glControl1.MouseMove += Scene.OnMouseMove;
            _glControl1.MouseUp += Scene.OnMouseUp;
            _glControl1.MouseClick += Scene.OnMouseClick;

            //Scene.Manager.ProgramManager = Scene.ProgramManager;
            //Scene.Manager.Collision = Scene.CollisionManager;

            Scene.Manager.Load( _cacheStream );

            //Scene.ObjectManager.LoadScenario(_cacheStream);
            //Scene.Manager.LoadObject(
            //    ( ObjectBlock )
            //        _cacheStream.Deserialize(
            //            _cacheStream.Index.Where( TagClass.Bipd, "masterchief_mp" ).First( ).Identifier ) );

            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera
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
                var newTime = _timer.ElapsedMilliseconds / 1000f;
                var baseTick = _timer.ElapsedTicks;
                var frameTime = newTime - _currentTime;


                if ( frameTime > 0.25 ) frameTime = 0.25;
                _currentTime = newTime;

                _accumulator += frameTime;

                while ( _accumulator >= _deltaTime )
                {
                    UpdateState( );
                    Scene.UpdatePhysics( );
                    _updateTime = _timer.ElapsedTicks - baseTick;
                    _accumulator -= _deltaTime;
                }
                var alpha = _accumulator / _deltaTime;

                Scene.Update( );
                Scene.RenderFrame( ( float ) alpha );
                _totalTime = _timer.ElapsedTicks - baseTick;
                _lastUpdate = 0;
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
            // ReSharper disable once UseObjectOrCollectionInitializer
            _glControl1 = new GLControl( new GraphicsMode( new ColorFormat( 32 ), 24, 8, 0 ), 3, 3,
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
            if ( dialog.ShowDialog( ) == DialogResult.OK )
            {
                _cacheStream = CacheStream.Open( dialog.FileName );
                LoadGLControl( );
                _glControl1.Load += glControl1_Load;
                glControl1_Load( null, null );
            }
        }

        private void Scene_OnFrameReady( object sender, EventArgs e )
        {
            _glControl1.SwapBuffers( );
        }

        private void SceneView_DragDrop( object sender, DragEventArgs e )
        {
            var test = e.Data.GetData( DataFormats.FileDrop );
        }

        private void UpdateState( )
        {
            lblRenderTime.Text = string.Format( lblRenderTime.Tag.ToString( ),
                TimeSpan.FromTicks( _totalTime ).TotalMilliseconds, TimeSpan.FromTicks( _updateTime ).TotalMilliseconds,
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
        private static extern int PeekMessage( out NativeMessage message, IntPtr window, uint filterMin, uint filterMax,
            uint remove );

        #endregion
    }
}