using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TagBlockIndexStructBlock : TagBlockIndexStructBlockBase
    {
        public  TagBlockIndexStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2)]
    public class TagBlockIndexStructBlockBase
    {
        internal byte index;
        internal byte length;
        internal  TagBlockIndexStructBlockBase(BinaryReader binaryReader)
        {
            this.index = binaryReader.ReadByte();
            this.length = binaryReader.ReadByte();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
    };
}
