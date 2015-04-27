// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public artial class SoundGlobalMixStructBlock : SoundGlobalMixStructBlockBase
    {
        public  oundGlobalMixStructBlock(B inaryReader binaryReader) :  base(b inaryReader) 
        {
         
    };

    LayoutAttribute(S ize = 48, Alignment = 4) ]
    public class SoundGlobalMixStructBlockBase  GuerillaBlock
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
        internal float gameMusicFadeOutTimeSecond

          
       public override int Serializ edSize{get { return 48; } }
        
        internal  SoundGlobalMixStructBlockBase(BinaryReader bi naryReader): base(binaryReader)
        {
            mon oUnspatializedGainDB = binaryReader.ReadSingle();
            stereoTo3DG ainDB = binaryReader.ReadSingle();
            rearSurroundT oFrontStereoGainDB = binaryReader.ReadSingle();
            f rontSpeakerGainDB = binaryReader.ReadSingle();
            ce nterSpeakerGainDB = binaryReader.ReadSingle();
            fro ntSpeakerGainDB0 = binaryReader.ReadSingle();
            centerSpe akerGainDB0 = binaryReader.ReadSingle();
            stereoUnspatialize dGainDB = binaryReader.ReadSingle();
            soloPlayerFadeOutDela ySeconds = binaryReader.ReadSingle();
            soloPlayerFadeOutTi meSeconds = binaryReader.ReadSingle();
            soloPlayerFadeInTi meSeconds = b

        r.ReadSingle();
             gameMusicFadeOutTimeSeconds = binaryReader .ReadSingle();
        }
          public override int Write ( System.IO.BinaryWriter binaryWriter, Int32 nextAddres s)
        {
             using(binaryWriter.BaseStream.Pin() )
            { 
                binaryWriter.Write(mo noUnspatializedGainDB);
                 binaryWriter.Write(stereoTo3D GainDB);
                 binaryWriter.Write(rearSurround ToFrontStereoGainDB );
                binaryWriter.Write( frontSpeakerGainDB) ;
                binaryWriter.Write(c enterSpeakerGainDB); 
                binaryWriter.Write(fr ontSpeakerGainDB0);
                 binaryWriter.Write(centerSp eakerGainDB0);
                 binaryWriter.Write(stereoUnspatializ edGainDB);
                 binaryWriter.Write(soloPlayerFadeOutDel aySeconds);
                 binaryWriter.Write(soloPlayerFadeOutT imeSeconds);
                 binaryWriter.Write(soloPlayerFadeInTimeSeconds);
                binaryWter.Write(gameMusicFadeOutTimeSeconds);
                return nextAddress;
            }
        }
    };
}
