using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Forms.ShaderForm;
using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class ShaderProperties : Form
    {
        private readonly Map _cache;
        readonly List<DockContent> documentsDockContents = new List<DockContent>(); 

        public ShaderProperties( )
        {
            InitializeComponent( );

            using ( _cache = new Map( Path.Combine( Local.MapsDirectory, "ascension.map" ) ) )
            {

                dockPanel1.Theme = new VS2013BlueTheme( );
                var asmEditor = new AsmEditor( "Test.glsl" );
                var tagList = new TagList( );
                var shaderPropertyGrid = new ShaderPropertyGrid( );
                tagList.Load( _cache.Index.Where( TagClass.Vrtx ).ToList( ) );
                tagList.NodeMouseClick +=
                    ( TreeNodeMouseClickEventHandler ) delegate( object sender, TreeNodeMouseClickEventArgs e )
                    {
                        var node = e.Node as TagTreeNode;
                        if ( node != null )
                        {
                            using ( var cache = new Map( Path.Combine( Local.MapsDirectory, "ascension.map" ) )
                                )
                            {
                                shaderPropertyGrid.DisplayVertexConstants( node.Info, cache );
                                DisplayVertexInstructions( node.Info, cache );
                            }
                        }
                    };
                asmEditor.Show( dockPanel1, DockState.Document );
                tagList.Show( dockPanel1, DockState.DockRight );
                shaderPropertyGrid.Show( dockPanel1, DockState.DockLeft );
            }
        }

        private void DisplayVertexInstructions( TagDatum vertexDatum, Map cache )
        {
            foreach ( var documentsDockContent in documentsDockContents )
            {
                documentsDockContent.DockHandler.DockPanel = null;
                documentsDockContent.Dispose(  );
            }
               var vertexBlock = ( VertexShaderBlock ) cache.Deserialize( vertexDatum.Identifier );
            for ( var i = 0; i < vertexBlock.GeometryClassifications.Length; i++ )
            {
                var asmEditor = new AsmEditor( $"vertex_{i}.glsl" );
                var code = vertexBlock.GeometryClassifications[i].Code;
                var altCode = vertexBlock.GeometryClassifications[i].CompiledShader;
                var strBuilder = new StringBuilder( );
                foreach ( var s in altCode )
                {
                    strBuilder.Append( "$ " + s + " " );
                }
                strBuilder.AppendLine( );
                if ( code.Length < 4 )
                {
                    asmEditor.SetText( strBuilder.ToString( ) );
                    return;
                }
                using ( var binaryReader = new BinaryReader( new MemoryStream( code ) ) )
                {
                    var version = binaryReader.ReadInt16( );
                    strBuilder.AppendLine( "#" + version );
                    var instructionCount = binaryReader.ReadInt16( );
                    for (var index = 0 ; index < instructionCount; index++ )
                    {
                        var instructionBytes = binaryReader.ReadBytes( 16 );
                        var instruction = new VertexProgramInstruction( instructionBytes );
                        strBuilder.AppendLine( instruction.ToAsm );
                    }

                }
                documentsDockContents.Add( asmEditor );
                asmEditor.SetText( strBuilder.ToString( ) );
                asmEditor.Show(dockPanel1, DockState.Document);
            }
        }
    };
}