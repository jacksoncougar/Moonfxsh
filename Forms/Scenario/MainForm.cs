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

            dockPanel1.Theme = new VS2013BlueTheme(  );

            _cacheStream = CacheStream.Open( Path.Combine( Local.MapsDirectory, "ascension.map" ) );
            
            var sceneView = new SceneView( _cacheStream );
            var objectListView = new ObjectListView( );

            objectListView.OnSelectedObjectChanged += delegate
            {
            };
            

            objectListView.LoadScenarioPallet( _cacheStream );
            
            sceneView.Show( dockPanel1, DockState.Document );
            objectListView.Show( dockPanel1, DockState.DockLeft );
        }
    }
}