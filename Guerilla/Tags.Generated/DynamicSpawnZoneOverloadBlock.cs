// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class DynamicSpawnZoneOverloadBlock : DynamicSpawnZoneOverloadBlockBase
    {
        public DynamicSpawnZoneOverloadBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class DynamicSpawnZoneOverloadBlockBase : GuerillaBlock
    {
        internal OverloadType overloadType;
        internal byte[] invalidName_;
        internal float innerRadius;
        internal float outerRadius;
        internal float weight;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DynamicSpawnZoneOverloadBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            overloadType = (OverloadType) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            innerRadius = binaryReader.ReadSingle();
            outerRadius = binaryReader.ReadSingle();
            weight = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16) overloadType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(innerRadius);
                binaryWriter.Write(outerRadius);
                binaryWriter.Write(weight);
                return nextAddress;
            }
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