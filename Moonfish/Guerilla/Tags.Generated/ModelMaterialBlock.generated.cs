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
    [TagBlockOriginalNameAttribute("model_material_block")]
    public partial class ModelMaterialBlock : GuerillaBlock, IWriteDeferrable
    {
        public Moonfish.Tags.StringIdent MaterialName;
        public MaterialTypeEnum MaterialType;
        public Moonfish.Tags.ShortBlockIndex2 DamageSection;
        private byte[] fieldpad = new byte[2];
        private byte[] fieldpad0 = new byte[2];
        public Moonfish.Tags.StringIdent GlobalMaterialName;
        private byte[] fieldpad1 = new byte[4];
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
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.MaterialName = binaryReader.ReadStringIdent();
            this.MaterialType = ((MaterialTypeEnum)(binaryReader.ReadInt16()));
            this.DamageSection = binaryReader.ReadShortBlockIndex2();
            this.fieldpad = binaryReader.ReadBytes(2);
            this.fieldpad0 = binaryReader.ReadBytes(2);
            this.GlobalMaterialName = binaryReader.ReadStringIdent();
            this.fieldpad1 = binaryReader.ReadBytes(4);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.MaterialName);
            queueableBinaryWriter.Write(((short)(this.MaterialType)));
            queueableBinaryWriter.Write(this.DamageSection);
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.fieldpad0);
            queueableBinaryWriter.Write(this.GlobalMaterialName);
            queueableBinaryWriter.Write(this.fieldpad1);
        }
        public enum MaterialTypeEnum : short
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
