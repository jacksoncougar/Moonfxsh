using Moonfish.Guerilla.Tags;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Moonfish.Graphics.Input;
using System.Collections.Generic;

namespace Moonfish.Graphics
{
    public partial class MarkerViewer : Form
    {
        DynamicScene Scene { get; set; }
        MapStream Map { get; set; }
        TagIdent SelectedTag { get; set; }

        #region Peek Message Native
        [StructLayout( LayoutKind.Sequential )]
        public struct NativeMessage
        {
            public IntPtr Handle;
            public uint Message;
            public IntPtr WParameter;
            public IntPtr LParameter;
            public uint Time;
            public System.Drawing.Point Location;
        }

        [DllImport( "user32.dll" )]
        public static extern int PeekMessage( out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove );
        #endregion

        bool IsApplicationIdle( )
        {
            NativeMessage result;
            return PeekMessage( out result, IntPtr.Zero, ( uint )0, ( uint )0, ( uint )0 ) == 0;
        }

        public MarkerViewer( )
        {
            InitializeComponent();
            glControl1.Load += glControl1_Load;

            foreach ( var value in Enum.GetValues( typeof( TransformMode ) ) )
            {
                toolStripComboBox1.Items.Add( value );
            }
            toolStripComboBox1.SelectedIndex = 0;
        }

        public void SaveMarkerData( )
        {
            var selectedItem = Scene.ObjectManager[ SelectedTag ].FirstOrDefault();
            if ( selectedItem == null ) return;

            var markerEnumerator = selectedItem.Markers.GetEnumerator();

            BinaryReader binaryReader = new BinaryReader( Map );
            BinaryWriter binaryWriter = new BinaryWriter( Map );

            Map[ "mode", "masterchief" ].Seek();
            Map.Seek( 88, SeekOrigin.Current );
            var markerGroups = binaryReader.ReadBlamPointer( 12 );
            foreach ( var group in markerGroups )
            {
                Map.Seek( group, SeekOrigin.Begin );
                var markers = binaryReader.ReadBlamPointer( 36 );
                foreach ( var marker in markers )
                {
                    var data = markerEnumerator.Current.Key;
                    Map.Seek( marker, SeekOrigin.Begin );
                    Map.Seek( 4, SeekOrigin.Current );
                    binaryWriter.Write( data.translation );
                    binaryWriter.Write( data.rotation );
                    binaryWriter.Write( data.scale );
                    if ( !markerEnumerator.MoveNext() ) return;
                }
            }
        }

        void glControl1_Load( object sender, EventArgs e )
        {
            Scene = new Graphics.DynamicScene();
            Application.Idle += HandleApplicationIdle;
            Scene.OnFrameReady += Scene_OnFrameReady;

            glControl1.Resize += glControl1_Resize;
            glControl1.MouseDown += Scene.Camera.OnMouseDown;
            glControl1.MouseMove += Scene.Camera.OnMouseMove;
            glControl1.MouseUp += Scene.Camera.OnMouseUp;
            glControl1.MouseCaptureChanged += Scene.Camera.OnMouseCaptureChanged;

            glControl1.MouseDown += Scene.OnMouseDown;
            glControl1.MouseMove += Scene.OnMouseMove;
            glControl1.MouseUp += Scene.OnMouseUp;

            var fileName = Path.Combine( Local.MapsDirectory, "headlong.map" );
            var directory = Path.GetDirectoryName( fileName );
            var maps = Directory.GetFiles( directory, "*.map", SearchOption.TopDirectoryOnly );
            var resourceMaps = maps.GroupBy(
                x =>
                {
                    return Halo2.CheckMapType( x );
                }
            ).Where( x => x.Key == MapType.MainMenu
                || x.Key == MapType.Shared
                || x.Key == MapType.SinglePlayerShared )
                .Select( g => g.First() ).ToList();
            resourceMaps.ForEach( x => Halo2.LoadResource( new MapStream( x ) ) );

            Map = new MapStream( fileName );

            listBox1.Items.AddRange( Map.Where( x => x.Type.ToString() == "hlmt" ).Select( x => x ).ToArray() );
            listBox1.DisplayMember = "Path";

            SelectedTag = Map[ "hlmt", "masterchief" ].Meta.Identifier;

            var model = ( ModelBlock )( Map[ SelectedTag ].Deserialize() );

            var scenarioObject = new ScenarioObject( model );
            Scene.ObjectManager.Add( SelectedTag, scenarioObject );
            Scene.CollisionManager.LoadScenarioObjectCollection( Scene.ObjectManager[ SelectedTag ].First() );

            //  firing this method is meant to load the view-projection matrix values into 
            //  the shader uniforms, and initalizes the camera
            glControl1_Resize( this, new EventArgs() );
        }

        void glControl1_Resize( object sender, EventArgs e )
        {
            ChangeViewport( glControl1.Width, glControl1.Height );
        }

        private void ChangeViewport( int width, int height )
        {
            Scene.Camera.Viewport.Size = new Size( width, height );
        }

        void Scene_OnFrameReady( object sender, EventArgs e )
        {
            glControl1.SwapBuffers();
            UpdateState();
        }

        private void UpdateState( )
        {
            Scene.DrawDebugCollision = debugDrawToolStripMenuItem.Checked;
            Scene.MousePole.Mode = ( TransformMode )Enum.Parse( typeof( TransformMode ), toolStripComboBox1.SelectedItem.ToString() );
            var selectedItem = Scene.ObjectManager[ SelectedTag ].FirstOrDefault();
            if ( selectedItem == null ) return;
            selectedItem.Flags = toolStripButton1.Checked ? selectedItem.Flags |= ScenarioObject.RenderFlags.RenderNodes :
                selectedItem.Flags &= ~ScenarioObject.RenderFlags.RenderNodes;
            selectedItem.Flags = toolStripButton2.Checked ? selectedItem.Flags |= ScenarioObject.RenderFlags.RenderMarkers :
                selectedItem.Flags &= ~ScenarioObject.RenderFlags.RenderMarkers;
            selectedItem.Flags = toolStripButton3.Checked ? selectedItem.Flags |= ScenarioObject.RenderFlags.RenderMesh :
                selectedItem.Flags &= ~ScenarioObject.RenderFlags.RenderMesh;
            lblRenderTime.Text = string.Format( lblRenderTime.Tag.ToString(), TimeSpan.FromTicks( ( long )Scene.Performance.FrameTime ).TotalMilliseconds );
        }


        private void HandleApplicationIdle( object sender, EventArgs e )
        {
            while ( IsApplicationIdle() )
            {
                Scene.Update();
                Scene.RenderFrame();
            }
        }

        void RemoveModel( TagIdent ident )
        {
            var @object = Scene.ObjectManager[ ident ].FirstOrDefault();
            if ( @object == null ) return;
            
            var collisionObject = Scene.CollisionManager.World.CollisionObjectArray.Where( x => x == @object.CollisionObject ).FirstOrDefault();
            if ( collisionObject != null )
            {
                Scene.CollisionManager.World.RemoveCollisionObject( @object.CollisionObject );
            }
            foreach ( var marker in @object.Markers )
            {
                var markerCollisionObject = Scene.CollisionManager.World.CollisionObjectArray.Where( x => x.UserObject == marker.Value ).FirstOrDefault();
                if ( markerCollisionObject != null )
                {
                    Scene.CollisionManager.World.RemoveCollisionObject( markerCollisionObject );
                }
            }
            Scene.ObjectManager.Remove( ident );
        }
        void LoadModel( TagIdent ident )
        {
            var model = ( ModelBlock )( Map[ ident ].Deserialize() );

            var scenarioObject = new ScenarioObject( model );
            Scene.ObjectManager.Add( ident, scenarioObject );
            var material = model.RenderModel.materials.FirstOrDefault();
            if ( material != null )
                LoadShader( material.shader.Ident );
            Scene.CollisionManager.LoadScenarioObjectCollection( Scene.ObjectManager[ ident ].First() );
        }

        private void listBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( listBox1.SelectedIndex < 0 ) return;
            RemoveModel( SelectedTag );
            SelectedTag = ( listBox1.SelectedItem as Tag ).Identifier;
            if ( Scene.ObjectManager[ SelectedTag ].Any() == false )
            {
                LoadModel( SelectedTag );
            }
        }

        MaterialShader material;

        private void LoadShader( TagIdent ident )
        {
            var shader = Map[ ident ].Deserialize() as ShaderBlock;
            material = new MaterialShader( shader, Map );
        }
    }
}
