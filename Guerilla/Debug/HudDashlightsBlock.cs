// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudDashlightsBlock : HudDashlightsBlockBase
    {
        public  HudDashlightsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class HudDashlightsBlockBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal short sequenceIndex;
        internal Flags flags;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference sound;
        internal  HudDashlightsBlockBase(System.IO.BinaryReader binaryReader)
        {
            bitmap = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            sequenceIndex = binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            sound = binaryReader.ReadTagReference();
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
                binaryWriter.Write(bitmap);
                binaryWriter.Write(shader);
                binaryWriter.Write(sequenceIndex);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(sound);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DontScaleWhenPulsing = 1,
        };
    };
}
