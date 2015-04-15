// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class FlockDefinitionBlock : FlockDefinitionBlockBase
    {
        public  FlockDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 132, Alignment = 4)]
    public class FlockDefinitionBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 bsp;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 boundingVolume;
        internal Flags flags;
        /// <summary>
        /// distance from ecology boundary that creature begins to be repulsed
        /// </summary>
        internal float ecologyMarginWus;
        internal FlockSourceBlock[] sources;
        internal FlockSinkBlock[] sinks;
        /// <summary>
        /// How frequently boids are produced at one of the sources (limited by the max boid count)
        /// </summary>
        internal float productionFrequencyBoidsSec;
        internal Moonfish.Model.Range scale;
        [TagReference("crea")]
        internal Moonfish.Tags.TagReference creature;
        internal int boidCount;
        /// <summary>
        /// distance within which one boid is affected by another
        /// </summary>
        internal float neighborhoodRadiusWorldUnits;
        /// <summary>
        /// distance that a boid tries to maintain from another
        /// </summary>
        internal float avoidanceRadiusWorldUnits;
        /// <summary>
        /// weight given to boid's desire to fly straight ahead
        /// </summary>
        internal float forwardScale01;
        /// <summary>
        /// weight given to boid's desire to align itself with neighboring boids
        /// </summary>
        internal float alignmentScale01;
        /// <summary>
        /// weight given to boid's desire to avoid collisions with other boids, when within the avoidance radius
        /// </summary>
        internal float avoidanceScale01;
        /// <summary>
        /// weight given to boids desire to fly level
        /// </summary>
        internal float levelingForceScale01;
        /// <summary>
        /// weight given to boid's desire to fly towards its sinks
        /// </summary>
        internal float sinkScale01;
        /// <summary>
        /// angle-from-forward within which one boid can perceive and react to another
        /// </summary>
        internal float perceptionAngleDegrees;
        /// <summary>
        /// throttle at which boids will naturally fly
        /// </summary>
        internal float averageThrottle01;
        /// <summary>
        /// maximum throttle applicable
        /// </summary>
        internal float maximumThrottle01;
        /// <summary>
        /// weight given to boid's desire to be near flock center
        /// </summary>
        internal float positionScale01;
        /// <summary>
        /// distance to flock center beyond which an attracting force is applied
        /// </summary>
        internal float positionMinRadiusWus;
        /// <summary>
        /// distance to flock center at which the maximum attracting force is applied
        /// </summary>
        internal float positionMaxRadiusWus;
        /// <summary>
        /// The threshold of accumulated weight over which movement occurs
        /// </summary>
        internal float movementWeightThreshold;
        /// <summary>
        /// distance within which boids will avoid a dangerous object (e.g. the player)
        /// </summary>
        internal float dangerRadiusWus;
        /// <summary>
        /// weight given to boid's desire to avoid danger
        /// </summary>
        internal float dangerScale;
        /// <summary>
        /// weight given to boid's random heading offset
        /// </summary>
        internal float randomOffsetScale01;
        internal Moonfish.Model.Range randomOffsetPeriodSeconds;
        internal Moonfish.Tags.StringID flockName;
        internal  FlockDefinitionBlockBase(BinaryReader binaryReader)
        {
            bsp = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            boundingVolume = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt16();
            ecologyMarginWus = binaryReader.ReadSingle();
            sources = Guerilla.ReadBlockArray<FlockSourceBlock>(binaryReader);
            sinks = Guerilla.ReadBlockArray<FlockSinkBlock>(binaryReader);
            productionFrequencyBoidsSec = binaryReader.ReadSingle();
            scale = binaryReader.ReadRange();
            creature = binaryReader.ReadTagReference();
            boidCount = binaryReader.ReadInt32();
            neighborhoodRadiusWorldUnits = binaryReader.ReadSingle();
            avoidanceRadiusWorldUnits = binaryReader.ReadSingle();
            forwardScale01 = binaryReader.ReadSingle();
            alignmentScale01 = binaryReader.ReadSingle();
            avoidanceScale01 = binaryReader.ReadSingle();
            levelingForceScale01 = binaryReader.ReadSingle();
            sinkScale01 = binaryReader.ReadSingle();
            perceptionAngleDegrees = binaryReader.ReadSingle();
            averageThrottle01 = binaryReader.ReadSingle();
            maximumThrottle01 = binaryReader.ReadSingle();
            positionScale01 = binaryReader.ReadSingle();
            positionMinRadiusWus = binaryReader.ReadSingle();
            positionMaxRadiusWus = binaryReader.ReadSingle();
            movementWeightThreshold = binaryReader.ReadSingle();
            dangerRadiusWus = binaryReader.ReadSingle();
            dangerScale = binaryReader.ReadSingle();
            randomOffsetScale01 = binaryReader.ReadSingle();
            randomOffsetPeriodSeconds = binaryReader.ReadRange();
            flockName = binaryReader.ReadStringID();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bsp);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(boundingVolume);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(ecologyMarginWus);
                nextAddress = Guerilla.WriteBlockArray<FlockSourceBlock>(binaryWriter, sources, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<FlockSinkBlock>(binaryWriter, sinks, nextAddress);
                binaryWriter.Write(productionFrequencyBoidsSec);
                binaryWriter.Write(scale);
                binaryWriter.Write(creature);
                binaryWriter.Write(boidCount);
                binaryWriter.Write(neighborhoodRadiusWorldUnits);
                binaryWriter.Write(avoidanceRadiusWorldUnits);
                binaryWriter.Write(forwardScale01);
                binaryWriter.Write(alignmentScale01);
                binaryWriter.Write(avoidanceScale01);
                binaryWriter.Write(levelingForceScale01);
                binaryWriter.Write(sinkScale01);
                binaryWriter.Write(perceptionAngleDegrees);
                binaryWriter.Write(averageThrottle01);
                binaryWriter.Write(maximumThrottle01);
                binaryWriter.Write(positionScale01);
                binaryWriter.Write(positionMinRadiusWus);
                binaryWriter.Write(positionMaxRadiusWus);
                binaryWriter.Write(movementWeightThreshold);
                binaryWriter.Write(dangerRadiusWus);
                binaryWriter.Write(dangerScale);
                binaryWriter.Write(randomOffsetScale01);
                binaryWriter.Write(randomOffsetPeriodSeconds);
                binaryWriter.Write(flockName);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            HardBoundariesOnVolume = 1,
            FlockInitiallyStopped = 2,
        };
    };
}
