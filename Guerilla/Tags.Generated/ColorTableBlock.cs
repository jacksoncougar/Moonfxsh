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
        public static readonly TagClass Colo = (TagClass)"colo";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("colo")]
    public partial class ColorTableBlock : ColorTableBlockBase
    {
        public  ColorTableBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ColorTableBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ColorTableBlockBase : GuerillaBlock
    {
        internal ColorBlock[] colors;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ColorTableBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            colors = Guerilla.ReadBlockArray<ColorBlock>(binaryReader);
        }
        public  ColorTableBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            colors = Guerilla.ReadBlockArray<ColorBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ColorBlock>(binaryWriter, colors, nextAddress);
                return nextAddress;
            }
        }
    };
}
