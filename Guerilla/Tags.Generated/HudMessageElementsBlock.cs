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
        public  HudMessageElementsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class HudMessageElementsBlockBase : GuerillaBlock
    {
        internal byte type;
        internal byte data;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudMessageElementsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = binaryReader.ReadByte();
            data = binaryReader.ReadByte();
        }
        public  HudMessageElementsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
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
