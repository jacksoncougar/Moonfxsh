//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("global_new_hud_globals_struct_block")]
    public partial class GlobalNewHudGlobalsStructBlock : GuerillaBlock, IWriteQueueable
    {
        [Moonfish.Tags.TagReferenceAttribute("unic")]
        public Moonfish.Tags.TagReference HudText;
        public HudDashlightsBlock[] Dashlights = new HudDashlightsBlock[0];
        public HudWaypointArrowBlock[] WaypointArrows = new HudWaypointArrowBlock[0];
        public HudWaypointBlock[] Waypoints = new HudWaypointBlock[0];
        public NewHudSoundBlock[] HudSounds = new NewHudSoundBlock[0];
        public PlayerTrainingEntryDataBlock[] PlayerTrainingData = new PlayerTrainingEntryDataBlock[0];
        public GlobalNewHudGlobalsConstantsStructBlock Constants = new GlobalNewHudGlobalsConstantsStructBlock();
        public override int SerializedSize
        {
            get
            {
                return 144;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.HudText = binaryReader.ReadTagReference();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(24));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(28));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Constants.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Dashlights = base.ReadBlockArrayData<HudDashlightsBlock>(binaryReader, pointerQueue.Dequeue());
            this.WaypointArrows = base.ReadBlockArrayData<HudWaypointArrowBlock>(binaryReader, pointerQueue.Dequeue());
            this.Waypoints = base.ReadBlockArrayData<HudWaypointBlock>(binaryReader, pointerQueue.Dequeue());
            this.HudSounds = base.ReadBlockArrayData<NewHudSoundBlock>(binaryReader, pointerQueue.Dequeue());
            this.PlayerTrainingData = base.ReadBlockArrayData<PlayerTrainingEntryDataBlock>(binaryReader, pointerQueue.Dequeue());
            this.Constants.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.Dashlights);
            queueableBinaryWriter.QueueWrite(this.WaypointArrows);
            queueableBinaryWriter.QueueWrite(this.Waypoints);
            queueableBinaryWriter.QueueWrite(this.HudSounds);
            queueableBinaryWriter.QueueWrite(this.PlayerTrainingData);
            this.Constants.QueueWrites(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.HudText);
            queueableBinaryWriter.WritePointer(this.Dashlights);
            queueableBinaryWriter.WritePointer(this.WaypointArrows);
            queueableBinaryWriter.WritePointer(this.Waypoints);
            queueableBinaryWriter.WritePointer(this.HudSounds);
            queueableBinaryWriter.WritePointer(this.PlayerTrainingData);
            this.Constants.Write(queueableBinaryWriter);
        }
    }
}
