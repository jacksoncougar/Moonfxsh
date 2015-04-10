using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("styl")]
    public  partial class StyleBlock : StyleBlockBase
    {
        public  StyleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class StyleBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal CombatStatusDecayOptions combatStatusDecayOptions;
        internal byte[] invalidName_;
        internal Attitude attitude;
        internal byte[] invalidName_0;
        internal EngageAttitude engageAttitude;
        internal EvasionAttitude evasionAttitude;
        internal CoverAttitude coverAttitude;
        internal SearchAttitude searchAttitude;
        internal PresearchAttitude presearchAttitude;
        internal RetreatAttitude retreatAttitude;
        internal ChargeAttitude chargeAttitude;
        internal ReadyAttitude readyAttitude;
        internal IdleAttitude idleAttitude;
        internal WeaponAttitude weaponAttitude;
        internal SwarmAttitude swarmAttitude;
        internal byte[] invalidName_1;
        internal StyleControl styleControl;
        internal Behaviors1 behaviors1;
        internal Behaviors2 behaviors2;
        internal Behaviors3 behaviors3;
        internal Behaviors4 behaviors4;
        internal Behaviors5 behaviors5;
        internal SpecialMovementBlock[] specialMovement;
        internal BehaviorNamesBlock[] behaviorList;
        internal  StyleBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.combatStatusDecayOptions = (CombatStatusDecayOptions)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.attitude = (Attitude)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.engageAttitude = (EngageAttitude)binaryReader.ReadByte();
            this.evasionAttitude = (EvasionAttitude)binaryReader.ReadByte();
            this.coverAttitude = (CoverAttitude)binaryReader.ReadByte();
            this.searchAttitude = (SearchAttitude)binaryReader.ReadByte();
            this.presearchAttitude = (PresearchAttitude)binaryReader.ReadByte();
            this.retreatAttitude = (RetreatAttitude)binaryReader.ReadByte();
            this.chargeAttitude = (ChargeAttitude)binaryReader.ReadByte();
            this.readyAttitude = (ReadyAttitude)binaryReader.ReadByte();
            this.idleAttitude = (IdleAttitude)binaryReader.ReadByte();
            this.weaponAttitude = (WeaponAttitude)binaryReader.ReadByte();
            this.swarmAttitude = (SwarmAttitude)binaryReader.ReadByte();
            this.invalidName_1 = binaryReader.ReadBytes(1);
            this.styleControl = (StyleControl)binaryReader.ReadInt32();
            this.behaviors1 = (Behaviors1)binaryReader.ReadInt32();
            this.behaviors2 = (Behaviors2)binaryReader.ReadInt32();
            this.behaviors3 = (Behaviors3)binaryReader.ReadInt32();
            this.behaviors4 = (Behaviors4)binaryReader.ReadInt32();
            this.behaviors5 = (Behaviors5)binaryReader.ReadInt32();
            this.specialMovement = ReadSpecialMovementBlockArray(binaryReader);
            this.behaviorList = ReadBehaviorNamesBlockArray(binaryReader);
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
        internal  virtual SpecialMovementBlock[] ReadSpecialMovementBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(SpecialMovementBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new SpecialMovementBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new SpecialMovementBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual BehaviorNamesBlock[] ReadBehaviorNamesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(BehaviorNamesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new BehaviorNamesBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new BehaviorNamesBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum CombatStatusDecayOptions : short
        
        {
            LatchAtIdle = 0,
            LatchAtAlert = 1,
            LatchAtCombat = 2,
        };
        internal enum Attitude : short
        
        {
            Normal = 0,
            Timid = 1,
            Aggressive = 2,
        };
        internal enum EngageAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum EvasionAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum CoverAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum SearchAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum PresearchAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum RetreatAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum ChargeAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum ReadyAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum IdleAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum WeaponAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        internal enum SwarmAttitude : byte
        
        {
            Default = 0,
            Normal = 1,
            Timid = 2,
            Aggressive = 3,
        };
        [FlagsAttribute]
        internal enum StyleControl : int
        
        {
            NewBehaviorsDefaultToON = 1,
        };
        [FlagsAttribute]
        internal enum Behaviors1 : int
        
        {
            GENERAL = 1,
            Root = 2,
            Null = 4,
            NullDiscrete = 8,
            Obey = 16,
            Guard = 32,
            FollowBehavior = 64,
            Ready = 128,
            SmashObstacle = 256,
            DestroyObstacle = 512,
            Perch = 1024,
            CoverFriend = 2048,
            BlindPanic = 4096,
            ENGAGE = 8192,
            Engage = 16384,
            Fight = 32768,
            MeleeCharge = 65536,
            MeleeLeapingCharge = 131072,
            Surprise = 262144,
            GrenadeImpulse = 524288,
            AntiVehicleGrenade = 1048576,
            Stalk = 2097152,
            BerserkWanderImpulse = 4194304,
            BERSERK = 8388608,
            LastManBerserk = 16777216,
            StuckWithGrenadeBerserk = 33554432,
            PRESEARCH = 67108864,
            Presearch = 134217728,
            PresearchUncover = 268435456,
            DestroyCover = 536870912,
            SuppressingFire = 1073741824,
            GrenadeUncover = -2147483648,
        };
        [FlagsAttribute]
        internal enum Behaviors2 : int
        
        {
            LeapOnCover = 1,
            SEARCH = 2,
            Search = 4,
            Uncover = 8,
            Investigate = 16,
            PursuitSync = 32,
            Pursuit = 64,
            Postsearch = 128,
            CovermeInvestigate = 256,
            SELFDEFENSE = 512,
            SelfPreservation = 1024,
            Cover = 2048,
            CoverPeek = 4096,
            Avoid = 8192,
            EvasionImpulse = 16384,
            DiveImpulse = 32768,
            DangerCoverImpulse = 65536,
            DangerCrouchImpulse = 131072,
            ProximityMelee = 262144,
            ProximitySelfPreservation = 524288,
            UnreachableEnemyCover = 1048576,
            ScaryTargetCover = 2097152,
            GroupEmerge = 4194304,
            RETREAT = 8388608,
            Retreat = 16777216,
            RetreatGrenade = 33554432,
            Flee = 67108864,
            Cower = 134217728,
            LowShieldRetreat = 268435456,
            ScaryTargetRetreat = 536870912,
            LeaderDeadRetreat = 1073741824,
            PeerDeadRetreat = -2147483648,
        };
        [FlagsAttribute]
        internal enum Behaviors3 : int
        
        {
            DangerRetreat = 1,
            ProximityRetreat = 2,
            ChargeWhenCornered = 4,
            SurpriseRetreat = 8,
            OverheatedWeaponRetreat = 16,
            AMBUSH = 32,
            Ambush = 64,
            CoordinatedAmbush = 128,
            ProximityAmbush = 256,
            VulnerableEnemyAmbush = 512,
            NowhereToRunAmbush = 1024,
            VEHICLE = 2048,
            Vehicle = 4096,
            EnterFriendlyVehicle = 8192,
            ReEnterFlippedVehicle = 16384,
            VehicleEntryEngageImpulse = 32768,
            VehicleBoard = 65536,
            VehicleFight = 131072,
            VehicleCharge = 262144,
            VehicleRamBehavior = 524288,
            VehicleCover = 1048576,
            DamageVehicleCover = 2097152,
            ExposedRearCoverImpulse = 4194304,
            PlayerEndageredCoverImpulse = 8388608,
            VehicleAvoid = 16777216,
            VehiclePickup = 33554432,
            VehiclePlayerPickup = 67108864,
            VehicleExitImpulse = 134217728,
            DangerVehicleExitImpulse = 268435456,
            VehicleFlip = 536870912,
            VehicleTurtle = 1073741824,
            VehicleEngagePatrolImpulse = -2147483648,
        };
        [FlagsAttribute]
        internal enum Behaviors4 : int
        
        {
            VehicleEngageWanderImpulse = 1,
            POSTCOMBAT = 2,
            Postcombat = 4,
            PostPostcombat = 8,
            CheckFriend = 16,
            ShootCorpse = 32,
            PostcombatApproach = 64,
            ALERT = 128,
            Alert = 256,
            IDLE = 512,
            Idle = 1024,
            WanderBehavior = 2048,
            FlightWander = 4096,
            Patrol = 8192,
            FallSleep = 16384,
            BUGGERS = 32768,
            BuggerGroundUncover = 65536,
            SWARMS = 131072,
            SwarmRoot = 262144,
            SwarmAttack = 524288,
            SupportAttack = 1048576,
            Infect = 2097152,
            Scatter = 4194304,
            EjectParasite = 8388608,
            FloodSelfPreservation = 16777216,
            JuggernautFlurry = 33554432,
            SENTINELS = 67108864,
            EnforcerWeaponControl = 134217728,
            Grapple = 268435456,
            SPECIAL = 536870912,
            Formation = 1073741824,
            GruntScaredByElite = -2147483648,
        };
        [FlagsAttribute]
        internal enum Behaviors5 : int
        
        {
            Stunned = 1,
            CureIsolation = 2,
            DeployTurret = 4,
            InvalidName = 8,
            InvalidName0 = 16,
            InvalidName1 = 32,
            InvalidName2 = 64,
            InvalidName3 = 128,
            InvalidName4 = 256,
            InvalidName5 = 512,
            InvalidName6 = 1024,
            InvalidName7 = 2048,
            InvalidName8 = 4096,
            InvalidName9 = 8192,
            InvalidName10 = 16384,
            InvalidName11 = 32768,
            InvalidName12 = 65536,
            InvalidName13 = 131072,
            InvalidName14 = 262144,
            InvalidName15 = 524288,
            InvalidName16 = 1048576,
            InvalidName17 = 2097152,
            InvalidName18 = 4194304,
            InvalidName19 = 8388608,
            InvalidName20 = 16777216,
            InvalidName21 = 33554432,
            InvalidName22 = 67108864,
            InvalidName23 = 134217728,
            InvalidName24 = 268435456,
            InvalidName25 = 536870912,
            InvalidName26 = 1073741824,
            InvalidName27 = -2147483648,
        };
    };
}
