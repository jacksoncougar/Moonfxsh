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
        public  AnimationSoundEventBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class AnimationSoundEventBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 sound;
        internal short frame;
        internal Moonfish.Tags.StringID markerName;
        internal  AnimationSoundEventBlockBase(System.IO.BinaryReader binaryReader)
        {
            sound = binaryReader.ReadShortBlockIndex1();
            frame = binaryReader.ReadInt16();
            markerName = binaryReader.ReadStringID();
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
                binaryWriter.Write(sound);
                binaryWriter.Write(frame);
                binaryWriter.Write(markerName);
            }
        }
    };
}
