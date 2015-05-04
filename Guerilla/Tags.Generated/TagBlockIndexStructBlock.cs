// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TagBlockIndexStructBlock : TagBlockIndexStructBlockBase
    {
        public  TagBlockIndexStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  TagBlockIndexStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class TagBlockIndexStructBlockBase : GuerillaBlock
    {
        internal short blockIndexData;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  TagBlockIndexStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            blockIndexData = binaryReader.ReadInt16();
        }
        public  TagBlockIndexStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            blockIndexData = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(blockIndexData);
                return nextAddress;
            }
        }
    };
}
