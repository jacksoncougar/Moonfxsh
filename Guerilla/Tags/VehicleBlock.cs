using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vehi")]
    public  partial class VehicleBlock : VehicleBlockBase
    {
        public  VehicleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 276)]
    public class VehicleBlockBase : UnitBlock
    {
        internal Flags flags;
        internal Type type;
        internal Control control;
        internal float maximumForwardSpeed;
        internal float maximumReverseSpeed;
        internal float speedAcceleration;
        internal float speedDeceleration;
        internal float maximumLeftTurn;
        internal float maximumRightTurnNegative;
        internal float wheelCircumference;
        internal float turnRate;
        internal float blurSpeed;
        /// <summary>
        /// if your type corresponds to something in this list choose it
        /// </summary>
        internal SpecificTypeIfYourTypeCorrespondsToSomethingInThisListChooseIt specificType;
        internal PlayerTrainingVehicleType playerTrainingVehicleType;
        internal Moonfish.Tags.StringID flipMessage;
        internal float turnScale;
        internal float speedTurnPenaltyPower052;
        internal float speedTurnPenalty0None1CantTurnAtTopSpeed;
        internal float maximumLeftSlide;
        internal float maximumRightSlide;
        internal float slideAcceleration;
        internal float slideDeceleration;
        internal float minimumFlippingAngularVelocity;
        internal float maximumFlippingAngularVelocity;
        /// <summary>
        /// The size determine what kind of seats in larger vehicles it may occupy (i.e. small or large cargo seats)
        /// </summary>
        internal VehicleSizeTheSizeDetermineWhatKindOfSeatsInLargerVehiclesItMayOccupyIESmallOrLargeCargoSeats vehicleSize;
        internal byte[] invalidName_;
        internal float fixedGunYaw;
        internal float fixedGunPitch;
        internal float overdampenCuspAngleDegrees;
        internal float overdampenExponent;
        internal float crouchTransitionTimeSeconds;
        internal byte[] invalidName_0;
        /// <summary>
        /// higher moments make engine spin up slower
        /// </summary>
        internal float engineMoment;
        /// <summary>
        /// higher moments make engine spin up slower
        /// </summary>
        internal float engineMaxAngularVelocity;
        internal GearBlock[] gears;
        /// <summary>
        /// big vehicles need to scale this down.  0 defaults to 1, which is generally a good value.  This is used with alien fighter physics
        /// </summary>
        internal float flyingTorqueScale;
        /// <summary>
        /// how much do we scale the force the biped the applies down on the seat when he enters. 0 == no acceleration
        /// </summary>
        internal float seatEnteranceAccelerationScale;
        /// <summary>
        /// how much do we scale the force the biped the applies down on the seat when he exits. 0 == no acceleration
        /// </summary>
        internal float seatExitAccelersationScale;
        /// <summary>
        /// human plane physics only. 0 is nothing.  1 is like thowing the engine to full reverse
        /// </summary>
        internal float airFrictionDeceleration;
        /// <summary>
        /// human plane physics only. 0 is default (1)
        /// </summary>
        internal float thrustScale;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference suspensionSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference crashSound;
        [TagReference("foot")]
        internal Moonfish.Tags.TagReference uNUSED;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference specialEffect;
        [TagReference("effe")]
        internal Moonfish.Tags.TagReference unusedEffect;
        internal HavokVehiclePhysicsStructBlock havokVehiclePhysics;
        internal  VehicleBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.type = (Type)binaryReader.ReadInt16();
            this.control = (Control)binaryReader.ReadInt16();
            this.maximumForwardSpeed = binaryReader.ReadSingle();
            this.maximumReverseSpeed = binaryReader.ReadSingle();
            this.speedAcceleration = binaryReader.ReadSingle();
            this.speedDeceleration = binaryReader.ReadSingle();
            this.maximumLeftTurn = binaryReader.ReadSingle();
            this.maximumRightTurnNegative = binaryReader.ReadSingle();
            this.wheelCircumference = binaryReader.ReadSingle();
            this.turnRate = binaryReader.ReadSingle();
            this.blurSpeed = binaryReader.ReadSingle();
            this.specificType = (SpecificTypeIfYourTypeCorrespondsToSomethingInThisListChooseIt)binaryReader.ReadInt16();
            this.playerTrainingVehicleType = (PlayerTrainingVehicleType)binaryReader.ReadInt16();
            this.flipMessage = binaryReader.ReadStringID();
            this.turnScale = binaryReader.ReadSingle();
            this.speedTurnPenaltyPower052 = binaryReader.ReadSingle();
            this.speedTurnPenalty0None1CantTurnAtTopSpeed = binaryReader.ReadSingle();
            this.maximumLeftSlide = binaryReader.ReadSingle();
            this.maximumRightSlide = binaryReader.ReadSingle();
            this.slideAcceleration = binaryReader.ReadSingle();
            this.slideDeceleration = binaryReader.ReadSingle();
            this.minimumFlippingAngularVelocity = binaryReader.ReadSingle();
            this.maximumFlippingAngularVelocity = binaryReader.ReadSingle();
            this.vehicleSize = (VehicleSizeTheSizeDetermineWhatKindOfSeatsInLargerVehiclesItMayOccupyIESmallOrLargeCargoSeats)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.fixedGunYaw = binaryReader.ReadSingle();
            this.fixedGunPitch = binaryReader.ReadSingle();
            this.overdampenCuspAngleDegrees = binaryReader.ReadSingle();
            this.overdampenExponent = binaryReader.ReadSingle();
            this.crouchTransitionTimeSeconds = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.engineMoment = binaryReader.ReadSingle();
            this.engineMaxAngularVelocity = binaryReader.ReadSingle();
            this.gears = ReadGearBlockArray(binaryReader);
            this.flyingTorqueScale = binaryReader.ReadSingle();
            this.seatEnteranceAccelerationScale = binaryReader.ReadSingle();
            this.seatExitAccelersationScale = binaryReader.ReadSingle();
            this.airFrictionDeceleration = binaryReader.ReadSingle();
            this.thrustScale = binaryReader.ReadSingle();
            this.suspensionSound = binaryReader.ReadTagReference();
            this.crashSound = binaryReader.ReadTagReference();
            this.uNUSED = binaryReader.ReadTagReference();
            this.specialEffect = binaryReader.ReadTagReference();
            this.unusedEffect = binaryReader.ReadTagReference();
            this.havokVehiclePhysics = new HavokVehiclePhysicsStructBlock(binaryReader);
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
        internal  virtual GearBlock[] ReadGearBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GearBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GearBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GearBlock(binaryReader);
                }
            }
            return array;
        }
        internal enum Flags : int
        {
            SpeedWakesPhysics = 1,
            TurnWakesPhysics = 2,
            DriverPowerWakesPhysics = 4,
            GunnerPowerWakesPhysics = 8,
            ControlOppositeSpeedSetsBrake = 16,
            SlideWakesPhysics = 32,
            KillsRidersAtTerminalVelocity = 64,
            CausesCollisionDamage = 128,
            AiWeaponCannotRotate = 256,
            AiDoesNotRequireDriver = 512,
            AiUnused = 1024,
            AiDriverEnable = 2048,
            AiDriverFlying = 4096,
            AiDriverCanSidestep = 8192,
            AiDriverHovering = 16384,
            VehicleSteersDirectly = 32768,
            Unused = 65536,
            HasEBrake = 131072,
            NoncombatVehicle = 262144,
            NoFrictionWDriver = 524288,
            CanTriggerAutomaticOpeningDoors = 1048576,
            AutoaimWhenTeamless = 2097152,
        };
        internal enum Type : short
        {
            HumanTank = 0,
            HumanJeep = 1,
            HumanBoat = 2,
            HumanPlane = 3,
            AlienScout = 4,
            AlienFighter = 5,
            Turret = 6,
        };
        internal enum Control : short
        {
            VehicleControlNormal = 0,
            VehicleControlUnused = 1,
            VehicleControlTank = 2,
        };
        internal enum SpecificTypeIfYourTypeCorrespondsToSomethingInThisListChooseIt : short
        {
            None = 0,
            Ghost = 1,
            Wraith = 2,
            Spectre = 3,
            SentinelEnforcer = 4,
        };
        internal enum PlayerTrainingVehicleType : short
        {
            None = 0,
            Warthog = 1,
            WarthogTurret = 2,
            Ghost = 3,
            Banshee = 4,
            Tank = 5,
            Wraith = 6,
        };
        internal enum VehicleSizeTheSizeDetermineWhatKindOfSeatsInLargerVehiclesItMayOccupyIESmallOrLargeCargoSeats : short
        {
            Small = 0,
            Large = 1,
        };
    };
}
