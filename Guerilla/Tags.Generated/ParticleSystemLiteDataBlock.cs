// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleSystemLiteDataBlock : ParticleSystemLiteDataBlockBase
    {
        public ParticleSystemLiteDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class ParticleSystemLiteDataBlockBase : GuerillaBlock
    {
        internal ParticlesRenderDataBlock[] particlesRenderData;
        internal ParticlesUpdateDataBlock[] particlesOtherData;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 48; } }
        public override int Alignment { get { return 4; } }
        public ParticleSystemLiteDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticlesRenderDataBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticlesUpdateDataBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(32);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            particlesRenderData = ReadBlockArrayData<ParticlesRenderDataBlock>(binaryReader, blamPointers.Dequeue());
            particlesOtherData = ReadBlockArrayData<ParticlesUpdateDataBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
