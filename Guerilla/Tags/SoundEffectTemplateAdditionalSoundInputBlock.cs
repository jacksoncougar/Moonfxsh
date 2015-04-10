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
    [LayoutAttribute(Size = 16)]
    public class SoundEffectTemplateAdditionalSoundInputBlockBase
    {
        internal Moonfish.Tags.StringID dspEffect;
        internal MappingFunctionBlock lowFrequencySound;
        internal float timePeriodSeconds;
        internal  SoundEffectTemplateAdditionalSoundInputBlockBase(BinaryReader binaryReader)
        {
            this.dspEffect = binaryReader.ReadStringID();
            this.lowFrequencySound = new MappingFunctionBlock(binaryReader);
            this.timePeriodSeconds = binaryReader.ReadSingle();
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
