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
    
    public partial class ScenarioSpawnDataBlock : GuerillaBlock, IWriteQueueable
    {
        /// <summary>
        /// Non-0 values here overload what appears in multiplayer_globals.
        /// </summary>
        public float DynamicSpawnLowerHeight;
        public float DynamicSpawnUpperHeight;
        public float GameObjectResetHeight;
        private byte[] fieldpad = new byte[60];
        public DynamicSpawnZoneOverloadBlock[] DynamicSpawnOverloads = new DynamicSpawnZoneOverloadBlock[0];
        public StaticSpawnZoneBlock[] StaticRespawnZones = new StaticSpawnZoneBlock[0];
        public StaticSpawnZoneBlock[] StaticInitialSpawnZones = new StaticSpawnZoneBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 96;
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
            this.DynamicSpawnLowerHeight = binaryReader.ReadSingle();
            this.DynamicSpawnUpperHeight = binaryReader.ReadSingle();
            this.GameObjectResetHeight = binaryReader.ReadSingle();
            this.fieldpad = binaryReader.ReadBytes(60);
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(16));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(48));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(48));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.DynamicSpawnOverloads = base.ReadBlockArrayData<DynamicSpawnZoneOverloadBlock>(binaryReader, pointerQueue.Dequeue());
            this.StaticRespawnZones = base.ReadBlockArrayData<StaticSpawnZoneBlock>(binaryReader, pointerQueue.Dequeue());
            this.StaticInitialSpawnZones = base.ReadBlockArrayData<StaticSpawnZoneBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.DynamicSpawnOverloads);
            queueableBinaryWriter.QueueWrite(this.StaticRespawnZones);
            queueableBinaryWriter.QueueWrite(this.StaticInitialSpawnZones);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.DynamicSpawnLowerHeight);
            queueableBinaryWriter.Write(this.DynamicSpawnUpperHeight);
            queueableBinaryWriter.Write(this.GameObjectResetHeight);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.WritePointer(this.DynamicSpawnOverloads);
            queueableBinaryWriter.WritePointer(this.StaticRespawnZones);
            queueableBinaryWriter.WritePointer(this.StaticInitialSpawnZones);
        }
    }
}
