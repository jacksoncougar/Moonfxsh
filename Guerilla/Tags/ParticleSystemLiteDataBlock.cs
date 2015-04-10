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
    [LayoutAttribute(Size = 48)]
    public class ParticleSystemLiteDataBlockBase
    {
        internal ParticlesRenderDataBlock[] particlesRenderData;
        internal ParticlesUpdateDataBlock[] particlesOtherData;
        internal byte[] invalidName_;
        internal  ParticleSystemLiteDataBlockBase(BinaryReader binaryReader)
        {
            this.particlesRenderData = ReadParticlesRenderDataBlockArray(binaryReader);
            this.particlesOtherData = ReadParticlesUpdateDataBlockArray(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(32);
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
        internal  virtual ParticlesRenderDataBlock[] ReadParticlesRenderDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticlesRenderDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticlesRenderDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticlesRenderDataBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticlesUpdateDataBlock[] ReadParticlesUpdateDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticlesUpdateDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticlesUpdateDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticlesUpdateDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
