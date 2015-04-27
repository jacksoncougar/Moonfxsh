// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class TagBlockIndexBlock : TagBlockIndexBlockBase
    {
        public  TagBlockIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  TagBlockIndexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class TagBlockIndexBlockBase : GuerillaBlock
    {
        internal TagBlockIndexStructBlock indices;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  TagBlockIndexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            indices = new TagBlockIndexStructBlock(binaryReader);
        }
        public  TagBlockIndexBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            indices = new TagBlockIndexStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                indices.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
