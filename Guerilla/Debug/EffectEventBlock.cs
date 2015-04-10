// ReSharper disable All
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
        public  EffectEventBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  EffectEventBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            skipFraction = binaryReader.ReadSingle();
            delayBoundsSeconds = binaryReader.ReadRange();
            durationBoundsSeconds = binaryReader.ReadRange();
            ReadEffectPartBlockArray(binaryReader);
            ReadBeamBlockArray(binaryReader);
            ReadEffectAccelerationsBlockArray(binaryReader);
            ReadParticleSystemDefinitionBlockNewArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual EffectPartBlock[] ReadEffectPartBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectPartBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectPartBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectPartBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BeamBlock[] ReadBeamBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BeamBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BeamBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BeamBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual EffectAccelerationsBlock[] ReadEffectAccelerationsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(EffectAccelerationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new EffectAccelerationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new EffectAccelerationsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ParticleSystemDefinitionBlockNew[] ReadParticleSystemDefinitionBlockNewArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ParticleSystemDefinitionBlockNew));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ParticleSystemDefinitionBlockNew[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ParticleSystemDefinitionBlockNew(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEffectPartBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteBeamBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteEffectAccelerationsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteParticleSystemDefinitionBlockNewArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(skipFraction);
                binaryWriter.Write(delayBoundsSeconds);
                binaryWriter.Write(durationBoundsSeconds);
                WriteEffectPartBlockArray(binaryWriter);
                WriteBeamBlockArray(binaryWriter);
                WriteEffectAccelerationsBlockArray(binaryWriter);
                WriteParticleSystemDefinitionBlockNewArray(binaryWriter);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            DisabledForDebugging = 1,
        };
    };
}
