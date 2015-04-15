// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TagBlockIndexBlock : TagBlockIndexBlockBase
    {
        public  TagBlockIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class TagBlockIndexBlockBase  : IGuerilla
    {
        internal TagBlockIndexStructBlock indices;
        internal  TagBlockIndexBlockBase(BinaryReader binaryReader)
        {
            indices = new TagBlockIndexStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                indices.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
