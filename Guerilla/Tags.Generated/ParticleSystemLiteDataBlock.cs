// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleSystemLiteDataBlock : ParticleSystemLiteDataBlockBase
    {
        public  ParticleSystemLiteDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ParticleSystemLiteDataBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class ParticleSystemLiteDataBlockBase : GuerillaBlock
    {
        internal ParticlesRenderDataBlock[] particlesRenderData;
        internal ParticlesUpdateDataBlock[] particlesOtherData;
        internal byte[] invalidName_;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ParticleSystemLiteDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            particlesRenderData = Guerilla.ReadBlockArray<ParticlesRenderDataBlock>(binaryReader);
            particlesOtherData = Guerilla.ReadBlockArray<ParticlesUpdateDataBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
        }
        public  ParticleSystemLiteDataBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            particlesRenderData = Guerilla.ReadBlockArray<ParticlesRenderDataBlock>(binaryReader);
            particlesOtherData = Guerilla.ReadBlockArray<ParticlesUpdateDataBlock>(binaryReader);
            invalidName_ = binaryReader.ReadBytes(32);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
