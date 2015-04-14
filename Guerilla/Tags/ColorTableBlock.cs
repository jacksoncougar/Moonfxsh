// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass ColoClass = (TagClass)"colo";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("colo")]
    public  partial class ColorTableBlock : ColorTableBlockBase
    {
        public  ColorTableBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ColorTableBlockBase  : IGuerilla
    {
        internal ColorBlock[] colors;
        internal  ColorTableBlockBase(BinaryReader binaryReader)
        {
            colors = Guerilla.ReadBlockArray<ColorBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                Guerilla.WriteBlockArray<ColorBlock>(binaryWriter, colors, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
