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
        public new event EventHandler<TagIdent> MouseDoubleClick;
        public event EventHandler<TagIdent> OnSelectedObjectChanged;

        public TagIdent SelectedObjectIdent { get; private set; }

        public ObjectListView( )
        {
            SelectedObjectIdent = TagIdent.NullIdentifier;
            InitializeComponent( );
            listView1.MouseDoubleClick +=
                delegate
                {
                    if ( MouseDoubleClick != null )
                        MouseDoubleClick( this, SelectedObjectIdent );
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

                    var data = ( TagDatum ) listView1.Items[ index ].Tag;
                    SelectedObjectIdent = data.Identifier;
                    if ( OnSelectedObjectChanged != null ) OnSelectedObjectChanged( this, SelectedObjectIdent );
                };
        }

        public void LoadScenarioPallet( CacheStream cacheStream )
        {
            var scenery = cacheStream.Index.Where( TagClass.Scen );
            var crates = cacheStream.Index.Where( TagClass.Bloc );
            var weapons = cacheStream.Index.Where( TagClass.Weap );
            var netgame = cacheStream.Index.Where( TagClass.Itmc );
            var machines = cacheStream.Index.Where( TagClass.Mach );

            AddListViewItems( scenery, new ListViewGroup(
                "Scenery", HorizontalAlignment.Left ) );
            AddListViewItems( crates, new ListViewGroup(
                "Crates", HorizontalAlignment.Left ) );
            AddListViewItems( weapons, new ListViewGroup(
                "Weapons", HorizontalAlignment.Left));
            AddListViewItems(netgame, new ListViewGroup(
                "NetGame", HorizontalAlignment.Left));
            AddListViewItems(machines, new ListViewGroup(
                "Machines", HorizontalAlignment.Left));
        }

        public void AddListViewItems( IEnumerable<TagDatum> tagDatums, ListViewGroup listViewGroup )
        {
            listView1.Groups.Add( listViewGroup );
            foreach ( var tagDatum in tagDatums )
            {
                listView1.Items.Add( new ListViewItem( tagDatum.Identifier.Index.ToString( ) )
                {
                    Group = listViewGroup,
                    SubItems = {tagDatum.Identifier.ToString( )},
                    Tag = tagDatum
                } );
            }
        }
    };
}
