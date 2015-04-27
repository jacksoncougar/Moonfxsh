// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundPitchLfoBlock : PlatformSoundPitchLfoBlockBase
    {
        public  PlatformSoundPitchLfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundPitchLfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class PlatformSoundPitchLfoBlockBase : GuerillaBlock
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock pitchModulation;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundPitchLfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            delay = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            frequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            pitchModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
        }
        public  PlatformSoundPitchLfoBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                delay.Write(binaryWriter);
                frequency.Write(binaryWriter);
                pitchModulation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
