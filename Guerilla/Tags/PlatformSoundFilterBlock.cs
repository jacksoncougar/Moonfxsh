using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundFilterBlock : PlatformSoundFilterBlockBase
    {
        public  PlatformSoundFilterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class PlatformSoundFilterBlockBase
    {
        internal FilterType filterType;
        internal int filterWidth07;
        internal SoundPlaybackParameterDefinitionBlock leftFilterFrequency;
        internal SoundPlaybackParameterDefinitionBlock leftFilterGain;
        internal SoundPlaybackParameterDefinitionBlock rightFilterFrequency;
        internal SoundPlaybackParameterDefinitionBlock rightFilterGain;
        internal  PlatformSoundFilterBlockBase(BinaryReader binaryReader)
        {
            this.filterType = (FilterType)binaryReader.ReadInt32();
            this.filterWidth07 = binaryReader.ReadInt32();
            this.leftFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.leftFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.rightFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            this.rightFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
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
        internal enum FilterType : int
        
        {
            ParametricEQ = 0,
            DLS2 = 1,
            BothOnlyValidForMono = 2,
        };
    };
}
