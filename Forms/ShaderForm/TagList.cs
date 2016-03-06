using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms.ShaderForm
{
    public partial class TagList : DockContent
    {
        public event TreeNodeMouseClickEventHandler NodeMouseClick
        {
            add { treeView1.NodeMouseClick += value; }
            remove { treeView1.NodeMouseClick -= value; }
        }

        public TagList( )
        {
            InitializeComponent();
        }

        public new void Load( List<TagDatum> tags )
        {
            var classes = tags.Select( u => u.Class ).Distinct( ).ToList(  );
            var classNodeDictionary = new Dictionary<TagClass, ClassTreeNode>( classes.Count );
            foreach ( var @class in classes )
            {
                var node = new ClassTreeNode( @class );
                classNodeDictionary.Add( @class, node );
            }
            foreach ( var tag in tags )
            {
                var node = new TagTreeNode( tag );
                var parent = classNodeDictionary[ tag.Class ];
                parent.Nodes.Add( node );
            }
            var nodes = classNodeDictionary.Values.ToArray( );
            foreach ( var node in nodes )
            {
                node.Expand(  );
            }
            treeView1.Nodes.AddRange(nodes);
        }
    }
}
