//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Linq;
using Moonfish.Tags;

namespace Moonfish.Guerilla.Tags.Generated
{
    public partial class MaterialsBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent Name;
        public Moonfish.Tags.StringIdent ParentName;
        private byte[] fieldpad = new byte[2];
        public Flags MaterialsFlags;
        public OldMaterialTypeEnum OldMaterialType;
        private byte[] fieldpad0 = new byte[2];
        public Moonfish.Tags.StringIdent GeneralArmor;
        public Moonfish.Tags.StringIdent SpecificArmor;
        public MaterialPhysicsPropertiesStructBlock PhysicsProperties = new MaterialPhysicsPropertiesStructBlock();
        [TagReference("mpdt")]
        public Moonfish.Tags.TagReference OldMaterialPhysics;
        [TagReference("bsdt")]
        public Moonfish.Tags.TagReference BreakableSurface;
        public MaterialsSweetenersStructBlock Sweeteners = new MaterialsSweetenersStructBlock();
        [TagReference("foot")]
        public Moonfish.Tags.TagReference MaterialEffects;
        public override int SerializedSize
        {
            get
            {
                return 180;
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
            this.Name = binaryReader.ReadStringIdent();
            this.ParentName = binaryReader.ReadStringIdent();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.MaterialsFlags = ((Flags)(binaryReader.ReadInt16()));
            this.OldMaterialType = ((OldMaterialTypeEnum)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.GeneralArmor = binaryReader.ReadStringIdent();
            this.SpecificArmor = binaryReader.ReadStringIdent();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.PhysicsProperties.ReadFields(binaryReader)));
            this.OldMaterialPhysics = binaryReader.ReadTagReference();
            this.BreakableSurface = binaryReader.ReadTagReference();
            pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(pointerQueue.Concat(this.Sweeteners.ReadFields(binaryReader)));
            this.MaterialEffects = binaryReader.ReadTagReference();
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
            this.PhysicsProperties.ReadInstances(binaryReader, pointerQueue);
            this.Sweeteners.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.QueueWrites(queueableBlamBinaryWriter);
            this.PhysicsProperties.QueueWrites(queueableBlamBinaryWriter);
            this.Sweeteners.QueueWrites(queueableBlamBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBlamBinaryWriter queueableBlamBinaryWriter)
        {
            base.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.Name);
            queueableBlamBinaryWriter.Write(this.ParentName);
            queueableBlamBinaryWriter.Write(this.fieldpad);
            queueableBlamBinaryWriter.Write(((short)(this.MaterialsFlags)));
            queueableBlamBinaryWriter.Write(((short)(this.OldMaterialType)));
            queueableBlamBinaryWriter.Write(this.fieldpad0);
            queueableBlamBinaryWriter.Write(this.GeneralArmor);
            queueableBlamBinaryWriter.Write(this.SpecificArmor);
            this.PhysicsProperties.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.OldMaterialPhysics);
            queueableBlamBinaryWriter.Write(this.BreakableSurface);
            this.Sweeteners.Write_(queueableBlamBinaryWriter);
            queueableBlamBinaryWriter.Write(this.MaterialEffects);
        }
        [System.FlagsAttribute()]
        public enum Flags : short
        {
            None = 0,
            Flammable = 1,
            Biomass = 2,
        }
        public enum OldMaterialTypeEnum : short
        {
            Dirt = 0,
            Sand = 1,
            Stone = 2,
            Snow = 3,
            Wood = 4,
            Metalhollow = 5,
            Metalthin = 6,
            Metalthick = 7,
            Rubber = 8,
            Glass = 9,
            ForceField = 10,
            Grunt = 11,
            HunterArmor = 12,
            HunterSkin = 13,
            Elite = 14,
            Jackal = 15,
            JackalEnergyShield = 16,
            EngineerSkin = 17,
            EngineerForceField = 18,
            FloodCombatForm = 19,
            FloodCarrierForm = 20,
            CyborgArmor = 21,
            CyborgEnergyShield = 22,
            HumanArmor = 23,
            HumanSkin = 24,
            Sentinel = 25,
            Monitor = 26,
            Plastic = 27,
            Water = 28,
            Leaves = 29,
            EliteEnergyShield = 30,
            Ice = 31,
            HunterShield = 32,
        }
    }
}
