using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticlePropertyColorStructNewBlock : ParticlePropertyColorStructNewBlockBase
    {
        public  ParticlePropertyColorStructNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ParticlePropertyColorStructNewBlockBase
    {
        internal InputVariable inputVariable;
        internal RangeVariable rangeVariable;
        internal OutputModifier outputModifier;
        internal OutputModifierInput outputModifierInput;
        internal MappingFunctionBlock mapping;
        internal  ParticlePropertyColorStructNewBlockBase(BinaryReader binaryReader)
        {
            this.inputVariable = (InputVariable)binaryReader.ReadInt16();
            this.rangeVariable = (RangeVariable)binaryReader.ReadInt16();
            this.outputModifier = (OutputModifier)binaryReader.ReadInt16();
            this.outputModifierInput = (OutputModifierInput)binaryReader.ReadInt16();
            this.mapping = new MappingFunctionBlock(binaryReader);
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
