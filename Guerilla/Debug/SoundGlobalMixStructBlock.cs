// ReSharper disable All
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
        public  SoundGlobalMixStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  SoundGlobalMixStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            monoUnspatializedGainDB = binaryReader.ReadSingle();
            stereoTo3DGainDB = binaryReader.ReadSingle();
            rearSurroundToFrontStereoGainDB = binaryReader.ReadSingle();
            frontSpeakerGainDB = binaryReader.ReadSingle();
            centerSpeakerGainDB = binaryReader.ReadSingle();
            frontSpeakerGainDB0 = binaryReader.ReadSingle();
            centerSpeakerGainDB0 = binaryReader.ReadSingle();
            stereoUnspatializedGainDB = binaryReader.ReadSingle();
            soloPlayerFadeOutDelaySeconds = binaryReader.ReadSingle();
            soloPlayerFadeOutTimeSeconds = binaryReader.ReadSingle();
            soloPlayerFadeInTimeSeconds = binaryReader.ReadSingle();
            gameMusicFadeOutTimeSeconds = binaryReader.ReadSingle();
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
                binaryWriter.Write(monoUnspatializedGainDB);
                binaryWriter.Write(stereoTo3DGainDB);
                binaryWriter.Write(rearSurroundToFrontStereoGainDB);
                binaryWriter.Write(frontSpeakerGainDB);
                binaryWriter.Write(centerSpeakerGainDB);
                binaryWriter.Write(frontSpeakerGainDB0);
                binaryWriter.Write(centerSpeakerGainDB0);
                binaryWriter.Write(stereoUnspatializedGainDB);
                binaryWriter.Write(soloPlayerFadeOutDelaySeconds);
                binaryWriter.Write(soloPlayerFadeOutTimeSeconds);
                binaryWriter.Write(soloPlayerFadeInTimeSeconds);
                binaryWriter.Write(gameMusicFadeOutTimeSeconds);
            }
        }
    };
}
