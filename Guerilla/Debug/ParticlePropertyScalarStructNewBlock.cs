// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticlePropertyScalarStructNewBlock : ParticlePropertyScalarStructNewBlockBase
    {
        public  ParticlePropertyScalarStructNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ParticlePropertyScalarStructNewBlockBase
    {
        internal InputVariable inputVariable;
        internal RangeVariable rangeVariable;
        internal OutputModifier outputModifier;
        internal OutputModifierInput outputModifierInput;
        internal MappingFunctionBlock mapping;
        internal  ParticlePropertyScalarStructNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            inputVariable = (InputVariable)binaryReader.ReadInt16();
            rangeVariable = (RangeVariable)binaryReader.ReadInt16();
            outputModifier = (OutputModifier)binaryReader.ReadInt16();
            outputModifierInput = (OutputModifierInput)binaryReader.ReadInt16();
            mapping = new MappingFunctionBlock(binaryReader);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)inputVariable);
                binaryWriter.Write((Int16)rangeVariable);
                binaryWriter.Write((Int16)outputModifier);
                binaryWriter.Write((Int16)outputModifierInput);
                mapping.Write(binaryWriter);
            }
        }
        internal enum InputVariable : short
        
        {
            ParticleAge = 0,
            ParticleEmitTime = 1,
            ParticleRandom1 = 2,
            ParticleRandom2 = 3,
            EmitterAge = 4,
            EmitterRandom1 = 5,
            EmitterRandom2 = 6,
            SystemLod = 7,
            GameTime = 8,
            EffectAScale = 9,
            EffectBScale = 10,
            ParticleRotation = 11,
            ExplosionAnimation = 12,
            ExplosionRotation = 13,
            ParticleRandom3 = 14,
            ParticleRandom4 = 15,
            LocationRandom = 16,
        };
        internal enum RangeVariable : short
        
        {
            ParticleAge = 0,
            ParticleEmitTime = 1,
            ParticleRandom1 = 2,
            ParticleRandom2 = 3,
            EmitterAge = 4,
            EmitterRandom1 = 5,
            EmitterRandom2 = 6,
            SystemLod = 7,
            GameTime = 8,
            EffectAScale = 9,
            EffectBScale = 10,
            ParticleRotation = 11,
            ExplosionAnimation = 12,
            ExplosionRotation = 13,
            ParticleRandom3 = 14,
            ParticleRandom4 = 15,
            LocationRandom = 16,
        };
        internal enum OutputModifier : short
        
        {
            InvalidName = 0,
            Plus = 1,
            Times = 2,
        };
        internal enum OutputModifierInput : short
        
        {
            ParticleAge = 0,
            ParticleEmitTime = 1,
            ParticleRandom1 = 2,
            ParticleRandom2 = 3,
            EmitterAge = 4,
            EmitterRandom1 = 5,
            EmitterRandom2 = 6,
            SystemLod = 7,
            GameTime = 8,
            EffectAScale = 9,
            EffectBScale = 10,
            ParticleRotation = 11,
            ExplosionAnimation = 12,
            ExplosionRotation = 13,
            ParticleRandom3 = 14,
            ParticleRandom4 = 15,
            LocationRandom = 16,
        };
    };
}
