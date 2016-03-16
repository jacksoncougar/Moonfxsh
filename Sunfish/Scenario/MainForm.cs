using System.IO;
using System.Linq;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;
using Moonfish;

namespace Sunfish.Forms
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

            _cacheStream = CacheStream.Open( Path.Combine( Local.MapsDirectory, "05b_deltatowers.nomap" ) );

            dockPanel1.DockBottomPortion = 350f;

            _sceneView = new SceneView( _cacheStream );
            _moonfxshExplorerForm = new MoonfxshExplorer( );
            _moonfxshExplorerForm.LoadTags( _cacheStream.Index.ToArray( ) );
            _moonfxshExplorerForm.TagItemDoubleClick += ( sender, reference ) => EditTag( reference );
            _sceneView.Show( dockPanel1, DockState.Document );
            _moonfxshExplorerForm.Show( dockPanel1, DockState.DockBottom );
        }

        private void EditTag( TagReference reference )
        {
            if ( reference.Class == TagClass.Bitm )
            {
                _sceneView.Scene.Manager.Load((BitmapBlock)reference.Get());
            }
            if ( reference.Class == TagClass.Scen || reference.Class == TagClass.Bloc ||
                 reference.Class == TagClass.Vehi || reference.Class == TagClass.Bipd ||
                 reference.Class == TagClass.Crea || reference.Class == TagClass.Ctrl ||
                 reference.Class == TagClass.Mach || reference.Class == TagClass.Unit ||
                 reference.Class == TagClass.Weap )
                _sceneView.Scene.Manager.Load( ( ObjectBlock ) reference.Get( ) );

            _sceneView.Scene.Manager.Load( ( ObjectBlock ) reference.Get( ) );
        }
    }
}