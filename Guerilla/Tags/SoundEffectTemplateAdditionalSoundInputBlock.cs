// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundEffectTemplateAdditionalSoundInputBlock : SoundEffectTemplateAdditionalSoundInputBlockBase
    {
        public  SoundEffectTemplateAdditionalSoundInputBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SoundEffectTemplateAdditionalSoundInputBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID dspEffect;
        internal MappingFunctionBlock lowFrequencySound;
        internal float timePeriodSeconds;
        internal  SoundEffectTemplateAdditionalSoundInputBlockBase(BinaryReader binaryReader)
        {
            dspEffect = binaryReader.ReadStringID();
            lowFrequencySound = new MappingFunctionBlock(binaryReader);
            timePeriodSeconds = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
