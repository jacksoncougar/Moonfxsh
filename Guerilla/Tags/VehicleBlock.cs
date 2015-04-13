// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass VehiClass = (TagClass)"vehi";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("vehi")]
    public  partial class VehicleBlock : VehicleBlockBase
    {
        public  VehicleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 276, Alignment = 4)]
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
            flags = (Flags)binaryReader.ReadInt32();
            type = (Type)binaryReader.ReadInt16();
            control = (Control)binaryReader.ReadInt16();
            maximumForwardSpeed = binaryReader.ReadSingle();
            maximumReverseSpeed = binaryReader.ReadSingle();
            speedAcceleration = binaryReader.ReadSingle();
            speedDeceleration = binaryReader.ReadSingle();
            maximumLeftTurn = binaryReader.ReadSingle();
            maximumRightTurnNegative = binaryReader.ReadSingle();
            wheelCircumference = binaryReader.ReadSingle();
            turnRate = binaryReader.ReadSingle();
            blurSpeed = binaryReader.ReadSingle();
            specificType = (SpecificTypeIfYourTypeCorrespondsToSomethingInThisListChooseIt)binaryReader.ReadInt16();
            playerTrainingVehicleType = (PlayerTrainingVehicleType)binaryReader.ReadInt16();
            flipMessage = binaryReader.ReadStringID();
            turnScale = binaryReader.ReadSingle();
            speedTurnPenaltyPower052 = binaryReader.ReadSingle();
            speedTurnPenalty0None1CantTurnAtTopSpeed = binaryReader.ReadSingle();
            maximumLeftSlide = binaryReader.ReadSingle();
            maximumRightSlide = binaryReader.ReadSingle();
            slideAcceleration = binaryReader.ReadSingle();
            slideDeceleration = binaryReader.ReadSingle();
            minimumFlippingAngularVelocity = binaryReader.ReadSingle();
            maximumFlippingAngularVelocity = binaryReader.ReadSingle();
            vehicleSize = (VehicleSizeTheSizeDetermineWhatKindOfSeatsInLargerVehiclesItMayOccupyIESmallOrLargeCargoSeats)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            fixedGunYaw = binaryReader.ReadSingle();
            fixedGunPitch = binaryReader.ReadSingle();
            overdampenCuspAngleDegrees = binaryReader.ReadSingle();
            overdampenExponent = binaryReader.ReadSingle();
            crouchTransitionTimeSeconds = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(4);
            engineMoment = binaryReader.ReadSingle();
            engineMaxAngularVelocity = binaryReader.ReadSingle();
            gears = Guerilla.ReadBlockArray<GearBlock>(binaryReader);
            flyingTorqueScale = binaryReader.ReadSingle();
            seatEnteranceAccelerationScale = binaryReader.ReadSingle();
            seatExitAccelersationScale = binaryReader.ReadSingle();
            airFrictionDeceleration = binaryReader.ReadSingle();
            thrustScale = binaryReader.ReadSingle();
            suspensionSound = binaryReader.ReadTagReference();
            crashSound = binaryReader.ReadTagReference();
            uNUSED = binaryReader.ReadTagReference();
            specialEffect = binaryReader.ReadTagReference();
            unusedEffect = binaryReader.ReadTagReference();
            havokVehiclePhysics = new HavokVehiclePhysicsStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)type);
                binaryWriter.Write((Int16)control);
                binaryWriter.Write(maximumForwardSpeed);
                binaryWriter.Write(maximumReverseSpeed);
                binaryWriter.Write(speedAcceleration);
                binaryWriter.Write(speedDeceleration);
                binaryWriter.Write(maximumLeftTurn);
                binaryWriter.Write(maximumRightTurnNegative);
                binaryWriter.Write(wheelCircumference);
                binaryWriter.Write(turnRate);
                binaryWriter.Write(blurSpeed);
                binaryWriter.Write((Int16)specificType);
                binaryWriter.Write((Int16)playerTrainingVehicleType);
                binaryWriter.Write(flipMessage);
                binaryWriter.Write(turnScale);
                binaryWriter.Write(speedTurnPenaltyPower052);
                binaryWriter.Write(speedTurnPenalty0None1CantTurnAtTopSpeed);
                binaryWriter.Write(maximumLeftSlide);
                binaryWriter.Write(maximumRightSlide);
                binaryWriter.Write(slideAcceleration);
                binaryWriter.Write(slideDeceleration);
                binaryWriter.Write(minimumFlippingAngularVelocity);
                binaryWriter.Write(maximumFlippingAngularVelocity);
                binaryWriter.Write((Int16)vehicleSize);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(fixedGunYaw);
                binaryWriter.Write(fixedGunPitch);
                binaryWriter.Write(overdampenCuspAngleDegrees);
                binaryWriter.Write(overdampenExponent);
                binaryWriter.Write(crouchTransitionTimeSeconds);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(engineMoment);
                binaryWriter.Write(engineMaxAngularVelocity);
                Guerilla.WriteBlockArray<GearBlock>(binaryWriter, gears, nextAddress);
                binaryWriter.Write(flyingTorqueScale);
                binaryWriter.Write(seatEnteranceAccelerationScale);
                binaryWriter.Write(seatExitAccelersationScale);
                binaryWriter.Write(airFrictionDeceleration);
                binaryWriter.Write(thrustScale);
                binaryWriter.Write(suspensionSound);
                binaryWriter.Write(crashSound);
                binaryWriter.Write(uNUSED);
                binaryWriter.Write(specialEffect);
                binaryWriter.Write(unusedEffect);
                havokVehiclePhysics.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
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
