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
    public partial class SquadsBlock : SquadsBlockBase
    {
        public SquadsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 116, Alignment = 4)]
    public class SquadsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Flags flags;
        internal Team team;
        internal Moonfish.Tags.ShortBlockIndex1 parent;
        internal float squadDelayTimeSeconds;

        /// <summary>
        /// initial number of actors on normal difficulty
        /// </summary>
        internal short normalDiffCount;

        /// <summary>
        /// initial number of actors on insane difficulty (hard difficulty is midway between normal and insane)
        /// </summary>
        internal short insaneDiffCount;

        internal MajorUpgrade majorUpgrade;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 vehicleType;
        internal Moonfish.Tags.ShortBlockIndex1 characterType;
        internal Moonfish.Tags.ShortBlockIndex1 initialZone;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.ShortBlockIndex1 initialWeapon;
        internal Moonfish.Tags.ShortBlockIndex1 initialSecondaryWeapon;
        internal GrenadeType grenadeType;
        internal Moonfish.Tags.ShortBlockIndex1 initialOrder;
        internal Moonfish.Tags.StringIdent vehicleVariant;
        internal ActorStartingLocationsBlock[] startingLocations;
        internal Moonfish.Tags.String32 placementScript;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;

        public override int SerializedSize
        {
            get { return 116; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SquadsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            flags = (Flags) binaryReader.ReadInt32();
            team = (Team) binaryReader.ReadInt16();
            parent = binaryReader.ReadShortBlockIndex1();
            squadDelayTimeSeconds = binaryReader.ReadSingle();
            normalDiffCount = binaryReader.ReadInt16();
            insaneDiffCount = binaryReader.ReadInt16();
            majorUpgrade = (MajorUpgrade) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            vehicleType = binaryReader.ReadShortBlockIndex1();
            characterType = binaryReader.ReadShortBlockIndex1();
            initialZone = binaryReader.ReadShortBlockIndex1();
            invalidName_0 = binaryReader.ReadBytes(2);
            initialWeapon = binaryReader.ReadShortBlockIndex1();
            initialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
            grenadeType = (GrenadeType) binaryReader.ReadInt16();
            initialOrder = binaryReader.ReadShortBlockIndex1();
            vehicleVariant = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<ActorStartingLocationsBlock>(binaryReader));
            placementScript = binaryReader.ReadString32();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(2);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            startingLocations = ReadBlockArrayData<ActorStartingLocationsBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int32) flags);
                binaryWriter.Write((Int16) team);
                binaryWriter.Write(parent);
                binaryWriter.Write(squadDelayTimeSeconds);
                binaryWriter.Write(normalDiffCount);
                binaryWriter.Write(insaneDiffCount);
                binaryWriter.Write((Int16) majorUpgrade);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(vehicleType);
                binaryWriter.Write(characterType);
                binaryWriter.Write(initialZone);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(initialWeapon);
                binaryWriter.Write(initialSecondaryWeapon);
                binaryWriter.Write((Int16) grenadeType);
                binaryWriter.Write(initialOrder);
                binaryWriter.Write(vehicleVariant);
                nextAddress = Guerilla.WriteBlockArray<ActorStartingLocationsBlock>(binaryWriter, startingLocations,
                    nextAddress);
                binaryWriter.Write(placementScript);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 2);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            Unused = 1,
            NeverSearch = 2,
            StartTimerImmediately = 4,
            NoTimerDelayForever = 8,
            MagicSightAfterTimer = 16,
            AutomaticMigration = 32,
            DEPRECATED = 64,
            RespawnEnabled = 128,
            Blind = 256,
            Deaf = 512,
            Braindead = 1024,
            InvalidName3DFiringPositions = 2048,
            InitiallyPlaced = 4096,
            UnitsNotEnterableByPlayer = 8192,
        };

        internal enum Team : short
        {
            Default = 0,
            Player = 1,
            Human = 2,
            Covenant = 3,
            Flood = 4,
            Sentinel = 5,
            Heretic = 6,
            Prophet = 7,
            Unused8 = 8,
            Unused9 = 9,
            Unused10 = 10,
            Unused11 = 11,
            Unused12 = 12,
            Unused13 = 13,
            Unused14 = 14,
            Unused15 = 15,
        };

        internal enum MajorUpgrade : short
        {
            Normal = 0,
            Few = 1,
            Many = 2,
            None = 3,
            All = 4,
        };

        internal enum GrenadeType : short
        {
            NONE = 0,
            HumanGrenade = 1,
            CovenantPlasma = 2,
        };
    };
}