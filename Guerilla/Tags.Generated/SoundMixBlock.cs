// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

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
    public  partial class SoundMixBlock : SoundMixBlockBase
    {
        public  SoundMixBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class SoundMixBlockBase  : IGuerilla
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
        internal  SoundMixBlockBase(BinaryReader binaryReader)
        {
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
            globalMix = new SoundGlobalMixStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
