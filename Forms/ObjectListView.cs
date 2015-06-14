using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moonfish.Cache;
using Moonfish.Graphics;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;
using WeifenLuo.WinFormsUI.Docking;

namespace Moonfish.Forms
{
    public partial class ObjectListView : DockContent
    {
        public event EventHandler<TagIdent> MouseDoubleClick;
        public event EventHandler<TagIdent> SelectedObjectChanged;

        public TagIdent SelectedObjectIdent { get; private set; }

        public ObjectListView( )
        {
            SelectedObjectIdent = TagIdent.NullIdentifier;
            InitializeComponent();
            listView1.MouseDoubleClick +=
                delegate
                {
                    if (MouseDoubleClick != null)
                        MouseDoubleClick(this, SelectedObjectIdent);
                };

            listView1.SelectedIndexChanged +=
                delegate
                {
                    var index = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[ 0 ] : -1;
                    if ( index < 0 )
                    {
                        SelectedObjectIdent = TagIdent.NullIdentifier;
                        return;
                    }
                    
                    var palette = listView1.Items[ index ].Tag as IH2ObjectPalette;

                    if ( palette == null ) return;

                    SelectedObjectIdent = palette.ObjectReference.Ident;
                    if ( SelectedObjectChanged != null ) SelectedObjectChanged( this, SelectedObjectIdent );
                };
        }

        public void LoadScenarioPallet( CacheStream cacheStream )
        {
            var ident = cacheStream.Index.Select( ( TagClass ) "scnr", "" ).First( ).Identifier;
            var scenario = ( ScenarioBlock ) cacheStream.Deserialize( ident );

            var scenery =
                scenario.SceneryPalette.Where( x => x.Name.Ident != TagIdent.NullIdentifier )
                    .Select( x => ( IH2ObjectPalette ) x )
                    .ToList( );
            var crates =
                scenario.CratesPalette.Where( x => x.Name.Ident != TagIdent.NullIdentifier )
                    .Select( x => ( IH2ObjectPalette ) x )
                    .ToList( );
            var weapons =
                scenario.WeaponPalette.Where( x => x.Name.Ident != TagIdent.NullIdentifier )
                    .Select( x => ( IH2ObjectPalette ) x )
                    .ToList( );
            var netgame =
                scenario.NetgameEquipment.GroupBy( x => x.ItemVehicleCollection.Ident )
                    .Select( x => x.First( ) )
                    .Where( x => x.ItemVehicleCollection.Ident != TagIdent.NullIdentifier )
                    .Select( x => ( IH2ObjectPalette ) x )
                    .ToList( );

            AddListViewItems( scenery, new ListViewGroup(
                "Scenery", HorizontalAlignment.Left ) );
            AddListViewItems( crates, new ListViewGroup(
                "Crates", HorizontalAlignment.Left ) );
            AddListViewItems( weapons, new ListViewGroup(
                "Weapons", HorizontalAlignment.Left ) );
            AddListViewItems( netgame, new ListViewGroup(
                "NetGame", HorizontalAlignment.Left ) );
        }

        private void AddListViewItems( List<IH2ObjectPalette> scenery, ListViewGroup listViewGroup )
        {
            listView1.Groups.Add( listViewGroup );
            scenery.ForEach( x => listView1.Items.Add( new ListViewItem( x.ObjectReference.Ident.Index.ToString( ) )
            {
                Group = listViewGroup,
                SubItems = {x.ObjectReference.Ident.ToString( )},
                Tag = x
            } ) );
        }
    };
}
