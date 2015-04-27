// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StylePaletteBlock : StylePaletteBlockBase
    {
        public  StylePaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StylePaletteBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class StylePaletteBlockBase : GuerillaBlock
    {
        [TagReference("styl")]
        internal Moonfish.Tags.TagReference reference;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StylePaletteBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            reference = binaryReader.ReadTagReference();
        }
        public  StylePaletteBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            reference = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(reference);
                return nextAddress;
            }
        }
    };
}
