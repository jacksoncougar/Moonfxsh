using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Moonfish.Guerilla;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Forms
{
    public partial class Research : Form
    {
        public Research()
        {
            InitializeComponent();
            var items = new SortedSet<object>( Comparer<object>.Create(( a, b ) =>
            {
                dynamic o1 = a;
                dynamic o2 = b;
                return o1.Type.CompareTo( o2.Type ) == 0
                    ? o1.SourceIndex.CompareTo( o2.SourceIndex ) == 0
                        ? o1.Value0.CompareTo( o2.Value0 ) == 0
                            ? o1.Value1.CompareTo( o2.Value1 ) == 0
                                ? o1.Value2.CompareTo( o2.Value2 ) == 0 ? 0 : o1.Value2.CompareTo( o2.Value2 )
                                : o1.Value1.CompareTo( o2.Value1 )
                            : o1.Value0.CompareTo( o2.Value0 )
                        : o1.SourceIndex.CompareTo( o2.SourceIndex )
                    : o1.Type.CompareTo( o2.Type );
            } ));
            foreach (var map in GuerillaCodeDom.GetAllMaps())
            {
                var tagDatums = map.Index.Where(u => u.Class == TagClass.Stem);

                foreach (var tagDatum in tagDatums)
                {
                    try
                    {
                        ////var guerillaBlock = tagDatum.Identifier.Get<ShaderTemplateBlock>();
                        //foreach (var definition in guerillaBlock.PostprocessDefinition)
                        //{
                        //    foreach ( var implementation in definition.Implementations )
                        //    {
                        //        for ( int index = 0; index < implementation.Bitmaps.Length; index++ )
                        //        {
                        //            var remap = definition.Remappings[index];
                        //            items.Add(
                        //                       new
                        //                       {
                        //                           Type = "Bitmap Remappings",
                        //                           SourceIndex = remap.SourceIndex,
                        //                           Value0 = remap.fieldskip[0],
                        //                           Value1 = remap.fieldskip[1],
                        //                           Value2 = remap.fieldskip[2],
                        //                           Location = map.Index[tagDatum.Identifier].Path
                        //                       });
                        //        }
                        //        for (int index = 0; index < implementation.PixelConstants.Length; index++)
                        //        {
                        //            var remap = definition.Remappings[index];
                        //            items.Add(
                        //                       new
                        //                       {
                        //                           Type = "Pixel Constant Remappings",
                        //                           SourceIndex = remap.SourceIndex,
                        //                           Value0 = remap.fieldskip[0],
                        //                           Value1 = remap.fieldskip[1],
                        //                           Value2 = remap.fieldskip[2],
                        //                           Location = map.Index[tagDatum.Identifier].Path
                        //                       });
                        //        }
                        //        for (int index = 0; index < implementation.VertexConstants.Length; index++)
                        //        {
                        //            var remap = definition.Remappings[index];
                        //            items.Add(
                        //                       new
                        //                       {
                        //                           Type = "Vertex Constant Remappings",
                        //                           SourceIndex = remap.SourceIndex,
                        //                           Value0 = remap.fieldskip[0],
                        //                           Value1 = remap.fieldskip[1],
                        //                           Value2 = remap.fieldskip[2],
                        //                           Location = map.Index[tagDatum.Identifier].Path
                        //                       });
                        //        }
                        //    }
                        //}
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            
            var source = new BindingSource();
            source.DataSource = items;

            dataGridView1.DataSource = source;
            
        }
    }
}
