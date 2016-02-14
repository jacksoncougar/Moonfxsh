using System;
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
using Moonfish.Cache;
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

        public MetaViewer()
        {
            InitializeComponent();
        }

        public MetaViewer( CacheStream cacheStream ) : this( )
        {

            _streamDictionary = new Dictionary<GuerillaBlock, Stream>();

            foreach ( var map in GuerillaCodeDom.GetAllMaps() )
            {
                var tagDatums = map.Index.Where( u => u.Class == TagClass.Spas );

                foreach ( var tagDatum in tagDatums )
                {
                    var guerillaBlock = tagDatum.Identifier.Get<ShaderPassBlock>( );
                    foreach ( var textureState in guerillaBlock.PostprocessDefinition[ 0 ].TextureStates )
                    {
                        var stream = new MemoryStream( );
                        stream.Write( textureState );
                        _streamDictionary.Add( textureState, stream );
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
                else if ( _type == typeof ( short ) && count >= sizeof(short))
                {
                    value.Add(new { Name = BitConverter.ToInt16( buffer, 0 ) });

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
            switch ( e.NewSelection.Label )
            {
                case "Byte":
                    _type = typeof ( byte );
                    break;
                case "Short":
                    _type = typeof ( short );
                    break;
                default:
                    _type = e.NewSelection.Label == "int" ? typeof ( int ) : typeof ( string );
                    break;
            }
        }
    }
}

public class DataTypes
{
    public byte[] data = new byte[0];

    public string Byte
    {
        get { return data.Length >= sizeof(byte) ? data[ 0 ].ToString( ) : ""; }
        set
        {
            byte result;
            if ( byte.TryParse( value, out result ) && data.Length >= sizeof(byte))
                data[ 0 ] = result;
        }
    }

    public string Short
    {
        get { return data.Length >= sizeof(short) ? BitConverter.ToInt16( data, 0 ).ToString() : ""; }
        set
        {
            short result;
            if (short.TryParse(value, out result) && data.Length >= sizeof(short))
            {
                var bytes = BitConverter.GetBytes(result);
                Array.Copy(bytes, data, sizeof(short));
            }
        }
    }

    public string Int
    {
        get { return data.Length >= sizeof(int) ? BitConverter.ToInt32(data, 0).ToString() : ""; }
        set
        {
            int result;
            if ( int.TryParse( value, out result ) && data.Length >= sizeof ( int ) )
            {
                var bytes = BitConverter.GetBytes( result );
                Array.Copy( bytes, data, sizeof ( int ) );
            }
        }
    }
}