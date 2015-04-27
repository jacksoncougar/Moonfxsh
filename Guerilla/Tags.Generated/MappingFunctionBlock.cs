// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MappingFunctionBlock : MappingFunctionBlockBase
    {
        public  MappingFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MappingFunctionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class MappingFunctionBlockBase : GuerillaBlock
    {
        internal ByteBlock[] data;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MappingFunctionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            data = Guerilla.ReadBlockArray<ByteBlock>(binaryReader);
        }
        public  MappingFunctionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            data = Guerilla.ReadBlockArray<ByteBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ByteBlock>(binaryWriter, data, nextAddress);
                return nextAddress;
            }
        }
    };
}
