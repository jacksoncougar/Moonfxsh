// ReSharper disable All
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
        public  PlatformSoundPitchLfoBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class PlatformSoundPitchLfoBlockBase
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock pitchModulation;
        internal  PlatformSoundPitchLfoBlockBase(System.IO.BinaryReader binaryReader)
        {
            delay = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            frequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            pitchModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
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
                delay.Write(binaryWriter);
                frequency.Write(binaryWriter);
                pitchModulation.Write(binaryWriter);
            }
        }
    };
}
