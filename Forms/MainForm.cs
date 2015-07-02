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
using Moonfish.Guerilla.Tags;
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
            var objectListView = new ObjectListView();

            CacheStream resourceCache;
            if (Halo2.TryGettingResourceStream(Halo2.ResourceSource.Shared, out resourceCache))
            {
                CopyTagsFromResourceStream(resourceCache, ref _cacheStream);
            }
            if (Halo2.TryGettingResourceStream(Halo2.ResourceSource.MainMenu, out resourceCache))
            {
                CopyTagsFromResourceStream(resourceCache, ref _cacheStream);
            }
            if (Halo2.TryGettingResourceStream(Halo2.ResourceSource.SinglePlayerShared, out resourceCache))
            {
                CopyTagsFromResourceStream(resourceCache, ref _cacheStream);
            }

            objectListView.LoadScenarioPallet(_cacheStream);

            objectListView.Show(dockPanel1, DockState.DockLeft);
            objectListView.MouseDoubleClick +=
                delegate( object sender, TagIdent ident ) { sceneView.AddSceneObject( ident ); };
        }

        private void CopyTagsFromResourceStream( CacheStream resourceCache, ref CacheStream cacheStream )
        {
            foreach ( var tagDatum in resourceCache.Index.Where( TagClass.Scen ) )
            {
                if ( _cacheStream.Index.Any( x => x.Class == tagDatum.Class && x.Path == tagDatum.Path ) ) continue;
                cacheStream.Add((SceneryBlock)resourceCache.Deserialize(tagDatum.Identifier), tagDatum.Path);
            }
            foreach ( var tagDatum in resourceCache.Index.Where( TagClass.Weap ) )
            {
                if ( _cacheStream.Index.Any( x => x.Class == tagDatum.Class && x.Path == tagDatum.Path ) ) continue;
                cacheStream.Add((WeaponBlock)resourceCache.Deserialize(tagDatum.Identifier), tagDatum.Path);
            }
            foreach ( var tagDatum in resourceCache.Index.Where( TagClass.Bloc ) )
            {
                if ( _cacheStream.Index.Any( x => x.Class == tagDatum.Class && x.Path == tagDatum.Path ) ) continue;
                cacheStream.Add((CrateBlock)resourceCache.Deserialize(tagDatum.Identifier), tagDatum.Path);
            }
            foreach ( var tagDatum in resourceCache.Index.Where( TagClass.Mach ) )
            {
                if ( _cacheStream.Index.Any( x => x.Class == tagDatum.Class && x.Path == tagDatum.Path ) ) continue;
                cacheStream.Add((DeviceMachineBlock)resourceCache.Deserialize(tagDatum.Identifier), tagDatum.Path);
            }
        }
    }
}
