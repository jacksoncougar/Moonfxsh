using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundPitchLfoBlock : PlatformSoundPitchLfoBlockBase
    {
        public  PlatformSoundPitchLfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class PlatformSoundPitchLfoBlockBase
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock pitchModulation;
        internal  PlatformSoundPitchLfoBlockBase(BinaryReader binaryReader)
        {
            this.delay = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.frequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.pitchModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
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
    };
}
