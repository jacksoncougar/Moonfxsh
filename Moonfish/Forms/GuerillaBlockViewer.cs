using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JetBrains.Annotations;
using Moonfish.Guerilla;

namespace Moonfish.Forms
{
    public partial class GuerillaBlockViewer : UserControl
    {
        private GuerillaBlock _block;
        private GuerillaBlock _activeBlock;
        private Dictionary<GuerillaBlock, GuerillaBlock> ParentLookup = new Dictionary<GuerillaBlock, GuerillaBlock>( );

        public GuerillaBlockViewer( )
        {
            InitializeComponent( );
        }

        public void LoadBlock( GuerillaBlock block )
        {
            _block = block;
        }

        public void Display( GuerillaBlock block )
        {
            if ( block == null ) block = _block;
            _activeBlock = block;
            var fields = block.GetType( ).GetFields( );
            dataGridView1.DataSource = fields.Select( u => new {u.Name, Value = u.GetValue( block )} ).ToList( );
        }

        private void dataGridView1_CellContentDoubleClick( object sender, DataGridViewCellEventArgs e )
        {
            var cell = dataGridView1[ e.ColumnIndex, e.RowIndex ];
            var type = cell.Value.GetType( );
            var elementType = type.GetElementType( );
            var guerillaBlock = elementType?.IsSubclassOf( typeof ( GuerillaBlock ) ) ?? false;
            if ( type.IsArray && guerillaBlock )
            {
                var guerillaBlocks = ( ( GuerillaBlock[] ) cell.Value );
                if ( guerillaBlocks.Length > 0 )
                {
                    Display( guerillaBlocks[ 0 ] );
                }
            }
        }

        private void navParent_Click( object sender, EventArgs e )
        {
            GuerillaBlock parent = FindParent( _activeBlock, _block );
            Display( parent );
        }

        private GuerillaBlock FindParent( GuerillaBlock block, GuerillaBlock searchBlock )
        {
            if ( ParentLookup.ContainsKey( block ) ) return ParentLookup[ block ];
            foreach ( var fieldInfo in searchBlock.GetType( ).GetFields( ) )
            {
                //  If the field is a GuerillaBlock or an array of GuerillaBlocks
                if ( fieldInfo.FieldType.IsSubclassOf( typeof ( GuerillaBlock ) ) )
                {
                    if ( ( GuerillaBlock ) fieldInfo.GetValue( searchBlock ) == block )
                    {
                        ParentLookup.Add( block, searchBlock );
                        return searchBlock;
                    }
                }
                if ( fieldInfo.FieldType.IsArray &&
                     fieldInfo.FieldType.GetElementType( ).IsSubclassOf( typeof ( GuerillaBlock ) ) )
                {
                    var guerillaBlocks = ( GuerillaBlock[] ) fieldInfo.GetValue( searchBlock );
                    foreach ( var guerillaBlock in guerillaBlocks )
                    {
                        if ( guerillaBlock == block )
                        {
                            ParentLookup.Add( block, searchBlock );
                            return searchBlock;
                        }
                        FindParent( block, guerillaBlock );
                    }
                }
            }
            return null;
        }
    };
}
