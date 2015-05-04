// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Bsdt = (TagClass) "bsdt";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("bsdt")]
    public partial class BreakableSurfaceBlock : BreakableSurfaceBlockBase
    {
        public BreakableSurfaceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class BreakableSurfaceBlockBase : GuerillaBlock
    {
        internal float maximumVitality;
        [TagReference("effe")] internal Moonfish.Tags.TagReference effect;
        [TagReference("snd!")] internal Moonfish.Tags.TagReference sound;
        internal ParticleSystemDefinitionBlockNew[] particleEffects;
        internal float particleDensity;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BreakableSurfaceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            maximumVitality = binaryReader.ReadSingle();
            effect = binaryReader.ReadTagReference();
            sound = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleSystemDefinitionBlockNew>(binaryReader));
            particleDensity = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            particleEffects = ReadBlockArrayData<ParticleSystemDefinitionBlockNew>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumVitality);
                binaryWriter.Write(effect);
                binaryWriter.Write(sound);
                nextAddress = Guerilla.WriteBlockArray<ParticleSystemDefinitionBlockNew>(binaryWriter, particleEffects,
                    nextAddress);
                binaryWriter.Write(particleDensity);
                return nextAddress;
            }
        }
    };
}