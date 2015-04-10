// ReSharper disable All
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
        public  PlatformSoundFilterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PlatformSoundFilterBlockBase(System.IO.BinaryReader binaryReader)
        {
            filterType = (FilterType)binaryReader.ReadInt32();
            filterWidth07 = binaryReader.ReadInt32();
            leftFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            leftFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            rightFilterFrequency = new SoundPlaybackParameterDefinitionBlock(binaryReader);
            rightFilterGain = new SoundPlaybackParameterDefinitionBlock(binaryReader);
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
                binaryWriter.Write((Int32)filterType);
                binaryWriter.Write(filterWidth07);
                leftFilterFrequency.Write(binaryWriter);
                leftFilterGain.Write(binaryWriter);
                rightFilterFrequency.Write(binaryWriter);
                rightFilterGain.Write(binaryWriter);
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
