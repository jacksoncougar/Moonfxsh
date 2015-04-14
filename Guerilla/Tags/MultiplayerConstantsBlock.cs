// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MultiplayerConstantsBlock : MultiplayerConstantsBlockBase
    {
        public  MultiplayerConstantsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 352, Alignment = 4)]
    public class MultiplayerConstantsBlockBase  : IGuerilla
    {
        internal float maximumRandomSpawnBias;
        internal float teleporterRechargeTimeSeconds;
        internal float grenadeDangerWeight;
        internal float grenadeDangerInnerRadius;
        internal float grenadeDangerOuterRadius;
        internal float grenadeDangerLeadTimeSeconds;
        internal float vehicleDangerMinSpeedWuSec;
        internal float vehicleDangerWeight;
        internal float vehicleDangerRadius;
        internal float vehicleDangerLeadTimeSeconds;
        /// <summary>
        /// how nearby a player is to count a vehicle as 'occupied'
        /// </summary>
        internal float vehicleNearbyPlayerDist;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference hillShader;
        internal byte[] invalidName_2;
        internal float flagResetStopDistance;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference bombExplodeEffect;
        [TagReference("jpt!")]
        internal Moonfish.Tags.TagReference bombExplodeDmgEffect;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference bombDefuseEffect;
        internal Moonfish.Tags.StringID bombDefusalString;
        internal Moonfish.Tags.StringID blockedTeleporterString;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal  MultiplayerConstantsBlockBase(BinaryReader binaryReader)
        {
            maximumRandomSpawnBias = binaryReader.ReadSingle();
            teleporterRechargeTimeSeconds = binaryReader.ReadSingle();
            grenadeDangerWeight = binaryReader.ReadSingle();
            grenadeDangerInnerRadius = binaryReader.ReadSingle();
            grenadeDangerOuterRadius = binaryReader.ReadSingle();
            grenadeDangerLeadTimeSeconds = binaryReader.ReadSingle();
            vehicleDangerMinSpeedWuSec = binaryReader.ReadSingle();
            vehicleDangerWeight = binaryReader.ReadSingle();
            vehicleDangerRadius = binaryReader.ReadSingle();
            vehicleDangerLeadTimeSeconds = binaryReader.ReadSingle();
            vehicleNearbyPlayerDist = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(84);
            invalidName_0 = binaryReader.ReadBytes(32);
            invalidName_1 = binaryReader.ReadBytes(32);
            hillShader = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadBytes(16);
            flagResetStopDistance = binaryReader.ReadSingle();
            bombExplodeEffect = binaryReader.ReadTagReference();
            bombExplodeDmgEffect = binaryReader.ReadTagReference();
            bombDefuseEffect = binaryReader.ReadTagReference();
            bombDefusalString = binaryReader.ReadStringID();
            blockedTeleporterString = binaryReader.ReadStringID();
            invalidName_3 = binaryReader.ReadBytes(4);
            invalidName_4 = binaryReader.ReadBytes(32);
            invalidName_5 = binaryReader.ReadBytes(32);
            invalidName_6 = binaryReader.ReadBytes(32);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(maximumRandomSpawnBias);
                binaryWriter.Write(teleporterRechargeTimeSeconds);
                binaryWriter.Write(grenadeDangerWeight);
                binaryWriter.Write(grenadeDangerInnerRadius);
                binaryWriter.Write(grenadeDangerOuterRadius);
                binaryWriter.Write(grenadeDangerLeadTimeSeconds);
                binaryWriter.Write(vehicleDangerMinSpeedWuSec);
                binaryWriter.Write(vehicleDangerWeight);
                binaryWriter.Write(vehicleDangerRadius);
                binaryWriter.Write(vehicleDangerLeadTimeSeconds);
                binaryWriter.Write(vehicleNearbyPlayerDist);
                binaryWriter.Write(invalidName_, 0, 84);
                binaryWriter.Write(invalidName_0, 0, 32);
                binaryWriter.Write(invalidName_1, 0, 32);
                binaryWriter.Write(hillShader);
                binaryWriter.Write(invalidName_2, 0, 16);
                binaryWriter.Write(flagResetStopDistance);
                binaryWriter.Write(bombExplodeEffect);
                binaryWriter.Write(bombExplodeDmgEffect);
                binaryWriter.Write(bombDefuseEffect);
                binaryWriter.Write(bombDefusalString);
                binaryWriter.Write(blockedTeleporterString);
                binaryWriter.Write(invalidName_3, 0, 4);
                binaryWriter.Write(invalidName_4, 0, 32);
                binaryWriter.Write(invalidName_5, 0, 32);
                binaryWriter.Write(invalidName_6, 0, 32);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
