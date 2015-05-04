// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Snd = (TagClass)"snd!";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("snd!")]
    public partial class SoundBlock : SoundBlockBase
    {
        public SoundBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SoundBlockBase : GuerillaBlock
    {
        internal byte[] soundFields;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public SoundBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            soundFields = binaryReader.ReadBytes(20);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            soundFields[0].ReadPointers(binaryReader, blamPointers);
            soundFields[1].ReadPointers(binaryReader, blamPointers);
            soundFields[2].ReadPointers(binaryReader, blamPointers);
            soundFields[3].ReadPointers(binaryReader, blamPointers);
            soundFields[4].ReadPointers(binaryReader, blamPointers);
            soundFields[5].ReadPointers(binaryReader, blamPointers);
            soundFields[6].ReadPointers(binaryReader, blamPointers);
            soundFields[7].ReadPointers(binaryReader, blamPointers);
            soundFields[8].ReadPointers(binaryReader, blamPointers);
            soundFields[9].ReadPointers(binaryReader, blamPointers);
            soundFields[10].ReadPointers(binaryReader, blamPointers);
            soundFields[11].ReadPointers(binaryReader, blamPointers);
            soundFields[12].ReadPointers(binaryReader, blamPointers);
            soundFields[13].ReadPointers(binaryReader, blamPointers);
            soundFields[14].ReadPointers(binaryReader, blamPointers);
            soundFields[15].ReadPointers(binaryReader, blamPointers);
            soundFields[16].ReadPointers(binaryReader, blamPointers);
            soundFields[17].ReadPointers(binaryReader, blamPointers);
            soundFields[18].ReadPointers(binaryReader, blamPointers);
            soundFields[19].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(soundFields, 0, 20);
                return nextAddress;
            }
        }
    };
}
