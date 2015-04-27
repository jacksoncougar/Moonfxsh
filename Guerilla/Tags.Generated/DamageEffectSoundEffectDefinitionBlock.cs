// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class DamageEffectSoundEffectDefinitionBlock : DamageEffectSoundEffectDefinitionBlockBase
    {
        public  DamageEffectSoundEffectDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  DamageEffectSoundEffectDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class DamageEffectSoundEffectDefinitionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID effectName;
        internal float durationSeconds;
        internal MappingFunctionBlock effectScaleFunction;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  DamageEffectSoundEffectDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            effectName = binaryReader.ReadStringID();
            durationSeconds = binaryReader.ReadSingle();
            effectScaleFunction = new MappingFunctionBlock(binaryReader);
        }
        public  DamageEffectSoundEffectDefinitionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(effectName);
                binaryWriter.Write(durationSeconds);
                effectScaleFunction.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
