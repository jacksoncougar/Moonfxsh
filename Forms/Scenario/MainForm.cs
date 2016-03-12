using System.IO;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Forms.TagBlock_Editor;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class MainForm : Form
    {
        private readonly CacheStream _cacheStream;
        private SceneView _sceneView;
        private MoonfxshExplorer _moonfxshExplorerForm;

        public MainForm( )
        {
            InitializeComponent( );

            dockPanel1.Theme = new VS2013BlueTheme( );

            _cacheStream = CacheStream.Open( Path.Combine( Local.MapsDirectory, "ascension.map" ) );
            var objectBlock = (GuerillaBlock)
                _cacheStream.Index.First( u => u.Class == TagClass.Scnr && u.Path.Contains( "scen" ) )
                    .Identifier.Get( );

            dockPanel1.DockBottomPortion = 350f;

            _sceneView = new SceneView( _cacheStream );
            _moonfxshExplorerForm = new MoonfxshExplorer( );
            _moonfxshExplorerForm.LoadTags( _cacheStream.Index.Select( u => new TagReference( u.Class, u.Identifier ) ).ToArray(  ));
            _moonfxshExplorerForm.TagItemDoubleClick += ( sender, reference ) => EditTag( reference );
            _sceneView.Show(dockPanel1, DockState.Document);
            _moonfxshExplorerForm.Show( dockPanel1, DockState.DockBottom );
        }

        private void EditTag( TagReference reference )
        {
            if ( reference.Class == TagClass.Scen )
            {
                _sceneView.Scene.Manager.Load( (ObjectBlock)reference.Get(  ) );
            }
        }
    }
}