using System.IO;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Guerilla;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class MainForm : Form
    {
        private readonly CacheStream _cacheStream;

        public MainForm( )
        {
            InitializeComponent( );

            _cacheStream = CacheStream.Open( Path.Combine( Local.MapsDirectory, "ascension.map" ) );

            var blockPropertyViewer = new GuerillaBlockPropertyViewer( );
            var sceneView = new SceneView( _cacheStream );
            var objectListView = new ObjectListView( );

            objectListView.SelectedObjectChanged += delegate
            {
                blockPropertyViewer.LoadGuerillaBlocks(
                    ( GuerillaBlock ) objectListView.SelectedObjectIdent.Get<ObjectBlock>(  ) );
            };
            

            objectListView.LoadScenarioPallet( _cacheStream );

            blockPropertyViewer.Show( dockPanel1, DockState.DockRight );
            sceneView.Show( dockPanel1, DockState.Document );
            objectListView.Show( dockPanel1, DockState.DockLeft );
        }
    }
}