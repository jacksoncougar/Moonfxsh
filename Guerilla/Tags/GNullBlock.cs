// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GNullBlock : GNullBlockBase
    {
        public  GNullBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 0, Alignment = 4)]
    public class GNullBlockBase  : IGuerilla
    {
        internal  GNullBlockBase(BinaryReader binaryReader)
        {
            
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
