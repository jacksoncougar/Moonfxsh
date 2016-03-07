using System;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Cache;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class TagDatumView : DockContent
    {
        public TagDatumView( )
        {
            InitializeComponent( );
            treeView1.NodeMouseDoubleClick += ( sender, args ) =>
            {
                if ( NodeMouseDoubleClick != null )
                    NodeMouseDoubleClick( sender, args );
            };

        }

        public TreeNode SelectedNode
        {
            get { return treeView1.SelectedNode; }
        }

        public event EventHandler NodeMouseDoubleClick;

        internal void LoadTagDatums( TagIndex tagIndex )
        {
            var classes = tagIndex.ClassHeirarchies.Select( x => x.Class );
            treeView1.SuspendLayout( );
            foreach ( var tagClass in classes )
            {
                var tags = tagIndex.Where( tagClass ).ToArray( );
                if ( tags.Length <= 0 ) continue;

                var node = new TreeNode( tagClass.ToString( ) );
                var childrenNodes = new TreeNode[tags.Length];
                for ( var index = 0; index < tags.Length; index++ )
                {
                    var tagDatum = tags[ index ];
                    childrenNodes[ index ] = new TreeNode( tagDatum.Path )
                    {
                        Tag = tagDatum
                    };
                }
                node.Nodes.AddRange( childrenNodes );
                treeView1.Nodes.Add( node );
            }
            treeView1.ResumeLayout( );
        }
    };
}
