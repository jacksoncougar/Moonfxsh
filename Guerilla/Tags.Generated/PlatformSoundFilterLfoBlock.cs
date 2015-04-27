// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundFilterLfoBlock : PlatformSoundFilterLfoBlockBase
    {
        public  PlatformSoundFilterLfoBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundFilterLfoBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class PlatformSoundFilterLfoBlockBase : GuerillaBlock
    {
        internal SoundPlaybackParameterDefinitionBlock delay;
        internal SoundPlaybackParameterDefinitionBlock frequency;
        internal SoundPlaybackParameterDefinitionBlock cutoffModulation;
        internal SoundPlaybackParameterDefinitionBlock gainModulation;
        
        public override int SerializedSize{get { return 64; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundFilterLfoBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            delay = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            frequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            cutoffModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            gainModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
        }
        public  PlatformSoundFilterLfoBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            delay = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            frequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            cutoffModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            gainModulation = new SoundPlaybackParameterDefinitionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                delay.Write(binaryWriter);
                frequency.Write(binaryWriter);
                cutoffModulation.Write(binaryWriter);
                gainModulation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
