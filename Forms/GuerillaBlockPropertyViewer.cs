using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Moonfish.Guerilla;
using WeifenLuo.WinFormsUI.Docking;
using Fasterflect;
using JetBrains.Annotations;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;

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

                for ( int i = 0; i < value.Length; i++ )
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

        private void treeView1_MouseClick( object sender, MouseEventArgs e )
        {
            if ( e.Button == MouseButtons.Right )
                treeView1.SelectedNode = treeView1.GetNodeAt( e.X, e.Y );
        }

        private void cloneToolStripMenuItem_Click( object sender, EventArgs e )
        {
            Clone( );
        }

        private void Clone( int count = 1)
        {
            var selectedNode = treeView1.SelectedNode;
            var element = selectedNode.Tag as GuerillaBlock;

            if ( element == null ) return;

            var parentNode = treeView1.SelectedNode.Parent;
            var tag = ( Tuple<GuerillaBlock, GuerillaBlock[], FieldInfo> ) parentNode.Tag;
            var tempList = new List<GuerillaBlock>( tag.Item2.Concat( Enumerable.Repeat( element, count ) ) );

            #region hacky 

            var method = typeof ( GuerillaBlockPropertyViewer )
                .GetMethod( "Convert", BindingFlags.Static | BindingFlags.NonPublic );
            method = method.MakeGenericMethod( tag.Item3.FieldType.GetElementType( ) );

            var t = method.Invoke( null, new object[] {tempList.ToArray( )} );

            #endregion

            tag.Item3.SetValue( tag.Item1, t );
            LoadGuerillaBlocks( _guerillaBlock );
        }

        /// <summary>
        /// We use this hack because FieldInfo.SetValue won't implicitly find the right converter
        /// </summary>
        /// <typeparam name="T">The type of the element to convert to</typeparam>
        /// <param name="input">The array holding the lements to convert</param>
        /// <returns>An array of type T</returns>
        private static T[] Convert<T>( dynamic[] input )
        {
            var t = new T[input.Length];
            for ( int i = 0; i < input.Length; i++ )
            {
                t[ i ] = ( T ) input[ i ];
            }
            return t;
        }

        private void clonemanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox inputBox = new InputBox(  );
            if ( inputBox.ShowDialog( this ) == DialogResult.OK )
            {
                var value = inputBox.Value;
                if ( value <= 0 ) return;
                Clone( value );
            }
        }

    };
}
