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
    
    [TagClassAttribute("*igh")]
    public partial class ScenarioLightsResourceBlock : GuerillaBlock, IWriteQueueable
    {
        public ScenarioObjectNamesBlock[] Names = new ScenarioObjectNamesBlock[0];
        public DontUseMeScenarioEnvironmentObjectBlock[] DontUseMeScenarioEnvironmentObjectBlock = new DontUseMeScenarioEnvironmentObjectBlock[0];
        public ScenarioStructureBspReferenceBlock[] StructureReferences = new ScenarioStructureBspReferenceBlock[0];
        public ScenarioLightPaletteBlock[] Palette = new ScenarioLightPaletteBlock[0];
        public ScenarioLightBlock[] Objects = new ScenarioLightBlock[0];
        public int NextObjectIDSalt;
        public GScenarioEditorFolderBlock[] EditorFolders = new GScenarioEditorFolderBlock[0];
        public override int SerializedSize
        {
            get
            {
                return 52;
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
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(36));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(64));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(68));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(40));
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(108));
            this.NextObjectIDSalt = binaryReader.ReadInt32();
            pointerQueue.Enqueue(binaryReader.ReadBlamPointer(260));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.Names = base.ReadBlockArrayData<ScenarioObjectNamesBlock>(binaryReader, pointerQueue.Dequeue());
            this.DontUseMeScenarioEnvironmentObjectBlock = base.ReadBlockArrayData<DontUseMeScenarioEnvironmentObjectBlock>(binaryReader, pointerQueue.Dequeue());
            this.StructureReferences = base.ReadBlockArrayData<ScenarioStructureBspReferenceBlock>(binaryReader, pointerQueue.Dequeue());
            this.Palette = base.ReadBlockArrayData<ScenarioLightPaletteBlock>(binaryReader, pointerQueue.Dequeue());
            this.Objects = base.ReadBlockArrayData<ScenarioLightBlock>(binaryReader, pointerQueue.Dequeue());
            this.EditorFolders = base.ReadBlockArrayData<GScenarioEditorFolderBlock>(binaryReader, pointerQueue.Dequeue());
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.QueueWrite(this.Names);
            queueableBlamBinaryWriter.QueueWrite(this.DontUseMeScenarioEnvironmentObjectBlock);
            queueableBlamBinaryWriter.QueueWrite(this.StructureReferences);
            queueableBlamBinaryWriter.QueueWrite(this.Palette);
            queueableBlamBinaryWriter.QueueWrite(this.Objects);
            queueableBlamBinaryWriter.QueueWrite(this.EditorFolders);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.WritePointer(this.Names);
            queueableBlamBinaryWriter.WritePointer(this.DontUseMeScenarioEnvironmentObjectBlock);
            queueableBlamBinaryWriter.WritePointer(this.StructureReferences);
            queueableBlamBinaryWriter.WritePointer(this.Palette);
            queueableBlamBinaryWriter.WritePointer(this.Objects);
            queueableBlamBinaryWriter.Write(this.NextObjectIDSalt);
            queueableBlamBinaryWriter.WritePointer(this.EditorFolders);
        }
    }
}
namespace Moonfish.Tags
{
    
    public partial struct TagClass
    {
        public static TagClass Igh = ((TagClass)("*igh"));
    }
}
