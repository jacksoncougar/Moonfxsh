// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelInvalidSectionPairsBlock : RenderModelInvalidSectionPairsBlockBase
    {
        public  RenderModelInvalidSectionPairsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class RenderModelInvalidSectionPairsBlockBase  : IGuerilla
    {
        internal int bits;
        internal  RenderModelInvalidSectionPairsBlockBase(BinaryReader binaryReader)
        {
            bits = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bits);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
