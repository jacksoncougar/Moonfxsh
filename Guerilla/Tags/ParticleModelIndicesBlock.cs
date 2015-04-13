// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleModelIndicesBlock : ParticleModelIndicesBlockBase
    {
        public  ParticleModelIndicesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ParticleModelIndicesBlockBase  : IGuerilla
    {
        internal short index;
        internal  ParticleModelIndicesBlockBase(BinaryReader binaryReader)
        {
            index = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
