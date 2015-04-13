using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationSoundEventBlock : AnimationSoundEventBlockBase
    {
        public  AnimationSoundEventBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class AnimationSoundEventBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 sound;
        internal short frame;
        internal Moonfish.Tags.StringID markerName;
        internal  AnimationSoundEventBlockBase(BinaryReader binaryReader)
        {
            this.sound = binaryReader.ReadShortBlockIndex1();
            this.frame = binaryReader.ReadInt16();
            this.markerName = binaryReader.ReadStringID();
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
