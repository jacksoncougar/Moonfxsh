using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;
using Moonfish;

namespace Sunfish.Forms
{
    /// <summary>
    ///     A file explorer control for viewing tags and resources
    /// </summary>
    /// <remarks>
    ///     TODO This should be expanded to allow an entire project to be maintained and explored.
    /// </remarks>
    public partial class MoonfxshExplorer : DockContent
    {
        public MoonfxshExplorer( )
        {
            InitializeComponent( );

            // Setup some properties of ListView here
            SetupDetailsView();
            (toolStripButton3 as IBindableComponent).DataBindings.Add("Text", listView1, "View");

            // WPF interop Events
            navigationBar1.AddressSubmitted += ( sender, e ) => { scenarioView1.SelectDirectoryNode( e ); };
            navigationBar1.SearchSubmitted += ( sender, e ) => { Search( e ); };
        }

        /// <summary>
        ///     Loads an array of TagDatums
        /// </summary>
        /// <param name="tagReferences">The array of tagDatums to load</param>
        /// <remarks>
        ///     The TagDatums contain all the information about the tag objects that they represent,
        ///     so it is akin to loading a file system. In the future this may be refactored to just take a TagIndex directly
        /// </remarks>
        public void LoadTags( TagDatum[] tagReferences )
        {
            scenarioView1.LoadReferences( tagReferences );
        }

        /// <summary>
        ///     Occurs when a Tag item is double clicked
        /// </summary>
        /// <remarks>
        ///     This should fire regardless of where the tag item is located: ie treeview, or taglist
        /// </remarks>
        public event EventHandler<TagReference> TagItemDoubleClick;

        class FuncEqualityComparer<T> : IEqualityComparer<T>
        {
            readonly Func<T, T, bool> _comparer;
            readonly Func<T, int> _hash;

            public FuncEqualityComparer( Func<T, T, bool> comparer )
                : this( comparer, t => 0 )
                // NB Cannot assume anything about how e.g., t.GetHashCode() interacts with the comparer's behavior
            {
            }

            public FuncEqualityComparer( Func<T, T, bool> comparer, Func<T, int> hash )
            {
                _comparer = comparer;
                _hash = hash;
            }

            public bool Equals( T x, T y )
            {
                return _comparer( x, y );
            }

            public int GetHashCode( T obj )
            {
                return _hash( obj );
            }
        }

        /// <summary>
            ///     Lists items and sub-directories within the directory.
            /// </summary>
            /// <param name="path">The directory path</param>
            private void ListDirectory( string path )
        {
            listView1.BeginUpdate();
            listView1.Items.Clear();

            IEnumerable<TagDatum> references;
            if ( path == CachePath.CacheRoot )
            {
                references = scenarioView1.References;
            }
            else
            {
                references = scenarioView1.References.Where(
                    u => u.Path.StartsWith( path ) || u.Path == path );
            }

            SortedSet<ListViewItem> items =
                new SortedSet<ListViewItem>(Comparer<ListViewItem>.Create((u, v) =>
                {
                    var uType = u.GetType();
                    var vType = v.GetType();
                    var compareType = uType.Name.CompareTo(vType.Name);
                    if (compareType != 0) return compareType;
                    var compareName = u.Name.CompareTo(v.Name);
                    return compareName;
                }));
            
            foreach ( var reference in references )
            {
                var tagPath = reference.Path;
                var directory = CachePath.GetDirectoryName( tagPath ) ?? string.Empty;

                // This item is a tag
                if (directory == path )
                    items.Add( new TagReferenceListViewItem(reference));
                // This item is a directory
                else
                {
                    directory = directory.Remove( 0, path.Length );
                    var split = directory.Split( new[] {Path.DirectorySeparatorChar},
                        StringSplitOptions.RemoveEmptyEntries );
                    if ( split.Length < 1 ) continue;
                    directory = split[ 0 ];
                    var fullPath = CachePath.Combine( path, directory );

                    items.Add(new DirectoryListViewItem(directory, fullPath, 1));

                }
            }
            listView1.Items.AddRange( items.ToArray( ) );
            listView1.EndUpdate(  );
        }

        private void listView1_MouseDoubleClick( object sender, MouseEventArgs e )
        {
            var item = listView1.GetItemAt( e.X, e.Y );
            var directoryItem = item as DirectoryListViewItem;
            var referenceItem = item as TagReferenceListViewItem;

            if ( directoryItem != null )
                scenarioView1.SelectDirectoryNode( directoryItem.Path );

            if ( referenceItem != null )
                TagItemDoubleClick?.Invoke( this, referenceItem.Reference );
        }

        private void scenarioView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            var directoryNode = e.Node as ScenarioView.DirectoryNode;
            if ( directoryNode == null ) return;

            ListDirectory( directoryNode.Path );
            navigationBar1.DisplayPath( directoryNode.Path );
        }

        private void scenarioView1_NodeMouseDoubleClick( object sender, TreeNodeMouseClickEventArgs e )
        {
            var guerillaBlockReference = e.Node as ScenarioView.GuerillaBlockReferenceNode;
            if ( guerillaBlockReference == null ) return;

            var tagClass = guerillaBlockReference.BlockClass;
            var tagIdent = guerillaBlockReference.BlockIdent;
            TagItemDoubleClick?.Invoke( this, new TagReference( tagClass, tagIdent ) );
        }

        /// <summary>
        ///     Lists search results returned by <paramref name="searchTerm" />
        /// </summary>
        /// <param name="searchTerm">The path fragment or tag-class to search for</param>
        /// <remarks>
        ///     Class searching takes presedence.
        ///     Searching for a class can be done by passing the string representation of that class: i.e "stem", "bitm"
        ///     Searching for a path can be done by passing the string that the path should contain
        /// </remarks>
        private void Search( string searchTerm )
        {
            if ( searchTerm == string.Empty ) return;
            scenarioView1.SelectedNode = null;
            navigationBar1.AddressBox.Text = "Search Results in Cache";

            listView1.Items.Clear();

            IEnumerable<TagDatum> references;
            var isClass = Halo2.Classes.Any( u => u == searchTerm );
            if ( isClass )
            {
                var searchClass = new TagClass( searchTerm );
                references = scenarioView1.References.Where( u => u.Class == searchClass );
            }
            else
            {
                references = scenarioView1.References.Where( u => u.Identifier.GetPath( ).Contains( searchTerm ) );
            }
            foreach ( var reference in references )
            {
                // This item is a tag
                listView1.Items.Add( new TagReferenceListViewItem( reference ) );
            }
        }

        /// <summary>
        ///     Configures <see cref="listView1" /> to display details of items
        /// </summary>
        private void SetupDetailsView( )
        {
            listView1.View = View.Details;
            listView1.SmallImageList = tinyIcons;
            listView1.Columns.Add( "Name", 350 );
            listView1.Columns.Add( "Class" );
            listView1.Columns.Add( "Size" );
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            scenarioView1.Mode = ScenarioView.DisplayMode.Hierarchical;
        }

        private void toolStripButton2_Click( object sender, EventArgs e )
        {
            scenarioView1.Mode = ScenarioView.DisplayMode.Class;
        }

        private void toolStripButton3_Click( object sender, EventArgs e )
        {
            var currentView = ( int ) listView1.View;
            var nextView = ( currentView + 1 ) % 5;
            listView1.View = ( View ) nextView;
        }

        /// <summary>
        ///     A <see cref="ListViewItem" /> item that represents a tag reference
        /// </summary>
        public class TagReferenceListViewItem : ListViewItem
        {
            public TagReferenceListViewItem( TagDatum datum, int imageIndex = 0 )
            {
                Reference = new TagReference( datum.Class, datum.Identifier );
                Name = Path.ChangeExtension(datum.Identifier.GetPath(), datum.Class.ToString());
                Text = Path.ChangeExtension( Path.GetFileName( datum.Identifier.GetPath( ) ),
                    datum.Class.ToString( ) );
                ImageIndex = imageIndex;
                SubItems.AddRange( new[]
                {
                    datum.Class.ToString( ),
                    datum.Length.ToString( )
                } );
            }

            /// <summary>
            ///     Reference of tag
            /// </summary>
            public TagReference Reference { get; }
        };

        /// <summary>
        ///     A <see cref="ListViewItem" /> item that represents a directory
        /// </summary>
        public class DirectoryListViewItem : ListViewItem
        {
            public DirectoryListViewItem( string text, string path, int imageIndex )
            {
                Text = text;
                Path = Name = path;
                ImageIndex = imageIndex;
            }

            /// <summary>
            ///     Fullpath of directory
            /// </summary>
            public string Path { get; }
        }
    }
}