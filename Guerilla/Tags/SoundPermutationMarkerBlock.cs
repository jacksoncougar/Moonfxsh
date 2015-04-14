// ReSharper disable All
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
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SoundPermutationMarkerBlockBase  : IGuerilla
    {
        internal int markerId;
        internal Moonfish.Tags.StringID name;
        internal int sampleOffset;
        internal  SoundPermutationMarkerBlockBase(BinaryReader binaryReader)
        {
            markerId = binaryReader.ReadInt32();
            name = binaryReader.ReadStringID();
            sampleOffset = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(markerId);
                binaryWriter.Write(name);
                binaryWriter.Write(sampleOffset);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
