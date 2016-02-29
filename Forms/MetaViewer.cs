using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using Be.Windows.Forms;
using Moonfish.Guerilla;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Forms
{
    public partial class MetaViewer : Form
    {
        private MemoryStream _stream;
        private readonly DataTypes _converter;
        private Dictionary<GuerillaBlock, Stream> _streamDictionary;
        private Type _type;
        
        public MetaViewer( ) 
        {
            InitializeComponent();
            hexBox1.ByteCharConverter  = new DefaultByteCharConverter(  );
            _streamDictionary = new Dictionary<GuerillaBlock, Stream>();

            foreach ( var map in GuerillaCodeDom.GetAllMaps() )
            {
                var tagDatums = map.Index.Where( u => u.Class == TagClass.Vrtx );

                foreach ( var tagDatum in tagDatums )
                {
                    try
                    {
                        var guerillaBlock = tagDatum.Identifier.Get<VertexShaderBlock>();
                        var stream = new MemoryStream();
                        var buffer = guerillaBlock.GeometryClassifications[0].Code;
                        stream.Write(buffer, 0, buffer.Length);

                        if (!_streamDictionary.ContainsKey(guerillaBlock.GeometryClassifications[0]))
                            _streamDictionary.Add(guerillaBlock.GeometryClassifications[0], stream);

                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            
            toolStripComboBox1.Items.AddRange( _streamDictionary.Select( u=>(object)u.Key ).ToArray(  ) );
            _stream = new MemoryStream();
            propertyGrid1.SelectedObject = _converter = new DataTypes( );
            hexBox1.ByteProvider = new DynamicFileByteProvider(_stream);
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void hexBox1_SelectionLengthChanged(object sender, EventArgs e)
        {
            UpdateCaret();
        }

        private void UpdateValueTypes( long start, long count )
        {
            start = start < 0 ? 0 : start;
            _stream.Seek( start, SeekOrigin.Begin );

            var eof = _stream.Length - _stream.Position;
            count = eof < count ? eof : count;

            var buffer = new byte[count];

            _stream.Read( buffer, 0, ( int ) count );
            _converter.data = buffer;
            propertyGrid1.Refresh( );
        }
        
        private void hexBox1_CurrentLineChanged(object sender, EventArgs e)
        {
            UpdateCaret( );
        }

        private void UpdateCaret( )
        {
            var start = hexBox1.SelectionStart;
            var count = hexBox1.SelectionLength;
            if ( count > 0 )
            {
                UpdateValueTypes(start, count);
                UpdateValueSieve( start, count );
                return;
            }
            var currentPositionInLine = hexBox1.CurrentPositionInLine;
            var currentLine = hexBox1.CurrentLine;
            var bytesPerLine = hexBox1.HorizontalByteCount;
            var offset = ( currentLine - 1 ) * bytesPerLine + ( currentPositionInLine - 1 );
            UpdateValueTypes( offset, 4 );
        }
        

        private void UpdateValueSieve( long start, long count )
        {
            HashSet<object> value = new HashSet<object>();
            foreach (var stream in _streamDictionary.Select(u => u.Value))
            {
                var buffer = new byte[count];
                stream.Position = start;
                stream.Read(buffer, (int)0, (int)count);
                if ( _type == typeof ( byte ) && count >= sizeof(byte))
                {
                    value.Add(new { Name = buffer[0] });
                }
                else if (_type == typeof(short) && count >= sizeof(short))
                {
                    value.Add(new { Name = BitConverter.ToInt16(buffer, 0) });

                }
                else if (_type == typeof(bool) && count >= sizeof(byte))
                {
                    //var b = new BitArray(buffer);
                    //value.Add( new {Name = new string( b.Cast<bool>( ).Select( bit => bit ? '1' : '0' ).ToArray( ) )} );
                }
                else
                {
                    value.Add( new {Name = BitConverter.ToString( buffer )} );
                }
            }
            var source = new BindingSource( );
            source.DataSource = value;
            dataGridView1.DataSource = source;
            
        }

        private void hexBox1_CurrentPositionInLineChanged(object sender, EventArgs e)
        {
            UpdateCaret();
        }

        private void toolStripComboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            var key = toolStripComboBox1.SelectedItem as GuerillaBlock;
            if ( key == null ) return;
            var newStream = new MemoryStream( );
            newStream.Write( key );
            var buffer = newStream.ToArray( );
            if ( hexBox1.ByteProvider.Length >= buffer.Length )
            {
                hexBox1.ByteProvider.DeleteBytes( 0, newStream.Length );
            }
            hexBox1.ByteProvider.InsertBytes( 0, buffer );
            hexBox1.ByteProvider.ApplyChanges(  );
            hexBox1.Invalidate();
            UpdateCaret( );

        }

        private Keys forward { get; set; } = Keys.F2;

        private Keys back { get; set; } = Keys.F1;

        private void MetaViewer_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == back)
            {
                if (toolStripComboBox1.SelectedIndex > 1)
                {
                    toolStripComboBox1.SelectedIndex--;
                }
            }
            else if (e.KeyCode == forward)
            {
                if (toolStripComboBox1.SelectedIndex < toolStripComboBox1.Items.Count - 1)
                {
                    toolStripComboBox1.SelectedIndex++;
                }
            }
        }

        private void propertyGrid1_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
        {
            switch ( e.NewSelection.Label.ToLower() )
            {
                case "byte":
                    _type = typeof ( byte );
                    break;
                case "short":
                    _type = typeof(short);
                    break;
                case "bits":
                    _type = typeof(bool);
                    break;
                default:
                    _type = e.NewSelection.Label == "int" ? typeof ( int ) : typeof ( string );
                    break;
            }
        }

        private void hexBox1_CopiedHex(object sender, EventArgs e)
        {

        }

        private void hexBox1_Copied(object sender, EventArgs e)
        {
            var data = Clipboard.GetData(DataFormats.StringFormat );
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = dataGridView1.GetClipboardContent( );
            if ( data != null ) Clipboard.SetDataObject( data );
        }
    }
}