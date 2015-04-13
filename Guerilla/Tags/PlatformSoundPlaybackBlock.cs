using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlatformSoundPlaybackBlock : PlatformSoundPlaybackBlockBase
    {
        public  PlatformSoundPlaybackBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class PlatformSoundPlaybackBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal PlatformSoundPlaybackStructBlock playback;
        internal  PlatformSoundPlaybackBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.playback = new PlatformSoundPlaybackStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
