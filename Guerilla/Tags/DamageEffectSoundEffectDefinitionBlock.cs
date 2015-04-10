using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DamageEffectSoundEffectDefinitionBlock : DamageEffectSoundEffectDefinitionBlockBase
    {
        public  DamageEffectSoundEffectDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class DamageEffectSoundEffectDefinitionBlockBase
    {
        internal Moonfish.Tags.StringID effectName;
        internal float durationSeconds;
        internal MappingFunctionBlock effectScaleFunction;
        internal  DamageEffectSoundEffectDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.effectName = binaryReader.ReadStringID();
            this.durationSeconds = binaryReader.ReadSingle();
            this.effectScaleFunction = new MappingFunctionBlock(binaryReader);
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
    };
}
