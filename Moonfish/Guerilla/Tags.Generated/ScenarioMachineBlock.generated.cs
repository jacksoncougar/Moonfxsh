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
    using Moonfish.Guerilla;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("scenario_machine_block")]
    public partial class ScenarioMachineBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.ShortBlockIndex1 Type;
        public Moonfish.Tags.ShortBlockIndex1 Name;
        public ScenarioObjectDatumStructBlock ObjectData = new ScenarioObjectDatumStructBlock();
        public ScenarioDeviceStructBlock DeviceData = new ScenarioDeviceStructBlock();
        public ScenarioMachineStructV3Block MachineData = new ScenarioMachineStructV3Block();
        public override int SerializedSize
        {
            get
            {
                return 72;
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
            this.Type = binaryReader.ReadShortBlockIndex1();
            this.Name = binaryReader.ReadShortBlockIndex1();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.ObjectData.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.DeviceData.ReadFields(binaryReader)));
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.MachineData.ReadFields(binaryReader)));
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.ObjectData.ReadInstances(binaryReader, pointerQueue);
            this.DeviceData.ReadInstances(binaryReader, pointerQueue);
            this.MachineData.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.DeferReferences(writer);
            this.ObjectData.DeferReferences(writer);
            this.DeviceData.DeferReferences(writer);
            this.MachineData.DeferReferences(writer);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter writer)
        {
            base.Write(writer);
            writer.Write(this.Type);
            writer.Write(this.Name);
            this.ObjectData.Write(writer);
            this.DeviceData.Write(writer);
            this.MachineData.Write(writer);
        }
    }
}
