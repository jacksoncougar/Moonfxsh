using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EffectEventBlock : EffectEventBlockBase
    {
        public  EffectEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class EffectEventBlockBase
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
        internal  EffectEventBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.skipFraction = binaryReader.ReadSingle();
            this.delayBoundsSeconds = binaryReader.ReadRange();
            this.durationBoundsSeconds = binaryReader.ReadRange();
            this.parts = ReadEffectPartBlockArray(binaryReader);
            this.beams = ReadBeamBlockArray(binaryReader);
            this.accelerations = ReadEffectAccelerationsBlockArray(binaryReader);
            this.particleSystems = ReadParticleSystemDefinitionBlockNewArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        internal  virtual EffectPartBlock[] ReadEffectPartBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectPartBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectPartBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectPartBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BeamBlock[] ReadBeamBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BeamBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BeamBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BeamBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EffectAccelerationsBlock[] ReadEffectAccelerationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectAccelerationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectAccelerationsBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectAccelerationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleSystemDefinitionBlockNew[] ReadParticleSystemDefinitionBlockNewArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemDefinitionBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemDefinitionBlockNew[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemDefinitionBlockNew(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DisabledForDebugging = 1,
        };
    };
}
