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
    [LayoutAttribute(Size = 132)]
    public class FlockDefinitionBlockBase
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
            this.bsp = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.boundingVolume = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.ecologyMarginWus = binaryReader.ReadSingle();
            this.sources = ReadFlockSourceBlockArray(binaryReader);
            this.sinks = ReadFlockSinkBlockArray(binaryReader);
            this.productionFrequencyBoidsSec = binaryReader.ReadSingle();
            this.scale = binaryReader.ReadRange();
            this.creature = binaryReader.ReadTagReference();
            this.boidCount = binaryReader.ReadInt32();
            this.neighborhoodRadiusWorldUnits = binaryReader.ReadSingle();
            this.avoidanceRadiusWorldUnits = binaryReader.ReadSingle();
            this.forwardScale01 = binaryReader.ReadSingle();
            this.alignmentScale01 = binaryReader.ReadSingle();
            this.avoidanceScale01 = binaryReader.ReadSingle();
            this.levelingForceScale01 = binaryReader.ReadSingle();
            this.sinkScale01 = binaryReader.ReadSingle();
            this.perceptionAngleDegrees = binaryReader.ReadSingle();
            this.averageThrottle01 = binaryReader.ReadSingle();
            this.maximumThrottle01 = binaryReader.ReadSingle();
            this.positionScale01 = binaryReader.ReadSingle();
            this.positionMinRadiusWus = binaryReader.ReadSingle();
            this.positionMaxRadiusWus = binaryReader.ReadSingle();
            this.movementWeightThreshold = binaryReader.ReadSingle();
            this.dangerRadiusWus = binaryReader.ReadSingle();
            this.dangerScale = binaryReader.ReadSingle();
            this.randomOffsetScale01 = binaryReader.ReadSingle();
            this.randomOffsetPeriodSeconds = binaryReader.ReadRange();
            this.flockName = binaryReader.ReadStringID();
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
        internal  virtual FlockSourceBlock[] ReadFlockSourceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FlockSourceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FlockSourceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FlockSourceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual FlockSinkBlock[] ReadFlockSinkBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(FlockSinkBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new FlockSinkBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new FlockSinkBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            HardBoundariesOnVolume = 1,
            FlockInitiallyStopped = 2,
        };
    };
}
