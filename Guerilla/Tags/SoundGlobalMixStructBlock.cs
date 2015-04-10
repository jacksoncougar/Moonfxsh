using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SoundGlobalMixStructBlock : SoundGlobalMixStructBlockBase
    {
        public  SoundGlobalMixStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class SoundGlobalMixStructBlockBase
    {
        internal float monoUnspatializedGainDB;
        internal float stereoTo3DGainDB;
        internal float rearSurroundToFrontStereoGainDB;
        internal float frontSpeakerGainDB;
        internal float centerSpeakerGainDB;
        internal float frontSpeakerGainDB0;
        internal float centerSpeakerGainDB0;
        internal float stereoUnspatializedGainDB;
        internal float soloPlayerFadeOutDelaySeconds;
        internal float soloPlayerFadeOutTimeSeconds;
        internal float soloPlayerFadeInTimeSeconds;
        internal float gameMusicFadeOutTimeSeconds;
        internal  SoundGlobalMixStructBlockBase(BinaryReader binaryReader)
        {
            this.monoUnspatializedGainDB = binaryReader.ReadSingle();
            this.stereoTo3DGainDB = binaryReader.ReadSingle();
            this.rearSurroundToFrontStereoGainDB = binaryReader.ReadSingle();
            this.frontSpeakerGainDB = binaryReader.ReadSingle();
            this.centerSpeakerGainDB = binaryReader.ReadSingle();
            this.frontSpeakerGainDB0 = binaryReader.ReadSingle();
            this.centerSpeakerGainDB0 = binaryReader.ReadSingle();
            this.stereoUnspatializedGainDB = binaryReader.ReadSingle();
            this.soloPlayerFadeOutDelaySeconds = binaryReader.ReadSingle();
            this.soloPlayerFadeOutTimeSeconds = binaryReader.ReadSingle();
            this.soloPlayerFadeInTimeSeconds = binaryReader.ReadSingle();
            this.gameMusicFadeOutTimeSeconds = binaryReader.ReadSingle();
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
