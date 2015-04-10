using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DynamicSpawnZoneOverloadBlock : DynamicSpawnZoneOverloadBlockBase
    {
        public  DynamicSpawnZoneOverloadBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class DynamicSpawnZoneOverloadBlockBase
    {
        internal OverloadType overloadType;
        internal byte[] invalidName_;
        internal float innerRadius;
        internal float outerRadius;
        internal float weight;
        internal  DynamicSpawnZoneOverloadBlockBase(BinaryReader binaryReader)
        {
            this.overloadType = (OverloadType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.innerRadius = binaryReader.ReadSingle();
            this.outerRadius = binaryReader.ReadSingle();
            this.weight = binaryReader.ReadSingle();
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
        internal enum OverloadType : short
        
        {
            Enemy = 0,
            Friend = 1,
            EnemyVehicle = 2,
            FriendlyVehicle = 3,
            EmptyVehicle = 4,
            OddballInclusion = 5,
            OddballExclusion = 6,
            HillInclusion = 7,
            HillExclusion = 8,
            LastRaceFlag = 9,
            DeadAlly = 10,
            ControlledTerritory = 11,
        };
    };
}
