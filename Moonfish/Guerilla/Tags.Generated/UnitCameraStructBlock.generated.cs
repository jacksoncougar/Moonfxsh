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
    [TagBlockOriginalNameAttribute("unit_camera_struct_block")]
    public partial class UnitCameraStructBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent CameraMarkerName;
        public Moonfish.Tags.StringIdent CameraSubmergedMarkerName;
        public float PitchAutolevel;
        public Moonfish.Model.Range PitchRange;
        public UnitCameraTrackBlock[] CameraTracks = new UnitCameraTrackBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 28;
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
            this.CameraMarkerName = binaryReader.ReadStringIdent();
            this.CameraSubmergedMarkerName = binaryReader.ReadStringIdent();
            this.PitchAutolevel = binaryReader.ReadSingle();
            this.PitchRange = binaryReader.ReadRange();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.CameraTracks = base.ReadBlockArrayData<UnitCameraTrackBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.CameraTracks);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.CameraMarkerName);
            queueableBinaryWriter.Write(this.CameraSubmergedMarkerName);
            queueableBinaryWriter.Write(this.PitchAutolevel);
            queueableBinaryWriter.Write(this.PitchRange);
            queueableBinaryWriter.WritePointer(this.CameraTracks);
        }
    }
}
