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
    
    [TagClassAttribute("pmov")]
    public partial class ParticlePhysicsBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("pmov")]
        public Moonfish.Tags.TagReference Template;
        public Flags ParticlePhysicsFlags;
        public ParticleController[] Movements = new ParticleController[0];
        public override int SerializedSize
        {
            get
            {
                return 20;
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
            this.Template = binaryReader.ReadTagReference();
            this.ParticlePhysicsFlags = ((Flags)(binaryReader.ReadInt32()));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(20));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Movements = base.ReadBlockArrayData<ParticleController>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Movements);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.Template);
            queueableBinaryWriter.Write(((int)(this.ParticlePhysicsFlags)));
            queueableBinaryWriter.WritePointer(this.Movements);
        }
        [System.FlagsAttribute()]
        public enum Flags : int
        {
            None = 0,
            Physics = 1,
            CollideWithStructure = 2,
            CollideWithMedia = 4,
            CollideWithScenery = 8,
            CollideWithVehicles = 16,
            CollideWithBipeds = 32,
            Swarm = 64,
            Wind = 128,
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Pmov = ((TagClass)("pmov"));
    }
}
