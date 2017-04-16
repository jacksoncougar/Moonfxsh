using System.Dynamic;
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
        private readonly Map _cacheStream;
        private SceneView _sceneView;
        private MoonfxshExplorer _moonfxshExplorerForm;

        public MainForm( )
        {
            InitializeComponent( );

            //dockPanel1.Theme = new VS2013BlueTheme( );


            var fileName = Path.Combine( Local.MapsDirectory, "ascension.map" );

			//if (!File.Exists(fileName)) //return;

            var directory = Path.GetDirectoryName(fileName);
				if (!string.IsNullOrEmpty(directory))
				{
					//var maps = Directory.GetFiles(directory, "*.map", SearchOption.TopDirectoryOnly);
					//var resourceMaps = maps.GroupBy(
					//	Halo2.CheckMapType
					//	).Where(x => x.Key == MapType.Shared || x.Key == MapType.MainMenu
					//				 || x.Key == MapType.SinglePlayerShared)
					//	.Select(g => g.First()).ToList();
					//resourceMaps.ForEach(x =>
					//   Solution.Index.AddCache(CacheStream.Open(x)));
				}
				//Solution.Index.AddCache(CacheStream.Open(fileName));
				//_cacheStream = CacheStream.Open(fileName);

				//dockPanel1.DockBottomPortion = 350f;

				//_sceneView = new SceneView();

				//_moonfxshExplorerForm = new MoonfxshExplorer();

				//_sceneView.SceneInitialized += delegate
				//{
				//	_moonfxshExplorerForm.LoadTags(_cacheStream.ToArray());
				//	Solution.SetScenario((ScenarioBlock)_cacheStream.Index.ScenarioIdent.Get(_cacheStream.GetKey()));

				//	_sceneView.Scene.OnFrameReady += delegate
				//	{
				//		this.Text = $@"{1 / _sceneView.SceneClock.frameTime:#.###} Update:{ _sceneView.SceneClock.updateTime}";
				//	};
				//};
			
            //_moonfxshExplorerForm.TagItemDoubleClick += ( sender, reference ) => EditTag( reference );
            //_sceneView.Show( dockPanel1, DockState.Document );
 			//_moonfxshExplorerForm.Show( dockPanel1, DockState.DockBottom );
        }


        private void EditTag( TagDatum reference)
        {
            if ( reference.Class == TagClass.Bitm )
            {
            }
            if ( reference.Class == TagClass.Scen || reference.Class == TagClass.Bloc ||
                 reference.Class == TagClass.Vehi || reference.Class == TagClass.Bipd ||
                 reference.Class == TagClass.Crea || reference.Class == TagClass.Ctrl ||
                 reference.Class == TagClass.Mach || reference.Class == TagClass.Unit ||
                 reference.Class == TagClass.Weap )
            {
            }
            
        }

        private void existingCacheToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog( );
            if(dialog.ShowDialog() != DialogResult.OK) return;

            var filename = dialog.FileName;
            if ( filename.EndsWith( ".map" ) )
            {
                // Solution.Index.AddCache( filename, out key );
            }
        }
    }
}