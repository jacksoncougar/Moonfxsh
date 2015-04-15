// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleSystemLiteDataBlock : ParticleSystemLiteDataBlockBase
    {
        public  ParticleSystemLiteDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class ParticleSystemLiteDataBlockBase  : IGuerilla
    {
        internal ParticlesRenderDataBlock[] particlesRenderData;
        internal ParticlesUpdateDataBlock[] particlesOtherData;
        internal byte[] invalidName_;
        internal  ParticleSystemLiteDataBlockBase(BinaryReader binaryReader)
        {
            particlesRenderData = Guerilla.ReadBlockArray<ParticlesRenderDataBlock>(binaryReader);
            particlesOtherData = Guerilla.ReadBlockArray<ParticlesUpdateDataBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ParticlesRenderDataBlock>(binaryWriter, particlesRenderData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticlesUpdateDataBlock>(binaryWriter, particlesOtherData, nextAddress);
                binaryWriter.Write(invalidName_, 0, 32);
                return nextAddress;
            }
        }
    };
}
