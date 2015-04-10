using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundFilterLfoBlock : PlatformSoundFilterLfoBlockBase
    {
        public  PlatformSoundFilterLfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class PlatformSoundFilterLfoBlockBase
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock cutoffModulation;
        internal SoundPlaybackParameterDefinitionBlock gainModulation;
        internal  PlatformSoundFilterLfoBlockBase(BinaryReader binaryReader)
        {
            this.delay = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.frequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.cutoffModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.gainModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
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
