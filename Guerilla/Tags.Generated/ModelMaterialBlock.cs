// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelMaterialBlock : ModelMaterialBlockBase
    {
        public ModelMaterialBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ModelMaterialBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent materialName;
        internal MaterialType materialType;
        internal Moonfish.Tags.ShortBlockIndex2 damageSection;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringIdent globalMaterialName;
        internal byte[] invalidName_1;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public ModelMaterialBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            materialName = binaryReader.ReadStringID();
            materialType = (MaterialType)binaryReader.ReadInt16();
            damageSection = binaryReader.ReadShortBlockIndex2();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            globalMaterialName = binaryReader.ReadStringID();
            invalidName_1 = binaryReader.ReadBytes(4);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(materialName);
                binaryWriter.Write((Int16)materialType);
                binaryWriter.Write(damageSection);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(globalMaterialName);
                binaryWriter.Write(invalidName_1, 0, 4);
                return nextAddress;
            }
        }
        internal enum MaterialType : short
        {
            Dirt = 0,
            Sand = 1,
            Stone = 2,
            Snow = 3,
            Wood = 4,
            MetalHollow = 5,
            MetalThin = 6,
            MetalThick = 7,
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
        };
    };
}
