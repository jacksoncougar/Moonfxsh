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
using Moonfish.Guerilla;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class DatumViewer : Form
    {
        private CacheStream _cacheStream;

        public DatumViewer( )
        {
            InitializeComponent( );

            _cacheStream = new CacheStream(Path.Combine( Local.MapsDirectory, "headlong.map" ) );
            var objectListView = new TagDatumView( );
            var guerillaPropertyView = new GuerillaBlockPropertyViewer( );

            objectListView.LoadTagDatums( _cacheStream.Index );
            objectListView.NodeMouseDoubleClick += ( sender, args ) =>
            {
                if ( objectListView.SelectedNode != null && objectListView.SelectedNode.Tag is TagDatum )
                {
                    var guerillaBlock = _cacheStream.Deserialize( ( ( TagDatum ) objectListView.SelectedNode.Tag ).Identifier );
                    guerillaPropertyView.LoadGuerillaBlocks( guerillaBlock );
                }
            };

            guerillaPropertyView.Show( dockPanel1, DockState.Document );

            objectListView.Show( dockPanel1, DockState.DockLeft );
        }
    }
}
