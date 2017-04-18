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
    
    public partial class ScenarioObjectDatumStructBlock : GuerillaBlock, IWriteQueueable
    {
        public PlacementFlags ScenarioObjectDatumStructPlacementFlags;
        public OpenTK.Vector3 Position;
        public OpenTK.Vector3 Rotation;
        public float Scale;
        public TransformFlags ScenarioObjectDatumStructTransformFlags;
        public Moonfish.Tags.BlockFlags16 ManualBSPFlags;
        public ScenarioObjectIdStructBlock ObjectID = new ScenarioObjectIdStructBlock();
        public BSPPolicyEnum BSPPolicy;
        private byte[] fieldpad = new byte[1];
        public Moonfish.Tags.ShortBlockIndex1 EditorFolder;
        public override int SerializedSize
        {
            get
            {
                return 48;
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
            this.ScenarioObjectDatumStructPlacementFlags = ((PlacementFlags)(binaryReader.ReadInt32()));
            this.Position = binaryReader.ReadVector3();
            this.Rotation = binaryReader.ReadVector3();
            this.Scale = binaryReader.ReadSingle();
            this.ScenarioObjectDatumStructTransformFlags = ((TransformFlags)(binaryReader.ReadInt16()));
            this.ManualBSPFlags = binaryReader.ReadBlockFlags16();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ObjectID.ReadFields(binaryReader)));
            this.BSPPolicy = ((BSPPolicyEnum)(binaryReader.ReadByte()));
            this.fieldpad = binaryReader.ReadBytes(1);
            this.EditorFolder = binaryReader.ReadShortBlockIndex1();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ObjectID.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.ObjectID.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((int)(this.ScenarioObjectDatumStructPlacementFlags)));
            queueableBlamBinaryWriter.Write(this.Position);
            queueableBlamBinaryWriter.Write(this.Rotation);
            queueableBlamBinaryWriter.Write(this.Scale);
            queueableBlamBinaryWriter.Write(((short)(this.ScenarioObjectDatumStructTransformFlags)));
            queueableBlamBinaryWriter.Write(this.ManualBSPFlags);
            this.ObjectID.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(((byte)(this.BSPPolicy)));
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(this.EditorFolder);
        }
        [System.FlagsAttribute()]
        public enum PlacementFlags : int
        {
            None = 0,
            NotAutomatically = 1,
            Unused = 2,
            Unused0 = 4,
            Unused1 = 8,
            LockTypeToEnvObject = 16,
            LockTransformToEnvObject = 32,
            NeverPlaced = 64,
            LockNameToEnvObject = 128,
            CreateAtRest = 256,
        }
        [System.FlagsAttribute()]
        public enum TransformFlags : short
        {
            None = 0,
            Mirrored = 1,
        }
        public enum BSPPolicyEnum : byte
        {
            Default = 0,
            AlwaysPlaced = 1,
            ManualBSPPlacement = 2,
        }
    }
}
