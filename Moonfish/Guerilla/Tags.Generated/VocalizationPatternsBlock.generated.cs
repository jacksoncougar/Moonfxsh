//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class VocalizationPatternsBlock : GuerillaBlock, IWriteQueueable
    {
        public DialogueTypeEnum DialogueType;
        public short VocalizationIndex;
        public Moonfish.Tags.StringIdent VocalizationName;
        public SpeakerTypeEnum SpeakerType;
        public Flags VocalizationPatternsFlags;
        public ListenertargetEnum Listenertarget;
        private byte[] fieldpad = new byte[2];
        private byte[] fieldpad0 = new byte[4];
        public HostilityEnum Hostility;
        public DamageTypeEnum DamageType;
        public DangerLevelEnum DangerLevel;
        public AttitudeEnum Attitude;
        private byte[] fieldpad1 = new byte[4];
        public SubjectActorTypeEnum SubjectActorType;
        public CauseActorTypeEnum CauseActorType;
        public CauseTypeEnum CauseType;
        public SubjectTypeEnum SubjectType;
        public Moonfish.Tags.StringIdent CauseAiTypeName;
        public SpatialRelationEnum SpatialRelation;
        private byte[] fieldpad2 = new byte[2];
        public Moonfish.Tags.StringIdent SubjectAiTypeName;
        private byte[] fieldpad3 = new byte[8];
        public Conditions VocalizationPatternsConditions;
        public override int SerializedSize
        {
            get
            {
                return 64;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.DialogueType = ((DialogueTypeEnum)(binaryReader.ReadInt16()));
            this.VocalizationIndex = binaryReader.ReadInt16();
            this.VocalizationName = binaryReader.ReadStringIdent();
            this.SpeakerType = ((SpeakerTypeEnum)(binaryReader.ReadInt16()));
            this.VocalizationPatternsFlags = ((Flags)(binaryReader.ReadInt16()));
            this.Listenertarget = ((ListenertargetEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.fieldpad0 = binaryReader.ReadBytes(4);
            this.Hostility = ((HostilityEnum)(binaryReader.ReadInt16()));
            this.DamageType = ((DamageTypeEnum)(binaryReader.ReadInt16()));
            this.DangerLevel = ((DangerLevelEnum)(binaryReader.ReadInt16()));
            this.Attitude = ((AttitudeEnum)(binaryReader.ReadInt16()));
            this.fieldpad1 = binaryReader.ReadBytes(4);
            this.SubjectActorType = ((SubjectActorTypeEnum)(binaryReader.ReadInt16()));
            this.CauseActorType = ((CauseActorTypeEnum)(binaryReader.ReadInt16()));
            this.CauseType = ((CauseTypeEnum)(binaryReader.ReadInt16()));
            this.SubjectType = ((SubjectTypeEnum)(binaryReader.ReadInt16()));
            this.CauseAiTypeName = binaryReader.ReadStringIdent();
            this.SpatialRelation = ((SpatialRelationEnum)(binaryReader.ReadInt16()));
            this.fieldpad2 = binaryReader.ReadBytes(2);
            this.SubjectAiTypeName = binaryReader.ReadStringIdent();
            this.fieldpad3 = binaryReader.ReadBytes(8);
            this.VocalizationPatternsConditions = ((Conditions)(binaryReader.ReadInt32()));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((short)(this.DialogueType)));
            queueableBlamBinaryWriter.Write(this.VocalizationIndex);
            queueableBlamBinaryWriter.Write(this.VocalizationName);
            queueableBlamBinaryWriter.Write(((short)(this.SpeakerType)));
            queueableBlamBinaryWriter.Write(((short)(this.VocalizationPatternsFlags)));
            queueableBlamBinaryWriter.Write(((short)(this.Listenertarget)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(((short)(this.Hostility)));
            queueableBlamBinaryWriter.Write(((short)(this.DamageType)));
            queueableBlamBinaryWriter.Write(((short)(this.DangerLevel)));
            queueableBlamBinaryWriter.Write(((short)(this.Attitude)));
            queueableBlamBinaryWriter.Write(this.fieldpad1);
            queueableBlamBinaryWriter.Write(((short)(this.SubjectActorType)));
            queueableBlamBinaryWriter.Write(((short)(this.CauseActorType)));
            queueableBlamBinaryWriter.Write(((short)(this.CauseType)));
            queueableBlamBinaryWriter.Write(((short)(this.SubjectType)));
            queueableBlamBinaryWriter.Write(this.CauseAiTypeName);
            queueableBlamBinaryWriter.Write(((short)(this.SpatialRelation)));
            queueableBlamBinaryWriter.Write(this.fieldpad2);
            queueableBlamBinaryWriter.Write(this.SubjectAiTypeName);
            queueableBlamBinaryWriter.Write(this.fieldpad3);
            queueableBlamBinaryWriter.Write(((int)(this.VocalizationPatternsConditions)));
        }
        public enum DialogueTypeEnum : short
        {
            Death = 0,
            Unused = 1,
            Unused0 = 2,
            Damage = 3,
            DamageUnused1 = 4,
            DamageUnused2 = 5,
            SightedNew = 6,
            SightedNewMajor = 7,
            Unused1 = 8,
            SightedOld = 9,
            SightedFirst = 10,
            SightedSpecial = 11,
            Unused2 = 12,
            HeardNew = 13,
            Unused3 = 14,
            HeardOld = 15,
            Unused4 = 16,
            Unused5 = 17,
            Unused6 = 18,
            AcknowledgeMultiple = 19,
            Unused7 = 20,
            Unused8 = 21,
            Unused9 = 22,
            FoundUnit = 23,
            FoundUnitPresearch = 24,
            FoundUnitPursuit = 25,
            FoundUnitSelfPreserving = 26,
            FoundUnitRetreating = 27,
            ThrowingGrenade = 28,
            NoticedGrenade = 29,
            Fighting = 30,
            Charging = 31,
            SuppressingFire = 32,
            GrenadeUncover = 33,
            Unused10 = 34,
            Unused11 = 35,
            Dive = 36,
            Evade = 37,
            Avoid = 38,
            Surprised = 39,
            Unused12 = 40,
            Unused13 = 41,
            Presearch = 42,
            PresearchStart = 43,
            Search = 44,
            SearchStart = 45,
            InvestigateFailed = 46,
            UncoverFailed = 47,
            PursuitFailed = 48,
            InvestigateStart = 49,
            AbandonedSearchSpace = 50,
            AbandonedSearchTime = 51,
            PresearchFailed = 52,
            AbandonedSearchRestricted = 53,
            InvestigatePursuitStart = 54,
            PostcombatInspectBody = 55,
            VehicleSlowDown = 56,
            VehicleGetIn = 57,
            Idle = 58,
            Taunt = 59,
            TauntReply = 60,
            Retreat = 61,
            RetreatFromScaryTarget = 62,
            RetreatFromDeadLeader = 63,
            RetreatFromProximity = 64,
            RetreatFromLowShield = 65,
            Flee = 66,
            Cowering = 67,
            Unused14 = 68,
            Unused15 = 69,
            Unused16 = 70,
            Cover = 71,
            Covered = 72,
            Unused17 = 73,
            Unused18 = 74,
            Unused19 = 75,
            PursuitStart = 76,
            PursuitSyncStart = 77,
            PursuitSyncJoin = 78,
            PursuitSyncQuorum = 79,
            Melee = 80,
            Unused20 = 81,
            Unused21 = 82,
            Unused22 = 83,
            VehicleFalling = 84,
            VehicleWoohoo = 85,
            VehicleScared = 86,
            VehicleCrazy = 87,
            Unused23 = 88,
            Unused24 = 89,
            Leap = 90,
            Unused25 = 91,
            Unused26 = 92,
            PostcombatWin = 93,
            PostcombatLose = 94,
            PostcombatNeutral = 95,
            ShootCorpse = 96,
            PostcombatStart = 97,
            InspectBodyStart = 98,
            PostcombatStatus = 99,
            Unused27 = 100,
            VehicleEntryStartDriver = 101,
            VehicleEnter = 102,
            VehicleEntryStartGun = 103,
            VehicleEntryStartPassenger = 104,
            VehicleExit = 105,
            EvictDriver = 106,
            EvictGunner = 107,
            EvictPassenger = 108,
            Unused28 = 109,
            Unused29 = 110,
            NewOrderAdvance = 111,
            NewOrderCharge = 112,
            NewOrderFallback = 113,
            NewOrderRetreat = 114,
            NewOrderMoveon = 115,
            NewOrderArrival = 116,
            NewOrderEntervcl = 117,
            NewOrderExitvcl = 118,
            NewOrderFllplr = 119,
            NewOrderLeaveplr = 120,
            NewOrderSupport = 121,
            Unused30 = 122,
            Unused31 = 123,
            Unused32 = 124,
            Unused33 = 125,
            Unused34 = 126,
            Unused35 = 127,
            Unused36 = 128,
            Unused37 = 129,
            Unused38 = 130,
            Unused39 = 131,
            Unused40 = 132,
            Unused41 = 133,
            Emerge = 134,
            Unused42 = 135,
            Unused43 = 136,
            Unused44 = 137,
            Curse = 138,
            Unused45 = 139,
            Unused46 = 140,
            Unused47 = 141,
            Threaten = 142,
            Unused48 = 143,
            Unused49 = 144,
            Unused50 = 145,
            CoverFriend = 146,
            Unused51 = 147,
            Unused52 = 148,
            Unused53 = 149,
            Strike = 150,
            Unused54 = 151,
            Unused55 = 152,
            Unused56 = 153,
            Unused57 = 154,
            Unused58 = 155,
            Unused59 = 156,
            Unused60 = 157,
            Unused61 = 158,
            Gloat = 159,
            Unused62 = 160,
            Unused63 = 161,
            Unused64 = 162,
            Greet = 163,
            Unused65 = 164,
            Unused66 = 165,
            Unused67 = 166,
            Unused68 = 167,
            PlayerLook = 168,
            PlayerLookLongtime = 169,
            Unused69 = 170,
            Unused70 = 171,
            Unused71 = 172,
            Unused72 = 173,
            PanicGrenadeAttached = 174,
            Unused73 = 175,
            Unused74 = 176,
            Unused75 = 177,
            Unused76 = 178,
            HelpResponse = 179,
            Unused77 = 180,
            Unused78 = 181,
            Unused79 = 182,
            Remind = 183,
            Unused80 = 184,
            Unused81 = 185,
            Unused82 = 186,
            Unused83 = 187,
            WeaponTradeBetter = 188,
            WeaponTradeWorse = 189,
            WeaponReadeEqual = 190,
            Unused84 = 191,
            Unused85 = 192,
            Unused86 = 193,
            Betray = 194,
            Unused87 = 195,
            Forgive = 196,
            Unused88 = 197,
            Reanimate = 198,
            Unused89 = 199,
        }
        public enum SpeakerTypeEnum : short
        {
            Subject = 0,
            Cause = 1,
            Friend = 2,
            Target = 3,
            Enemy = 4,
            Vehicle = 5,
            Joint = 6,
            Squad = 7,
            Leader = 8,
            JointLeader = 9,
            Clump = 10,
            Peer = 11,
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            SubjectVisible = 1,
            CauseVisible = 2,
            FriendsPresent = 4,
            SubjectIsSpeakersTarget = 8,
            CauseIsSpeakersTarget = 16,
            CauseIsPlayerOrSpeakerIsPlayerAlly = 32,
            SpeakerIsSearching = 64,
            SpeakerIsFollowingPlayer = 128,
            CauseIsPrimaryPlayerAlly = 256,
        }
        public enum ListenertargetEnum : short
        {
            Subject = 0,
            Cause = 1,
            Friend = 2,
            Target = 3,
            Enemy = 4,
            Vehicle = 5,
            Joint = 6,
            Squad = 7,
            Leader = 8,
            JointLeader = 9,
            Clump = 10,
            Peer = 11,
        }
        public enum HostilityEnum : short
        {
            NONE = 0,
            Self = 1,
            Neutral = 2,
            Friend = 3,
            Enemy = 4,
            Traitor = 5,
        }
        public enum DamageTypeEnum : short
        {
            NONE = 0,
            Falling = 1,
            Bullet = 2,
            Grenade = 3,
            Explosive = 4,
            Sniper = 5,
            Melee = 6,
            Flame = 7,
            MountedWeapon = 8,
            Vehicle = 9,
            Plasma = 10,
            Needle = 11,
            Shotgun = 12,
        }
        public enum DangerLevelEnum : short
        {
            NONE = 0,
            BroadlyFacing = 1,
            ShootingNear = 2,
            ShootingAt = 3,
            ExtremelyClose = 4,
            ShieldDamage = 5,
            ShieldExtendedDamage = 6,
            BodyDamage = 7,
            BodyExtendedDamage = 8,
        }
        public enum AttitudeEnum : short
        {
            Normal = 0,
            Timid = 1,
            Aggressive = 2,
        }
        public enum SubjectActorTypeEnum : short
        {
            NONE = 0,
            Elite = 1,
            Jackal = 2,
            Grunt = 3,
            Hunter = 4,
            Engineer = 5,
            Assassin = 6,
            Player = 7,
            Marine = 8,
            Crew = 9,
            CombatForm = 10,
            InfectionForm = 11,
            CarrierForm = 12,
            Monitor = 13,
            Sentinel = 14,
            None = 15,
            MountedWeapon = 16,
            Brute = 17,
            Prophet = 18,
            Bugger = 19,
            Juggernaut = 20,
        }
        public enum CauseActorTypeEnum : short
        {
            NONE = 0,
            Elite = 1,
            Jackal = 2,
            Grunt = 3,
            Hunter = 4,
            Engineer = 5,
            Assassin = 6,
            Player = 7,
            Marine = 8,
            Crew = 9,
            CombatForm = 10,
            InfectionForm = 11,
            CarrierForm = 12,
            Monitor = 13,
            Sentinel = 14,
            None = 15,
            MountedWeapon = 16,
            Brute = 17,
            Prophet = 18,
            Bugger = 19,
            Juggernaut = 20,
        }
        public enum CauseTypeEnum : short
        {
            NONE = 0,
            Player = 1,
            Actor = 2,
            Biped = 3,
            Body = 4,
            Vehicle = 5,
            Projectile = 6,
            ActorOrPlayer = 7,
            Turret = 8,
            UnitInVehicle = 9,
            UnitInTurret = 10,
            Driver = 11,
            Gunner = 12,
            Passenger = 13,
            Postcombat = 14,
            PostcombatWon = 15,
            PostcombatLost = 16,
            PlayerMasterchief = 17,
            PlayerDervish = 18,
            Heretic = 19,
            MajorlyScary = 20,
            LastManInVehicle = 21,
            Male = 22,
            Female = 23,
            Grenade = 24,
        }
        public enum SubjectTypeEnum : short
        {
            NONE = 0,
            Player = 1,
            Actor = 2,
            Biped = 3,
            Body = 4,
            Vehicle = 5,
            Projectile = 6,
            ActorOrPlayer = 7,
            Turret = 8,
            UnitInVehicle = 9,
            UnitInTurret = 10,
            Driver = 11,
            Gunner = 12,
            Passenger = 13,
            Postcombat = 14,
            PostcombatWon = 15,
            PostcombatLost = 16,
            PlayerMasterchief = 17,
            PlayerDervish = 18,
            Heretic = 19,
            MajorlyScary = 20,
            LastManInVehicle = 21,
            Male = 22,
            Female = 23,
            Grenade = 24,
        }
        public enum SpatialRelationEnum : short
        {
            None = 0,
            VeryNear1wu = 1,
            Near25wus = 2,
            MediumRange5wus = 3,
            Far10wus = 4,
            VeryFar10wus = 5,
            InFrontOf = 6,
            Behind = 7,
            Abovedelta1Wu = 8,
            Belowdelta1Wu = 9,
        }
        [System.FlagsAttribute()]
        public enum Conditions : int
        {
            None = 0,
            Asleep = 1,
            Idle = 2,
            Alert = 4,
            Active = 8,
            UninspectedOrphan = 16,
            DefiniteOrphan = 32,
            CertainOrphan = 64,
            VisibleEnemy = 128,
            ClearLosEnemy = 256,
            DangerousEnemy = 512,
            NoVehicle = 1024,
            VehicleDriver = 2048,
            VehiclePassenger = 4096,
        }
    }
}
