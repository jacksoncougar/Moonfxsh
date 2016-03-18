using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Navigation;
using Be.Windows.Forms;
using Moonfish.Debug;
using Moonfish.Guerilla;
using Moonfish.Guerilla.CodeDom;
using Moonfish.Guerilla.Tags;
using Moonfish.Tags;

namespace Moonfish.Forms
{
    public partial class VrtxViewer : Form
    {
        private DataTypes _types = new DataTypes();
        private MemoryStream _stream;
        private HashSet<GuerillaBlock> blockKeys = new HashSet<GuerillaBlock>();
        private Dictionary<GuerillaBlock, Stream> vertexStreams = new Dictionary<GuerillaBlock, Stream>();

        public VrtxViewer()
        {
            InitializeComponent();
            hexBox1.ByteCharConverter = new DefaultByteCharConverter();
            vertexTags.Columns.Add("Path");

            foreach (var map in GuerillaCodeDom.GetAllMaps())
            {
                var tagDatums = map.Index.Where(u => u.Class == TagClass.Vrtx);

                foreach (var tagDatum in tagDatums)
                {
                    try
                    {
                        //var guerillaBlock = tagDatum.Identifier.Get<VertexShaderBlock>();
                        //for (int index = 0; index < guerillaBlock.GeometryClassifications.Length; index++)
                        //{
                        //    var vertexShaderClassificationBlock = guerillaBlock.GeometryClassifications[index];
                        //    if (vertexShaderClassificationBlock.Code.Length <= 0 ||
                        //         !blockKeys.Add(vertexShaderClassificationBlock)) continue;

                        //    var path = map.Index[tagDatum.Identifier].Path;
                        //    var stream = new MemoryStream(vertexShaderClassificationBlock.Code);
                        //    vertexStreams.Add(vertexShaderClassificationBlock, stream);
                        //    vertexTags.Items.Add(new ListViewItem
                        //    {
                        //        Text = $"{path}: [{index}]",
                        //        Tag = vertexShaderClassificationBlock
                        //    });
                        //}
                    }
                    catch
                    {
                        // ignored
                    }
                }
                break;
            }
            vertexTags.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            _stream = new MemoryStream();
            hexBox1.ByteProvider = new DynamicFileByteProvider(_stream);
            vertexTags.Items[0].Selected = true;
            hexBox1.AutoSize = true;
            splitContainer_tags_hex.Panel2MinSize = hexBox1.RequiredWidth + hexBox1.Padding.Horizontal;
            splitContainer_tags_hex.FixedPanel = FixedPanel.Panel2;
            propertyGrid1.SelectedObject = _types;
        }

        private void vertexTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vertexTags.SelectedItems.Count > 0)
            {
                LoadStream(vertexTags.SelectedItems[0].Tag);
            }
        }

        private void LoadStream(object tag)
        {
            var block = tag as GuerillaBlock;
            if (block == null) return;

            var stream = (MemoryStream)vertexStreams[block];
            hexBox1.ByteProvider.DeleteBytes(0, hexBox1.ByteProvider.Length);
            var buffer = stream.ToArray();
            hexBox1.ByteProvider.InsertBytes(0, buffer);
            hexBox1.ByteProvider.ApplyChanges();
            hexBox1.Refresh();
        }

        private void hexBox1_SelectionStartChanged(object sender, EventArgs e)
        {
            OnHexSelectionChanged();
        }

        private void hexBox1_SelectionLengthChanged(object sender, EventArgs e)
        {
            OnHexSelectionChanged();
        }

        private void OnHexSelectionChanged()
        {
            DisplaySelectionValues();
            DisplaySelectionStatus();
            DisplaySelectionAlternatives();
        }

        private void DisplaySelectionAlternatives()
        {
            return;
            if (propertyGrid1.SelectedGridItem?.Value != null)
            {
                var type = propertyGrid1.SelectedGridItem.Value.GetType();

                int offset, stride;
                if (!int.TryParse(txbOffset.Text, out offset)
                     || !int.TryParse(txbStride.Text, out stride))
                {
                    return;
                }

                var dataSize = Marshal.SizeOf(type);
                if (type == typeof(sbyte))
                {
                    using (var binaryReader = new BinaryReader(_stream, Encoding.Default, true))
                    {

                    }
                }
            }
        }

        private void DisplaySelectionStatus()
        {
            var len = (int)hexBox1.SelectionLength;
            if (len < 1) return;
            toolStripStatusLabel1.Text = $"Sel: {len,-11}";
        }

        private void DisplaySelectionValues()
        {
            var loc = (int)hexBox1.SelectionStart;
            var len = (int)hexBox1.SelectionLength;
            var buffer = new byte[len];
            if (!(loc < 0 || len < 1))
            {
                _stream.Seek(loc, SeekOrigin.Begin);
                _stream.Read(buffer, 0, len);
            }
            _types.data = buffer;
            Update();
        }

        private void txbMask_Validating(object sender, CancelEventArgs e)
        {
            int mask;
            if (int.TryParse(txbMask.Text, NumberStyles.AllowHexSpecifier, CultureInfo.CurrentCulture, out mask))
            {
                txbMask.Text = mask.ToString();
                _types.mask = mask;
            }
            else
            {
                txbMask.Text = "";
                _types.mask = 0;
            }
        }

        private void txbShift_Validating(object sender, CancelEventArgs e)
        {
            byte shift;
            if (byte.TryParse(txbShift.Text, out shift))
            {
                txbShift.Text = shift.ToString();
                _types.shift = shift;
            }
            else
            {
                txbShift.Text = "";
                _types.shift = 0;
            }
        }

        private void txbMask_Validated(object sender, EventArgs e)
        {
            Update();
        }

        private new void Update()
        {
            propertyGrid1.Refresh();
            propertyGrid1.ExpandAllGridItems();
        }

        private void txbShift_Validated(object sender, EventArgs e)
        {
            Update();
        }
    };
}

// ReSharper disable once InconsistentNaming