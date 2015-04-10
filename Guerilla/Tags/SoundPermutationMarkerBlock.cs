using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundPermutationMarkerBlock : SoundPermutationMarkerBlockBase
    {
        public  SoundPermutationMarkerBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class SoundPermutationMarkerBlockBase
    {
        internal int markerId;
        internal Moonfish.Tags.StringID name;
        internal int sampleOffset;
        internal  SoundPermutationMarkerBlockBase(BinaryReader binaryReader)
        {
            this.markerId = binaryReader.ReadInt32();
            this.name = binaryReader.ReadStringID();
            this.sampleOffset = binaryReader.ReadInt32();
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
    };
}
