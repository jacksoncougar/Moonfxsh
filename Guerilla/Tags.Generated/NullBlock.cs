// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class NullBlock : NullBlockBase
    {
        public  NullBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  NullBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 0, Alignment = 4)]
    public class NullBlockBase : GuerillaBlock
    {
        
        public override int SerializedSize{get { return 0; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  NullBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  NullBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                return nextAddress;
            }
        }
    };
}
