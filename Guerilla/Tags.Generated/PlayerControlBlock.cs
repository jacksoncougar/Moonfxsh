// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PlayerControlBlock : PlayerControlBlockBase
    {
        public PlayerControlBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 128, Alignment = 4)]
    public class PlayerControlBlockBase : GuerillaBlock
    {
        /// <summary>
        /// how much the crosshair slows over enemies
        /// </summary>
        internal float magnetismFriction;
        /// <summary>
        /// how much the crosshair sticks to enemies
        /// </summary>
        internal float magnetismAdhesion;
        /// <summary>
        /// scales magnetism level for inconsequential targets like infection forms
        /// </summary>
        internal float inconsequentialTargetScale;
        internal byte[] invalidName_;
        /// <summary>
        /// -1..1, 0 is middle of the screen
        /// </summary>
        internal OpenTK.Vector2 crosshairLocation;
        /// <summary>
        /// how long you must be pegged before you start sprinting
        /// </summary>
        internal float secondsToStart;
        /// <summary>
        /// how long you must sprint before you reach top speed
        /// </summary>
        internal float secondsToFullSpeed;
        /// <summary>
        /// how fast being unpegged decays the timer (seconds per second)
        /// </summary>
        internal float decayRate;
        /// <summary>
        /// how much faster we actually go when at full sprint
        /// </summary>
        internal float fullSpeedMultiplier;
        /// <summary>
        /// how far the stick needs to be pressed before being considered pegged
        /// </summary>
        internal float peggedMagnitude;
        /// <summary>
        /// how far off straight up (in degrees) we consider pegged
        /// </summary>
        internal float peggedAngularThreshold;
        internal byte[] invalidName_0;
        internal float lookDefaultPitchRateDegrees;
        internal float lookDefaultYawRateDegrees;
        /// <summary>
        /// magnitude of yaw for pegged acceleration to kick in
        /// </summary>
        internal float lookPegThreshold01;
        /// <summary>
        /// time for a pegged look to reach maximum effect
        /// </summary>
        internal float lookYawAccelerationTimeSeconds;
        /// <summary>
        /// maximum effect of a pegged look (scales last value in the look function below)
        /// </summary>
        internal float lookYawAccelerationScale;
        /// <summary>
        /// time for a pegged look to reach maximum effect
        /// </summary>
        internal float lookPitchAccelerationTimeSeconds;
        /// <summary>
        /// maximum effect of a pegged look (scales last value in the look function below)
        /// </summary>
        internal float lookPitchAccelerationScale;
        /// <summary>
        /// 1 is fast, 0 is none, >1 will probably be really fast
        /// </summary>
        internal float lookAutolevellingScale;
        internal byte[] invalidName_1;
        internal float gravityScale;
        internal byte[] invalidName_2;
        /// <summary>
        /// amount of time player needs to move and not look up or down for autolevelling to kick in
        /// </summary>
        internal short minimumAutolevellingTicks;
        /// <summary>
        /// 0 means the vehicle's up vector is along the ground, 90 means the up vector is pointing straight up:degrees
        /// </summary>
        internal float minimumAngleForVehicleFlipping;
        internal LookFunctionBlock[] lookFunction;
        /// <summary>
        /// time that player needs to press ACTION to register as a HOLD
        /// </summary>
        internal float minimumActionHoldTimeSeconds;
        public override int SerializedSize { get { return 128; } }
        public override int Alignment { get { return 4; } }
        public PlayerControlBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            magnetismFriction = binaryReader.ReadSingle();
            magnetismAdhesion = binaryReader.ReadSingle();
            inconsequentialTargetScale = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(12);
            crosshairLocation = binaryReader.ReadVector2();
            secondsToStart = binaryReader.ReadSingle();
            secondsToFullSpeed = binaryReader.ReadSingle();
            decayRate = binaryReader.ReadSingle();
            fullSpeedMultiplier = binaryReader.ReadSingle();
            peggedMagnitude = binaryReader.ReadSingle();
            peggedAngularThreshold = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
            lookDefaultPitchRateDegrees = binaryReader.ReadSingle();
            lookDefaultYawRateDegrees = binaryReader.ReadSingle();
            lookPegThreshold01 = binaryReader.ReadSingle();
            lookYawAccelerationTimeSeconds = binaryReader.ReadSingle();
            lookYawAccelerationScale = binaryReader.ReadSingle();
            lookPitchAccelerationTimeSeconds = binaryReader.ReadSingle();
            lookPitchAccelerationScale = binaryReader.ReadSingle();
            lookAutolevellingScale = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(8);
            gravityScale = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(2);
            minimumAutolevellingTicks = binaryReader.ReadInt16();
            minimumAngleForVehicleFlipping = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<LookFunctionBlock>(binaryReader));
            minimumActionHoldTimeSeconds = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            lookFunction = ReadBlockArrayData<LookFunctionBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(magnetismFriction);
                binaryWriter.Write(magnetismAdhesion);
                binaryWriter.Write(inconsequentialTargetScale);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(crosshairLocation);
                binaryWriter.Write(secondsToStart);
                binaryWriter.Write(secondsToFullSpeed);
                binaryWriter.Write(decayRate);
                binaryWriter.Write(fullSpeedMultiplier);
                binaryWriter.Write(peggedMagnitude);
                binaryWriter.Write(peggedAngularThreshold);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(lookDefaultPitchRateDegrees);
                binaryWriter.Write(lookDefaultYawRateDegrees);
                binaryWriter.Write(lookPegThreshold01);
                binaryWriter.Write(lookYawAccelerationTimeSeconds);
                binaryWriter.Write(lookYawAccelerationScale);
                binaryWriter.Write(lookPitchAccelerationTimeSeconds);
                binaryWriter.Write(lookPitchAccelerationScale);
                binaryWriter.Write(lookAutolevellingScale);
                binaryWriter.Write(invalidName_1, 0, 8);
                binaryWriter.Write(gravityScale);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(minimumAutolevellingTicks);
                binaryWriter.Write(minimumAngleForVehicleFlipping);
                nextAddress = Guerilla.WriteBlockArray<LookFunctionBlock>(binaryWriter, lookFunction, nextAddress);
                binaryWriter.Write(minimumActionHoldTimeSeconds);
                return nextAddress;
            }
        }
    };
}
