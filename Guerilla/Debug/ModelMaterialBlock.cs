// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelMaterialBlock : ModelMaterialBlockBase
    {
        public  ModelMaterialBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class ModelMaterialBlockBase
    {
        internal Moonfish.Tags.StringID materialName;
        internal MaterialType materialType;
        internal Moonfish.Tags.ShortBlockIndex2 damageSection;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringID globalMaterialName;
        internal byte[] invalidName_1;
        internal  ModelMaterialBlockBase(System.IO.BinaryReader binaryReader)
        {
            materialName = binaryReader.ReadStringID();
            materialType = (MaterialType)binaryReader.ReadInt16();
            damageSection = binaryReader.ReadShortBlockIndex2();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            globalMaterialName = binaryReader.ReadStringID();
            invalidName_1 = binaryReader.ReadBytes(4);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(materialName);
                binaryWriter.Write((Int16)materialType);
                binaryWriter.Write(damageSection);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(globalMaterialName);
                binaryWriter.Write(invalidName_1, 0, 4);
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
