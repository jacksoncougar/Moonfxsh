﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Tags;

namespace Moonfish.Forms
{
    public partial class ScenarioView : TreeView
    {
        public enum DisplayMode
        {
            Hierarchical,
            Class
        }

        public readonly List<TagReference>  References = new List<TagReference>();

        private static readonly Comparer<TagReference> PathComparer = Comparer<TagReference>.Create(
            ( u, v ) =>
                string.Compare( Halo2.Paths[ u.Ident.Index ], Halo2.Paths[ v.Ident.Index ], StringComparison.Ordinal ) );

        private static readonly Comparer<TagReference> ClassComparer = Comparer<TagReference>.Create(
            ( u, v ) =>
            {
                var result = string.Compare( u.Class.ToString( ), v.Class.ToString( ), StringComparison.Ordinal );
                return result == 0 ? PathComparer.Compare( u, v ) : result;
            } );

        private DisplayMode _displayMode;

        public ScenarioView( )
        {
            InitializeComponent( );
        }

        public DisplayMode Mode
        {
            get { return _displayMode; }
            set
            {
                if ( _displayMode == value ) return;
                _displayMode = value;
                OnDisplayModeChanged( );
            }
        }

        public void LoadReferences( TagReference[] references )
        {
            if ( references == null )
                return;

            References.AddRange( references );
            References.Sort(ClassComparer);
            Display(References);
        }

        private void Display( List<TagReference> references )
        {
            if ( Mode == DisplayMode.Hierarchical )
                DisplayHierarchical( references );
            if ( Mode == DisplayMode.Class )
                DisplayClasses( references );
        }

        private void DisplayClasses( IEnumerable<TagReference> references, bool loadTags = false )
        {
            var lookup = new Dictionary<TagClass, TreeNode>( );
            foreach ( var reference in references )
            {
                var path = Halo2.Paths[ reference.Ident.Index ];
                var tagClass = reference.Class;
                var @class = ( string ) tagClass;

                // Don't process empty classes
                if ( tagClass == TagClass.Empty )
                    continue;

                if ( !lookup.ContainsKey( tagClass ) )
                    lookup.Add( tagClass, new ScenarioView.DirectoryNode( @class, @class ) );

                if ( !loadTags )
                    continue;

                var node = new ScenarioView.GuerillaBlockReferenceNode( path, path, reference );
                lookup[ tagClass ].Nodes.Add( node );
            }
            BeginUpdate(  );
            Nodes.Clear( );
            Nodes.AddRange( lookup.Values.ToArray( ) );
            EndUpdate(  );
        }

        private void DisplayHierarchical( IEnumerable<TagReference> references, bool loadTags = false)
        {
            BeginUpdate();
            Nodes.Clear( );

            var rootNode = new DirectoryNode( "root", "cache:");
            foreach ( var reference in references )
            {
                var path = Halo2.Paths[ reference.Ident.Index ];
                var directories = path.Split( new[] {@"\"}, StringSplitOptions.RemoveEmptyEntries );
                var length = path.IndexOf('\\');

                // Don't process empty arrays
                if ( directories.Length <= 0 )
                    continue;

                var collection = rootNode.Nodes;

                // Loop through all elements of array except the last one
                var lastElementIndex = directories.Length - 1;
                for ( var index = 0; index < lastElementIndex; index++ )
                {
                    var dir = directories[ index ];
                    var fullDirectory = path.Substring( 0, length );
                    var directoryNode = new ScenarioView.DirectoryNode( dir, fullDirectory);
                    if ( !collection.ContainsKey( directoryNode.Name ) ) collection.Add( directoryNode );
                    collection = collection[ directoryNode.Name ].Nodes;

                    var indexOf = path.IndexOf( '\\', length + 1 );
                    length = indexOf < 0 ? path.Length : indexOf;
                }
                if ( !loadTags )
                    continue;

                // Do special work on the last element:
                var text = directories[ lastElementIndex ];
                var guerillaBlockNode = new ScenarioView.GuerillaBlockReferenceNode( path, text, reference );
                if ( !collection.ContainsKey( guerillaBlockNode.Name ) ) collection.Add( guerillaBlockNode );
            }
            Nodes.Add( rootNode );
            EndUpdate();
        }
        
        private void OnDisplayModeChanged( )
        {
            Display( References );
        }


        public class GuerillaBlockReferenceNode : TreeNode
        {
            public GuerillaBlockReferenceNode( string name, string text, TagReference reference )
            {
                Text = Path.ChangeExtension( text, reference.Class.ToString( ) );
                Name = Path.ChangeExtension( name, reference.Class.ToString( ) );
                BlockIdent = reference.Ident;
                BlockClass = reference.Class;
            }

            public TagClass BlockClass { get; }
            public TagIdent BlockIdent { get; }
        }

        /// <summary>
        ///     Represents a directory node of a <see cref="ScenarioView" />
        /// </summary>
        public class DirectoryNode : TreeNode
        {
            public DirectoryNode( string text, string path )
            {
                Text = text;
                Path = Name = path;

                ToolTipText = Path;
            }

            public string Path { get; }
        }

        public void SelectDirectoryNode( string path )
        {
            if ( path == "cache:" )
            {
                SelectedNode = Nodes[ 0 ];
                return;
            }
            var collection = Nodes[0].Nodes;
            
            foreach ( var directoryName in CachePath.ForeachDirectory( path ) )
            {
                if ( !collection.ContainsKey( directoryName ) ) return;
                collection[directoryName].Expand(  );
                SelectedNode = collection[ directoryName ];
                collection = collection[ directoryName ].Nodes;
            }
        }
    }
}