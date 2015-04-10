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
    [LayoutAttribute(Size = 352)]
    public class MultiplayerConstantsBlockBase
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
            this.maximumRandomSpawnBias = binaryReader.ReadSingle();
            this.teleporterRechargeTimeSeconds = binaryReader.ReadSingle();
            this.grenadeDangerWeight = binaryReader.ReadSingle();
            this.grenadeDangerInnerRadius = binaryReader.ReadSingle();
            this.grenadeDangerOuterRadius = binaryReader.ReadSingle();
            this.grenadeDangerLeadTimeSeconds = binaryReader.ReadSingle();
            this.vehicleDangerMinSpeedWuSec = binaryReader.ReadSingle();
            this.vehicleDangerWeight = binaryReader.ReadSingle();
            this.vehicleDangerRadius = binaryReader.ReadSingle();
            this.vehicleDangerLeadTimeSeconds = binaryReader.ReadSingle();
            this.vehicleNearbyPlayerDist = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(84);
            this.invalidName_0 = binaryReader.ReadBytes(32);
            this.invalidName_1 = binaryReader.ReadBytes(32);
            this.hillShader = binaryReader.ReadTagReference();
            this.invalidName_2 = binaryReader.ReadBytes(16);
            this.flagResetStopDistance = binaryReader.ReadSingle();
            this.bombExplodeEffect = binaryReader.ReadTagReference();
            this.bombExplodeDmgEffect = binaryReader.ReadTagReference();
            this.bombDefuseEffect = binaryReader.ReadTagReference();
            this.bombDefusalString = binaryReader.ReadStringID();
            this.blockedTeleporterString = binaryReader.ReadStringID();
            this.invalidName_3 = binaryReader.ReadBytes(4);
            this.invalidName_4 = binaryReader.ReadBytes(32);
            this.invalidName_5 = binaryReader.ReadBytes(32);
            this.invalidName_6 = binaryReader.ReadBytes(32);
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
