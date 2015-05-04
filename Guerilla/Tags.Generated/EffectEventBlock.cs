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
    public partial class EffectEventBlock : EffectEventBlockBase
    {
        public EffectEventBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class EffectEventBlockBase : GuerillaBlock
    {
        internal Flags flags;

        /// <summary>
        /// chance that this event will be skipped entirely
        /// </summary>
        internal float skipFraction;

        /// <summary>
        /// delay before this event takes place
        /// </summary>
        internal Moonfish.Model.Range delayBoundsSeconds;

        /// <summary>
        /// duration of this event
        /// </summary>
        internal Moonfish.Model.Range durationBoundsSeconds;

        internal EffectPartBlock[] parts;
        internal BeamBlock[] beams;
        internal EffectAccelerationsBlock[] accelerations;
        internal ParticleSystemDefinitionBlockNew[] particleSystems;

        public override int SerializedSize
        {
            get { return 56; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public EffectEventBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            skipFraction = binaryReader.ReadSingle();
            delayBoundsSeconds = binaryReader.ReadRange();
            durationBoundsSeconds = binaryReader.ReadRange();
            blamPointers.Enqueue(ReadBlockArrayPointer<EffectPartBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BeamBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<EffectAccelerationsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleSystemDefinitionBlockNew>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            parts = ReadBlockArrayData<EffectPartBlock>(binaryReader, blamPointers.Dequeue());
            beams = ReadBlockArrayData<BeamBlock>(binaryReader, blamPointers.Dequeue());
            accelerations = ReadBlockArrayData<EffectAccelerationsBlock>(binaryReader, blamPointers.Dequeue());
            particleSystems = ReadBlockArrayData<ParticleSystemDefinitionBlockNew>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(delayBoundsSeconds);
                binaryWriter.Write(durationBoundsSeconds);
                nextAddress = Guerilla.WriteBlockArray<EffectPartBlock>(binaryWriter, parts, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BeamBlock>(binaryWriter, beams, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EffectAccelerationsBlock>(binaryWriter, accelerations,
                    nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ParticleSystemDefinitionBlockNew>(binaryWriter, particleSystems,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            DisabledForDebugging = 1,
        };
    };
}