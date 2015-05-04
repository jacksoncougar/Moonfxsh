// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class SoundGlobalMixStructBlock : SoundGlobalMixStructBlockBase
    {
        public SoundGlobalMixStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class SoundGlobalMixStructBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 48; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SoundGlobalMixStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
                return nextAddress;
            }
        }
    };
}