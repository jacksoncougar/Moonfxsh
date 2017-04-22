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
    [TagBlockOriginalNameAttribute("scenario_resources_block")]
    public partial class ScenarioResourcesBlock : GuerillaBlock, IWriteQueueable
    {
        public ScenarioResourceReferenceBlock[] References = new ScenarioResourceReferenceBlock[0];
        public ScenarioHsSourceReferenceBlock[] ScriptSource = new ScenarioHsSourceReferenceBlock[0];
        public ScenarioAiResourceReferenceBlock[] AIResources = new ScenarioAiResourceReferenceBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 24;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(8));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.References = base.ReadBlockArrayData<ScenarioResourceReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.ScriptSource = base.ReadBlockArrayData<ScenarioHsSourceReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.AIResources = base.ReadBlockArrayData<ScenarioAiResourceReferenceBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
            queueableBinaryWriter.QueueWrite(this.References);
            queueableBinaryWriter.QueueWrite(this.ScriptSource);
            queueableBinaryWriter.QueueWrite(this.AIResources);
        }
        public override void Write(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.WritePointer(this.References);
            queueableBinaryWriter.WritePointer(this.ScriptSource);
            queueableBinaryWriter.WritePointer(this.AIResources);
        }
    }
}
