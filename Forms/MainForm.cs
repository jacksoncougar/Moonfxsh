using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class MainForm : Form
    {
        private CacheStream _cacheStream;

        public MainForm()
        {
            _cacheStream = CacheStream.Open( Path.Combine( Local.MapsDirectory, "headlong.map" ) );
            InitializeComponent();
            var sceneView = new SceneView( _cacheStream );
            sceneView.Show(dockPanel1, DockState.Document);
            var objectListView = new ObjectListView( );
            objectListView.LoadScenarioPallet( _cacheStream );
            objectListView.Show(dockPanel1, DockState.DockLeft);
            objectListView.MouseDoubleClick +=
                delegate( object sender, TagIdent ident ) { sceneView.AddSceneObject( ident ); };
        }
    }
}
