// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudMessageElementsBlock : HudMessageElementsBlockBase
    {
        public  HudMessageElementsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class HudMessageElementsBlockBase : GuerillaBlock
    {
        internal byte type;
        internal byte data;
        
        public override int SerializedSize{get { return 2; }}
        
        internal  HudMessageElementsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = binaryReader.ReadByte();
            data = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(type);
                binaryWriter.Write(data);
                return nextAddress;
            }
        }
    };
}
