using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("snmx")]
    public  partial class SoundMixBlock : SoundMixBlockBase
    {
        public  SoundMixBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 88)]
    public class SoundMixBlockBase
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
            this.leftStereoGainDB = binaryReader.ReadSingle();
            this.rightStereoGainDB = binaryReader.ReadSingle();
            this.leftStereoGainDB0 = binaryReader.ReadSingle();
            this.rightStereoGainDB0 = binaryReader.ReadSingle();
            this.leftStereoGainDB1 = binaryReader.ReadSingle();
            this.rightStereoGainDB1 = binaryReader.ReadSingle();
            this.frontSpeakerGainDB = binaryReader.ReadSingle();
            this.rearSpeakerGainDB = binaryReader.ReadSingle();
            this.frontSpeakerGainDB0 = binaryReader.ReadSingle();
            this.rearSpeakerGainDB0 = binaryReader.ReadSingle();
            this.globalMix = new SoundGlobalMixStructBlock(binaryReader);
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
    };
}
