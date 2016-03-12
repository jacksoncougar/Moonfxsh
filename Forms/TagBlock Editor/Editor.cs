using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms.TagBlock_Editor
{
    public partial class MoonfxshExplorer : DockContent
    {
        public event EventHandler<TagReference> TagItemDoubleClick;

        public MoonfxshExplorer( )
        {
            InitializeComponent( );
            //var addressbar = (elementHost1.Child as Addressbar);
            //if ( addressbar != null )
            //    addressbar.AddressSubmitted += ( sender, path ) =>
            //    {
            //        scenarioView1.SelectDirectoryNode( path );
            //    };
        }

        public void LoadTags( TagReference[] tagReferences )
        {
            scenarioView1.LoadReferences( tagReferences );
        }

        private void scenarioView1_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
        {
            var guerillaBlockReference = e.Node as ScenarioView.GuerillaBlockReferenceNode;
            if ( guerillaBlockReference == null ) return;

            var tagClass = guerillaBlockReference.BlockClass;
            var tagIdent = guerillaBlockReference.BlockIdent;
            TagItemDoubleClick?.Invoke( this, new TagReference( tagClass, tagIdent ) );
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            scenarioView1.Mode = ScenarioView.DisplayMode.Hierarchical;
        }

        private void toolStripButton2_Click( object sender, EventArgs e )
        {
            scenarioView1.Mode = ScenarioView.DisplayMode.Class;
        }

        private void scenarioView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            var directoryNode = e.Node as ScenarioView.DirectoryNode;
            if ( directoryNode == null ) return;

            DisplayDirectoryItems( directoryNode.Path );
           // (elementHost1.Child as Addressbar).DisplayPath( directoryNode.Path );
        }

        private void DisplayDirectoryItems( string path )
        {
            listView1.Clear( );
            var references = path == "cache:"
                ? scenarioView1.References
                : scenarioView1.References.Where( u => u.Ident.GetPath( ).StartsWith( path ) || u.Ident.GetPath( ) == path );
            path = path == "cache:" ? "" : path;
            foreach ( var reference in references )
            {
                var tagPath = reference.Ident.GetPath( );
                var directory = Path.GetDirectoryName( tagPath ) ?? string.Empty;

                // This item is a tag
                if ( directory == path )
                    listView1.Items.Add( new TagReferenceListViewItem( reference, 0 ) );
                // This item is a directory
                else
                {
                    directory = directory.Remove( 0, path.Length );
                    var split = directory.Split( new[] {Path.DirectorySeparatorChar},
                        StringSplitOptions.RemoveEmptyEntries );
                    if ( split.Length < 1 ) continue;
                    directory = split[ 0 ];
                    var fullPath = Path.Combine(path, directory);
                    if ( !listView1.Items.ContainsKey(fullPath) )
                    {
                        listView1.Items.Add( new DirectoryListViewItem( directory, fullPath, 1 ) );
                    }
                }
            }
        }

        public class TagReferenceListViewItem : ListViewItem
        {
            public TagReference Reference { get; }

            public TagReferenceListViewItem( TagReference reference, int imageIndex = 0 )
            {
                Reference = reference;
                Name = reference.Ident.GetPath( );
                Text = Path.ChangeExtension( Path.GetFileName( reference.Ident.GetPath( ) ),
                    reference.Class.ToString( ) );
                ImageIndex = imageIndex;
                SubItems.AddRange(
                    new[] {"test", "apple", "orange", "12"}
                    );
            }
        }

        public class DirectoryListViewItem : ListViewItem
        {
            public string Path { get; }

            public DirectoryListViewItem( string text, string path, int imageIndex )
            {
                Text = text;
                Path = Name = path;
                ImageIndex = imageIndex;
                SubItems.AddRange(
                    new[] { "test", "apple", "orange", "12" }
                    );
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var currentView = (int)listView1.View;
            var nextView = ( currentView + 1 ) % 5;
            listView1.View = ( View ) nextView;
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var item = listView1.GetItemAt( e.X, e.Y );
            var directoryItem = item as DirectoryListViewItem;
            var referenceItem = item as TagReferenceListViewItem;

            if ( directoryItem != null )
                scenarioView1.SelectDirectoryNode( directoryItem.Path );

            if (referenceItem != null )
                TagItemDoubleClick?.Invoke( this, referenceItem.Reference );

        }
    }
}
