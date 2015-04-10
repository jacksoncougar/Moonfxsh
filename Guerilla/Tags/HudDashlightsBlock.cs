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
        public  HudDashlightsBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  HudDashlightsBlockBase(BinaryReader binaryReader)
        {
            this.bitmap = binaryReader.ReadTagReference();
            this.shader = binaryReader.ReadTagReference();
            this.sequenceIndex = binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.sound = binaryReader.ReadTagReference();
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            DontScaleWhenPulsing = 1,
        };
    };
}
