// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlatformSoundFilterBlock : PlatformSoundFilterBlockBase
    {
        public  PlatformSoundFilterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlatformSoundFilterBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class PlatformSoundFilterBlockBase : GuerillaBlock
    {
        internal FilterType filterType;
        internal int filterWidth07;
        internal SoundPlaybackParameterDefinitionBlock leftFilterFrequency;
        internal SoundPlaybackParameterDefinitionBlock leftFilterGain;
        internal SoundPlaybackParameterDefinitionBlock rightFilterFrequency;
        internal SoundPlaybackParameterDefinitionBlock rightFilterGain;
        
        public override int SerializedSize{get { return 72; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlatformSoundFilterBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            filterType = (FilterType)binaryReader.ReadInt32();
            filterWidth07 = binaryReader.ReadInt32();
            leftFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            leftFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            rightFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            rightFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
        }
        public  PlatformSoundFilterBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            filterType = (FilterType)binaryReader.ReadInt32();
            filterWidth07 = binaryReader.ReadInt32();
            leftFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            leftFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            rightFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            rightFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)filterType);
                binaryWriter.Write(filterWidth07);
                leftFilterFrequency.Write(binaryWriter);
                leftFilterGain.Write(binaryWriter);
                rightFilterFrequency.Write(binaryWriter);
                rightFilterGain.Write(binaryWriter);
                return nextAddress;
            }
        }
        internal enum FilterType : int
        {
            ParametricEQ = 0,
            DLS2 = 1,
            BothOnlyValidForMono = 2,
        };
    };
}
