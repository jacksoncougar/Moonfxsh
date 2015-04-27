// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundEffectTemplateAdditionalSoundInputBlock : SoundEffectTemplateAdditionalSoundInputBlockBase
    {
        public  SoundEffectTemplateAdditionalSoundInputBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SoundEffectTemplateAdditionalSoundInputBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundEffectTemplateAdditionalSoundInputBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID dspEffect;
        internal MappingFunctionBlock lowFrequencySound;
        internal float timePeriodSeconds;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SoundEffectTemplateAdditionalSoundInputBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            dspEffect = binaryReader.ReadStringID();
            lowFrequencySound = new MappingFunctionBlock(binaryReader);
            timePeriodSeconds = binaryReader.ReadSingle();
        }
        public  SoundEffectTemplateAdditionalSoundInputBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            dspEffect = binaryReader.ReadStringID();
            lowFrequencySound = new MappingFunctionBlock(binaryReader);
            timePeriodSeconds = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dspEffect);
                lowFrequencySound.Write(binaryWriter);
                binaryWriter.Write(timePeriodSeconds);
                return nextAddress;
            }
        }
    };
}
