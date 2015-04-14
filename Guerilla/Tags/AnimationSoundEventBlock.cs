// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationSoundEventBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 sound;
        internal short frame;
        internal Moonfish.Tags.StringID markerName;
        internal  AnimationSoundEventBlockBase(BinaryReader binaryReader)
        {
            sound = binaryReader.ReadShortBlockIndex1();
            frame = binaryReader.ReadInt16();
            markerName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sound);
                binaryWriter.Write(frame);
                binaryWriter.Write(markerName);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
