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
    
    public partial class FlockDefinitionBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.ShortBlockIndex1 Bsp;
        private byte[] fieldpad = new byte[2];
        public Moonfish.Tags.ShortBlockIndex1 BoundingVolume;
        public Flags FlockDefinitionFlags;
        public float EcologyMargin;
        public FlockSourceBlock[] Sources = new FlockSourceBlock[0];
        public FlockSinkBlock[] Sinks = new FlockSinkBlock[0];
        public float ProductionFrequency;
        public Moonfish.Model.Range Scale;
        [Moonfish.Tags.TagReferenceAttribute("crea")]
        public Moonfish.Tags.TagReference Creature;
        public int BoidCount;
        /// <summary>
        /// Flocks with a neighborhood radius of 0 don't FLOCK, per se (in the creature-creature interaction kind of way), but they are much cheaper. The best thing is to have a non-zero radius for small flocks, and a zero radius for large flocks (or for 'flow-flocks', ones with sources and sinks that are intended to create a steady flow of something). Note also that for flocks with a 0 neighborhood radius, the parameters for avoidance, alignment, position and perception angle are ignored entirely.
        /// </summary>
        public float NeighborhoodRadius;
        public float AvoidanceRadius;
        public float ForwardScale;
        public float AlignmentScale;
        public float AvoidanceScale;
        public float LevelingForceScale;
        public float SinkScale;
        public float PerceptionAngle;
        public float AverageThrottle;
        public float MaximumThrottle;
        public float PositionScale;
        public float PositionMinRadius;
        public float PositionMaxRadius;
        public float MovementWeightThreshold;
        public float DangerRadius;
        public float DangerScale;
        /// <summary>
        /// Recommended initial values: 
        ///	random offset scale= 0.2 
        ///	offset period bounds= 1, 3
        /// </summary>
        public float RandomOffsetScale;
        public Moonfish.Model.Range RandomOffsetPeriod;
        public Moonfish.Tags.StringIdent FlockName;
        public override int SerializedSize
        {
            get
            {
                return 132;
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
            this.Bsp = binaryReader.ReadShortBlockIndex1();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.BoundingVolume = binaryReader.ReadShortBlockIndex1();
            this.FlockDefinitionFlags = ((Flags)(binaryReader.ReadInt16()));
            this.EcologyMargin = binaryReader.ReadSingle();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            this.ProductionFrequency = binaryReader.ReadSingle();
            this.Scale = binaryReader.ReadRange();
            this.Creature = binaryReader.ReadTagReference();
            this.BoidCount = binaryReader.ReadInt32();
            this.NeighborhoodRadius = binaryReader.ReadSingle();
            this.AvoidanceRadius = binaryReader.ReadSingle();
            this.ForwardScale = binaryReader.ReadSingle();
            this.AlignmentScale = binaryReader.ReadSingle();
            this.AvoidanceScale = binaryReader.ReadSingle();
            this.LevelingForceScale = binaryReader.ReadSingle();
            this.SinkScale = binaryReader.ReadSingle();
            this.PerceptionAngle = binaryReader.ReadSingle();
            this.AverageThrottle = binaryReader.ReadSingle();
            this.MaximumThrottle = binaryReader.ReadSingle();
            this.PositionScale = binaryReader.ReadSingle();
            this.PositionMinRadius = binaryReader.ReadSingle();
            this.PositionMaxRadius = binaryReader.ReadSingle();
            this.MovementWeightThreshold = binaryReader.ReadSingle();
            this.DangerRadius = binaryReader.ReadSingle();
            this.DangerScale = binaryReader.ReadSingle();
            this.RandomOffsetScale = binaryReader.ReadSingle();
            this.RandomOffsetPeriod = binaryReader.ReadRange();
            this.FlockName = binaryReader.ReadStringID();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Sources = base.ReadBlockArrayData<FlockSourceBlock>(binaryReader, pointerQueue.Dequeue());
            this.Sinks = base.ReadBlockArrayData<FlockSinkBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Sources);
            queueableBinaryWriter.QueueWrite(this.Sinks);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Bsp);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.BoundingVolume);
            queueableBinaryWriter.Write(((short)(this.FlockDefinitionFlags)));
            queueableBinaryWriter.Write(this.EcologyMargin);
            queueableBinaryWriter.WritePointer(this.Sources);
            queueableBinaryWriter.WritePointer(this.Sinks);
            queueableBinaryWriter.Write(this.ProductionFrequency);
            queueableBinaryWriter.Write(this.Scale);
            queueableBinaryWriter.Write(this.Creature);
            queueableBinaryWriter.Write(this.BoidCount);
            queueableBinaryWriter.Write(this.NeighborhoodRadius);
            queueableBinaryWriter.Write(this.AvoidanceRadius);
            queueableBinaryWriter.Write(this.ForwardScale);
            queueableBinaryWriter.Write(this.AlignmentScale);
            queueableBinaryWriter.Write(this.AvoidanceScale);
            queueableBinaryWriter.Write(this.LevelingForceScale);
            queueableBinaryWriter.Write(this.SinkScale);
            queueableBinaryWriter.Write(this.PerceptionAngle);
            queueableBinaryWriter.Write(this.AverageThrottle);
            queueableBinaryWriter.Write(this.MaximumThrottle);
            queueableBinaryWriter.Write(this.PositionScale);
            queueableBinaryWriter.Write(this.PositionMinRadius);
            queueableBinaryWriter.Write(this.PositionMaxRadius);
            queueableBinaryWriter.Write(this.MovementWeightThreshold);
            queueableBinaryWriter.Write(this.DangerRadius);
            queueableBinaryWriter.Write(this.DangerScale);
            queueableBinaryWriter.Write(this.RandomOffsetScale);
            queueableBinaryWriter.Write(this.RandomOffsetPeriod);
            queueableBinaryWriter.Write(this.FlockName);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            HardBoundariesOnVolume = 1,
            FlockInitiallyStopped = 2,
        }
    }
}
