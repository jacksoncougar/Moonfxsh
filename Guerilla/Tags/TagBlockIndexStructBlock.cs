// ReSharper disable All
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
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class TagBlockIndexStructBlockBase  : IGuerilla
    {
        internal byte index;
        internal byte length;
        internal  TagBlockIndexStructBlockBase(BinaryReader binaryReader)
        {
            index = binaryReader.ReadByte();
            length = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                binaryWriter.Write(length);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
