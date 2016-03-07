using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using Be.Windows.Forms;
using Moonfish.Debug;
using Moonfish.Graphics;
using Moonfish.Guerilla;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Forms
{
    public partial class VrtxASMViewer : Form
    {
        private DataTypes _types = new DataTypes( );
        private MemoryStream _stream;
        private HashSet<GuerillaBlock> blockKeys = new HashSet<GuerillaBlock>( );
        private Dictionary<GuerillaBlock, Stream> vertexStreams = new Dictionary<GuerillaBlock, Stream>( );

        public VrtxASMViewer( )
        {
            InitializeComponent( );
            vertexTags.Columns.Add( "Path" );

            foreach ( var map in GuerillaCodeDom.GetAllMaps( ) )
            {
                var tagDatums = map.Index.Where( u => u.Class == TagClass.Vrtx );

                foreach ( var tagDatum in tagDatums )
                {
                    try
                    {
                        var guerillaBlock = tagDatum.Identifier.Get<VertexShaderBlock>( );
                        for ( int index = 0; index < guerillaBlock.GeometryClassifications.Length; index++ )
                        {
                            var vertexShaderClassificationBlock = guerillaBlock.GeometryClassifications[ index ];
                            if ( vertexShaderClassificationBlock.Code.Length <= 0 ||
                                 !blockKeys.Add( vertexShaderClassificationBlock ) ) continue;

                            var path = map.Index[ tagDatum.Identifier ].Path;
                            var stream = new MemoryStream( vertexShaderClassificationBlock.Code );
                            vertexStreams.Add( vertexShaderClassificationBlock, stream );
                            vertexTags.Items.Add( new ListViewItem
                            {
                                Text = $"{path}: [{index}]",
                                Tag = vertexShaderClassificationBlock
                            } );
                        }
                    }
                    catch
                    {
                        // ignored
                    }
                }
                break;
            }
            vertexTags.Columns[ 0 ].AutoResize( ColumnHeaderAutoResizeStyle.ColumnContent );
            _stream = new MemoryStream( );
            hexBox1.ByteProvider = new DynamicFileByteProvider(_stream);
            vertexTags.Items[ 0 ].Selected = true;
        }

        private void vertexTags_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( vertexTags.SelectedItems.Count > 0 )
            {
                LoadStream( vertexTags.SelectedItems[ 0 ].Tag );
            }
        }

        private void LoadStream( object tag )
        {
            var block = tag as GuerillaBlock;
            if ( block == null ) return;

            var stream = ( MemoryStream ) vertexStreams[ block ];
            var buffer = stream.ToArray( );
            
            hexBox1.ByteProvider.DeleteBytes(0, hexBox1.ByteProvider.Length);
            hexBox1.ByteProvider.InsertBytes(0, buffer);
            hexBox1.ByteProvider.ApplyChanges();
            hexBox1.Refresh();

            var strBuilder = new StringBuilder( );
            using ( BinaryReader binaryReader = new BinaryReader( stream, Encoding.Default, true ) )
            {
                stream.Seek( 0, SeekOrigin.Begin );
                var version = binaryReader.ReadInt16( );
                strBuilder.AppendLine("#" + version);
                var instructionCount = binaryReader.ReadInt16( );
                for ( int i = 0; i < instructionCount; i++ )
                {
                    var instructionBytes = binaryReader.ReadBytes( 16 );
                    var instruction = new VertexProgramInstruction( instructionBytes );
                    strBuilder.AppendLine( instruction.ToAsm );
                }
            }
            asmLines.Text = strBuilder.ToString( );
        }
    };
}