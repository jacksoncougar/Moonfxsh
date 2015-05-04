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
        public static readonly TagClass Snmx = (TagClass)"snmx";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("snmx")]
    public partial class SoundMixBlock : SoundMixBlockBase
    {
        public SoundMixBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class SoundMixBlockBase : GuerillaBlock
    {
        internal float leftStereoGainDB;
        internal float rightStereoGainDB;
        internal float leftStereoGainDB0;
        internal float rightStereoGainDB0;
        internal float leftStereoGainDB1;
        internal float rightStereoGainDB1;
        internal float frontSpeakerGainDB;
        internal float rearSpeakerGainDB;
        internal float frontSpeakerGainDB0;
        internal float rearSpeakerGainDB0;
        internal SoundGlobalMixStructBlock globalMix;
        public override int SerializedSize { get { return 88; } }
        public override int Alignment { get { return 4; } }
        public SoundMixBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            leftStereoGainDB = binaryReader.ReadSingle();
            rightStereoGainDB = binaryReader.ReadSingle();
            leftStereoGainDB0 = binaryReader.ReadSingle();
            rightStereoGainDB0 = binaryReader.ReadSingle();
            leftStereoGainDB1 = binaryReader.ReadSingle();
            rightStereoGainDB1 = binaryReader.ReadSingle();
            frontSpeakerGainDB = binaryReader.ReadSingle();
            rearSpeakerGainDB = binaryReader.ReadSingle();
            frontSpeakerGainDB0 = binaryReader.ReadSingle();
            rearSpeakerGainDB0 = binaryReader.ReadSingle();
            globalMix = new SoundGlobalMixStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(globalMix.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            globalMix.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(leftStereoGainDB);
                binaryWriter.Write(rightStereoGainDB);
                binaryWriter.Write(leftStereoGainDB0);
                binaryWriter.Write(rightStereoGainDB0);
                binaryWriter.Write(leftStereoGainDB1);
                binaryWriter.Write(rightStereoGainDB1);
                binaryWriter.Write(frontSpeakerGainDB);
                binaryWriter.Write(rearSpeakerGainDB);
                binaryWriter.Write(frontSpeakerGainDB0);
                binaryWriter.Write(rearSpeakerGainDB0);
                globalMix.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
