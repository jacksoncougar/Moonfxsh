using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SquadsBlock : SquadsBlockBase
    {
        public  SquadsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 116)]
    public class SquadsBlockBase
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
        internal Moonfish.Tags.StringID vehicleVariant;
        internal ActorStartingLocationsBlock[] startingLocations;
        internal Moonfish.Tags.String32 placementScript;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal  SquadsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.team = (Team)binaryReader.ReadInt16();
            this.parent = binaryReader.ReadShortBlockIndex1();
            this.squadDelayTimeSeconds = binaryReader.ReadSingle();
            this.normalDiffCount = binaryReader.ReadInt16();
            this.insaneDiffCount = binaryReader.ReadInt16();
            this.majorUpgrade = (MajorUpgrade)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.vehicleType = binaryReader.ReadShortBlockIndex1();
            this.characterType = binaryReader.ReadShortBlockIndex1();
            this.initialZone = binaryReader.ReadShortBlockIndex1();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.initialWeapon = binaryReader.ReadShortBlockIndex1();
            this.initialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
            this.grenadeType = (GrenadeType)binaryReader.ReadInt16();
            this.initialOrder = binaryReader.ReadShortBlockIndex1();
            this.vehicleVariant = binaryReader.ReadStringID();
            this.startingLocations = ReadActorStartingLocationsBlockArray(binaryReader);
            this.placementScript = binaryReader.ReadString32();
            this.invalidName_1 = binaryReader.ReadBytes(2);
            this.invalidName_2 = binaryReader.ReadBytes(2);
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
        internal  virtual ActorStartingLocationsBlock[] ReadActorStartingLocationsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ActorStartingLocationsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ActorStartingLocationsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ActorStartingLocationsBlock(binaryReader);
                }
            }
            return array;
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
