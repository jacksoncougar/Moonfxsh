using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPlatformSoundPlaybackBlock : SoundPlatformSoundPlaybackBlockBase
    {
        public  SoundPlatformSoundPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class SoundPlatformSoundPlaybackBlockBase
    {
        internal SimplePlatformSoundPlaybackStructBlock playbackDefinition;
        internal GNullBlock[] gNullBlock;
        internal  SoundPlatformSoundPlaybackBlockBase(BinaryReader binaryReader)
        {
            this.playbackDefinition = new SimplePlatformSoundPlaybackStructBlock(binaryReader);
            this.gNullBlock = ReadGNullBlockArray(binaryReader);
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
        internal  virtual GNullBlock[] ReadGNullBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GNullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GNullBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GNullBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
