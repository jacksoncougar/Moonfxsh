// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterVehicleBlock : CharacterVehicleBlockBase
    {
        public  CharacterVehicleBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 180, Alignment = 4)]
    public class CharacterVehicleBlockBase  : IGuerilla
    {
        [TagReference("unit")]
        internal Moonfish.Tags.TagReference unit;
        [TagReference("styl")]
        internal Moonfish.Tags.TagReference style;
        internal VehicleFlags vehicleFlags;
        /// <summary>
        /// (Ground vehicles)
        /// </summary>
        internal float aiPathfindingRadiusWorldUnits;
        /// <summary>
        /// (All vehicles) Distance within which goal is considered reached
        /// </summary>
        internal float aiDestinationRadiusWorldUnits;
        /// <summary>
        /// (All vehicles)Distance from goal at which AI starts to decelerate
        /// </summary>
        internal float aiDecelerationDistanceworldUnits;
        /// <summary>
        /// (Warthog, Pelican, Ghost) Idealized average turning radius (should reflect actual vehicle physics)
        /// </summary>
        internal float aiTurningRadius;
        /// <summary>
        /// (Warthog-type) Idealized minimum turning radius (should reflect actual vehicle physics)
        /// </summary>
        internal float aiInnerTurningRadiusTr;
        /// <summary>
        /// (Warthogs, ghosts) Ideal turning radius for rounding turns (barring obstacles, etc.)
        /// </summary>
        internal float aiIdealTurningRadiusTr;
        /// <summary>
        /// (Banshee)
        /// </summary>
        internal float aiBansheeSteeringMaximum;
        /// <summary>
        /// (Warthog, ghosts, wraiths)Maximum steering angle from forward (ultimately controls turning speed)
        /// </summary>
        internal float aiMaxSteeringAngleDegrees;
        /// <summary>
        /// (pelicans, dropships, ghosts, wraiths)Maximum delta in steering angle from one tick to the next (ultimately controls turn acceleration)
        /// </summary>
        internal float aiMaxSteeringDeltaDegrees;
        /// <summary>
        /// (Warthog, ghosts, wraiths)
        /// </summary>
        internal float aiOversteeringScale;
        /// <summary>
        /// (Banshee) Angle to goal at which AI will oversteer
        /// </summary>
        internal Moonfish.Model.Range aiOversteeringBounds;
        /// <summary>
        /// (Ghosts, Dropships) Distance within which Ai will strafe to target (as opposed to turning)
        /// </summary>
        internal float aiSideslipDistance;
        /// <summary>
        /// (Banshee-style) Look-ahead distance for obstacle avoidance
        /// </summary>
        internal float aiAvoidanceDistanceWorldUnits;
        /// <summary>
        /// (Banshees)The minimum urgency with which a turn can be made (urgency = percent of maximum steering delta)
        /// </summary>
        internal float aiMinUrgency01;
        /// <summary>
        /// (All vehicles)
        /// </summary>
        internal float aiThrottleMaximum01;
        /// <summary>
        /// (Warthogs, Dropships, ghosts)scale on throttle when within 'ai deceleration distance' of goal (0...1)
        /// </summary>
        internal float aiGoalMinThrottleScale;
        /// <summary>
        /// (Warthogs, ghosts) Scale on throttle due to nearness to a turn (0...1)
        /// </summary>
        internal float aiTurnMinThrottleScale;
        /// <summary>
        /// (Warthogs, ghosts) Scale on throttle due to facing away from intended direction (0...1)
        /// </summary>
        internal float aiDirectionMinThrottleScale;
        /// <summary>
        /// (warthogs, ghosts) The maximum allowable change in throttle between ticks
        /// </summary>
        internal float aiAccelerationScale01;
        /// <summary>
        /// (dropships, sentinels) The degree of throttle blending between one tick and the next (0 = no blending)
        /// </summary>
        internal float aiThrottleBlend01;
        /// <summary>
        /// (dropships, warthogs, ghosts) About how fast I can go.
        /// </summary>
        internal float theoreticalMaxSpeedWuS;
        /// <summary>
        /// (dropships, warthogs) scale on the difference between desired and actual speed, applied to throttle
        /// </summary>
        internal float errorScale;
        internal float aiAllowableAimDeviationAngle;
        /// <summary>
        /// (All vehicles) The distance at which the tight angle criterion is used for deciding to vehicle charge
        /// </summary>
        internal float aiChargeTightAngleDistance;
        /// <summary>
        /// (All vehicles) Angle cosine within which the target must be when target is closer than tight angle distance in order to charge
        /// </summary>
        internal float aiChargeTightAngle01;
        /// <summary>
        /// (All vehicles) Time delay between vehicle charges
        /// </summary>
        internal float aiChargeRepeatTimeout;
        /// <summary>
        /// (All vehicles) In deciding when to abort vehicle charge, look ahead these many seconds to predict time of contact
        /// </summary>
        internal float aiChargeLookAheadTime;
        /// <summary>
        /// Consider charging the target when it is within this range (0 = infinite distance)
        /// </summary>
        internal float aiChargeConsiderDistance;
        /// <summary>
        /// Abort the charge when the target get more than this far away (0 = never abort)
        /// </summary>
        internal float aiChargeAbortDistance;
        /// <summary>
        /// The ram behavior stops after a maximum of the given number of seconds
        /// </summary>
        internal float vehicleRamTimeout;
        /// <summary>
        /// The ram behavior freezes the vehicle for a given number of seconds after performing the ram
        /// </summary>
        internal float ramParalysisTime;
        /// <summary>
        /// (All vehicles) Trigger a cover when recent damage is above given threshold (damage_vehicle_cover impulse)
        /// </summary>
        internal float aiCoverDamageThreshold;
        /// <summary>
        /// (All vehicles) When executing vehicle-cover, minimum distance from the target to flee to
        /// </summary>
        internal float aiCoverMinDistance;
        /// <summary>
        /// (All vehicles) How long to stay away from the target
        /// </summary>
        internal float aiCoverTime;
        /// <summary>
        /// (All vehicles) Boosting allowed when distance to cover destination is greater then this.
        /// </summary>
        internal float aiCoverMinBoostDistance;
        /// <summary>
        /// If vehicle turtling behavior is enabled, turtling is initiated if 'recent damage' surpasses the given threshold
        /// </summary>
        internal float turtlingRecentDamageThreshold;
        /// <summary>
        /// If the vehicle turtling behavior is enabled, turtling occurs for at least the given time
        /// </summary>
        internal float turtlingMinTimeSeconds;
        /// <summary>
        /// The turtled state times out after the given number of seconds
        /// </summary>
        internal float turtlingTimeoutSeconds;
        internal ObstacleIgnoreSize obstacleIgnoreSize;
        internal byte[] invalidName_;
        internal  CharacterVehicleBlockBase(BinaryReader binaryReader)
        {
            unit = binaryReader.ReadTagReference();
            style = binaryReader.ReadTagReference();
            vehicleFlags = (VehicleFlags)binaryReader.ReadInt32();
            aiPathfindingRadiusWorldUnits = binaryReader.ReadSingle();
            aiDestinationRadiusWorldUnits = binaryReader.ReadSingle();
            aiDecelerationDistanceworldUnits = binaryReader.ReadSingle();
            aiTurningRadius = binaryReader.ReadSingle();
            aiInnerTurningRadiusTr = binaryReader.ReadSingle();
            aiIdealTurningRadiusTr = binaryReader.ReadSingle();
            aiBansheeSteeringMaximum = binaryReader.ReadSingle();
            aiMaxSteeringAngleDegrees = binaryReader.ReadSingle();
            aiMaxSteeringDeltaDegrees = binaryReader.ReadSingle();
            aiOversteeringScale = binaryReader.ReadSingle();
            aiOversteeringBounds = binaryReader.ReadRange();
            aiSideslipDistance = binaryReader.ReadSingle();
            aiAvoidanceDistanceWorldUnits = binaryReader.ReadSingle();
            aiMinUrgency01 = binaryReader.ReadSingle();
            aiThrottleMaximum01 = binaryReader.ReadSingle();
            aiGoalMinThrottleScale = binaryReader.ReadSingle();
            aiTurnMinThrottleScale = binaryReader.ReadSingle();
            aiDirectionMinThrottleScale = binaryReader.ReadSingle();
            aiAccelerationScale01 = binaryReader.ReadSingle();
            aiThrottleBlend01 = binaryReader.ReadSingle();
            theoreticalMaxSpeedWuS = binaryReader.ReadSingle();
            errorScale = binaryReader.ReadSingle();
            aiAllowableAimDeviationAngle = binaryReader.ReadSingle();
            aiChargeTightAngleDistance = binaryReader.ReadSingle();
            aiChargeTightAngle01 = binaryReader.ReadSingle();
            aiChargeRepeatTimeout = binaryReader.ReadSingle();
            aiChargeLookAheadTime = binaryReader.ReadSingle();
            aiChargeConsiderDistance = binaryReader.ReadSingle();
            aiChargeAbortDistance = binaryReader.ReadSingle();
            vehicleRamTimeout = binaryReader.ReadSingle();
            ramParalysisTime = binaryReader.ReadSingle();
            aiCoverDamageThreshold = binaryReader.ReadSingle();
            aiCoverMinDistance = binaryReader.ReadSingle();
            aiCoverTime = binaryReader.ReadSingle();
            aiCoverMinBoostDistance = binaryReader.ReadSingle();
            turtlingRecentDamageThreshold = binaryReader.ReadSingle();
            turtlingMinTimeSeconds = binaryReader.ReadSingle();
            turtlingTimeoutSeconds = binaryReader.ReadSingle();
            obstacleIgnoreSize = (ObstacleIgnoreSize)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(unit);
                binaryWriter.Write(style);
                binaryWriter.Write((Int32)vehicleFlags);
                binaryWriter.Write(aiPathfindingRadiusWorldUnits);
                binaryWriter.Write(aiDestinationRadiusWorldUnits);
                binaryWriter.Write(aiDecelerationDistanceworldUnits);
                binaryWriter.Write(aiTurningRadius);
                binaryWriter.Write(aiInnerTurningRadiusTr);
                binaryWriter.Write(aiIdealTurningRadiusTr);
                binaryWriter.Write(aiBansheeSteeringMaximum);
                binaryWriter.Write(aiMaxSteeringAngleDegrees);
                binaryWriter.Write(aiMaxSteeringDeltaDegrees);
                binaryWriter.Write(aiOversteeringScale);
                binaryWriter.Write(aiOversteeringBounds);
                binaryWriter.Write(aiSideslipDistance);
                binaryWriter.Write(aiAvoidanceDistanceWorldUnits);
                binaryWriter.Write(aiMinUrgency01);
                binaryWriter.Write(aiThrottleMaximum01);
                binaryWriter.Write(aiGoalMinThrottleScale);
                binaryWriter.Write(aiTurnMinThrottleScale);
                binaryWriter.Write(aiDirectionMinThrottleScale);
                binaryWriter.Write(aiAccelerationScale01);
                binaryWriter.Write(aiThrottleBlend01);
                binaryWriter.Write(theoreticalMaxSpeedWuS);
                binaryWriter.Write(errorScale);
                binaryWriter.Write(aiAllowableAimDeviationAngle);
                binaryWriter.Write(aiChargeTightAngleDistance);
                binaryWriter.Write(aiChargeTightAngle01);
                binaryWriter.Write(aiChargeRepeatTimeout);
                binaryWriter.Write(aiChargeLookAheadTime);
                binaryWriter.Write(aiChargeConsiderDistance);
                binaryWriter.Write(aiChargeAbortDistance);
                binaryWriter.Write(vehicleRamTimeout);
                binaryWriter.Write(ramParalysisTime);
                binaryWriter.Write(aiCoverDamageThreshold);
                binaryWriter.Write(aiCoverMinDistance);
                binaryWriter.Write(aiCoverTime);
                binaryWriter.Write(aiCoverMinBoostDistance);
                binaryWriter.Write(turtlingRecentDamageThreshold);
                binaryWriter.Write(turtlingMinTimeSeconds);
                binaryWriter.Write(turtlingTimeoutSeconds);
                binaryWriter.Write((Int16)obstacleIgnoreSize);
                binaryWriter.Write(invalidName_, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum VehicleFlags : int
        {
            PassengersAdoptOriginalSquad = 1,
        };
        internal enum ObstacleIgnoreSize : short
        {
            None = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        };
    };
}
