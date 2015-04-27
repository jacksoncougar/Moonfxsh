// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ClothIndicesBlock : ClothIndicesBlockBase
    {
        public  ClothIndicesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ClothIndicesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ClothIndicesBlockBase : GuerillaBlock
    {
        internal short index;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ClothIndicesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            index = binaryReader.ReadInt16();
        }
        public  ClothIndicesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            index = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                return nextAddress;
            }
        }
    };
}
