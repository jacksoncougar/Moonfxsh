using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Fasterflect;
using JetBrains.Annotations;
using Moonfish.Guerilla;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class GuerillaBlockPropertyViewer : DockContent
    {
        private GuerillaBlock _guerillaBlock;

        public GuerillaBlockPropertyViewer( )
        {
            InitializeComponent( );
        }

        public void LoadGuerillaBlocks( GuerillaBlock guerillaBlock )
        {
            _guerillaBlock = guerillaBlock;
            if ( guerillaBlock == null ) return;

            var fields = guerillaBlock.GetType( ).GetFields( );
            treeView1.Nodes.Clear( );
            treeView1.Nodes.AddRange( ParseChildNodes( fields, guerillaBlock ) );
            treeView1.ExpandAll( );
        }

        private void AddNew( )
        {
            var selectedNode = treeView1.SelectedNode;
            var tag = selectedNode.Tag as Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo>;

            if ( tag == null )
            {
                return;
            }

            var guerillaBlocks = new List<GuerillaBlock>
            {
                ( GuerillaBlock ) Activator.CreateInstance( tag.Item3.FieldType.GetElementType( ) )
            };

            UpdateGuerillaBlock( tag, guerillaBlocks.ToArray( ) );
        }

        private void Clone( int count = 1 )
        {
            GuerillaBlock element;
            Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo> tag;
            if ( GetActiveNode( out element, out tag ) ) return;

            var tempList = new List<GuerillaBlock>( tag.Item2.Concat( Enumerable.Repeat( element, count ) ) );

            UpdateGuerillaBlock( tag, tempList.ToArray( ) );
        }

        private void clonemanyToolStripMenuItem_Click( object sender, EventArgs e )
        {
            var inputBox = new InputBox( );
            if ( inputBox.ShowDialog( this ) == DialogResult.OK )
            {
                var value = inputBox.Value;
                if ( value <= 0 ) return;
                Clone( value );
            }
        }

        private void cloneToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Clone( );
        }

        /// <summary>
        ///     We use this hack because FieldInfo.SetValue won't implicitly find the right converter
        /// </summary>
        /// <typeparam name="T">The type of the element to convert to</typeparam>
        /// <param name="input">The array holding the elements to convert</param>
        /// <returns>An array of type T</returns>
        private static T[] Convert<T>( dynamic[] input )
        {
            var t = new T[input.Length];
            for ( var i = 0; i < input.Length; i++ )
            {
                t[ i ] = ( T ) input[ i ];
            }
            return t;
        }

        private void Delete( )
        {
            GuerillaBlock element;
            Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo> tag;
            if ( GetActiveNode( out element, out tag ) ) return;

            var guerillaBlocks = new List<GuerillaBlock>( tag.Item2 );
            guerillaBlocks.Remove( element );
            var tempList = new List<GuerillaBlock>( guerillaBlocks );

            UpdateGuerillaBlock( tag, tempList.ToArray( ) );
        }

        private bool GetActiveNode( out GuerillaBlock element, out Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo> tag )
        {
            var selectedNode = treeView1.SelectedNode;
            element = selectedNode.Tag as GuerillaBlock;

            if ( element == null )
            {
                tag = null;
                return true;
            }

            var parentNode = treeView1.SelectedNode.Parent;
            tag = ( Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo> ) parentNode.Tag;
            return false;
        }

        private static TreeNode[] ParseChildNodes( [NotNull] FieldInfo[] fields, GuerillaBlock guerillaBlock )
        {
            if ( fields == null ) throw new ArgumentNullException( "fields" );
            var arrayFields =
                fields.Where(
                    x => x.FieldType.IsArray && x.FieldType.GetElementType( ).BaseType == typeof ( GuerillaBlock ) )
                    .ToArray( );
            var treeNodes = new TreeNode[arrayFields.Count( )];

            for ( var index = 0; index < arrayFields.Length; index++ )
            {
                var fieldInfo = arrayFields[ index ];

                var value = ( GuerillaBlock[] ) fieldInfo.Get( guerillaBlock );


                var arrayNode = new TreeNode( fieldInfo.Name )
                {
                    ImageIndex = 0,
                    SelectedImageIndex = 0,
                    Tag = new Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo>( guerillaBlock, value, fieldInfo )
                };

                for ( var i = 0; i < value.Length; i++ )
                {
                    var element = value[ i ];

                    var elementNode = new TreeNode( string.Format( fieldInfo.Name + "[{0}]", i ) )
                    {
                        ImageIndex = 1,
                        SelectedImageIndex = 1,
                        Tag = element
                    };
                    elementNode.Nodes.AddRange( ParseChildNodes( fieldInfo.FieldType.GetElementType( ).GetFields( ),
                        element ) );
                    arrayNode.Nodes.Add( elementNode );
                }

                treeNodes[ index ] = arrayNode;
            }
            return treeNodes;
        }

        private void treeView1_KeyDown( object sender, KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.Delete:
                    Delete( );
                    break;
                case Keys.Add:
                    AddNew( );
                    break;
            }
        }

        private void treeView1_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
                treeView1.SelectedNode = treeView1.GetNodeAt( e.X, e.Y );
        }

        private void UpdateGuerillaBlock( Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo> tag,
            [NotNull] GuerillaBlock[] tempList )
        {
            if ( tempList == null ) throw new ArgumentNullException( "tempList" );

            #region hacky

            var method = typeof ( GuerillaBlockPropertyViewer )
                .GetMethod( "Convert", BindingFlags.Static | BindingFlags.NonPublic );
            method = method.MakeGenericMethod( tag.Item3.FieldType.GetElementType( ) );

            var t = method.Invoke( null, new object[] {tempList} );

            #endregion

            tag.Item3.SetValue( tag.Item1, t );
            LoadGuerillaBlocks( _guerillaBlock );
        }
    };
}