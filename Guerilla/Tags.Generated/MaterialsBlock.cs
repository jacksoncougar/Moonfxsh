// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class MaterialsBlock : MaterialsBlockBase
    {
        public  MaterialsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  MaterialsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 180, Alignment = 4)]
    public class MaterialsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.StringID parentName;
        internal byte[] invalidName_;
        internal Flags flags;
        internal OldMaterialType oldMaterialType;
        internal byte[] invalidName_0;
        internal Moonfish.Tags.StringID generalArmor;
        internal Moonfish.Tags.StringID specificArmor;
        internal MaterialPhysicsPropertiesStructBlock physicsProperties;
        [TagReference("mpdt")]
        internal Moonfish.Tags.TagReference oldMaterialPhysics;
        [TagReference("bsdt")]
        internal Moonfish.Tags.TagReference breakableSurface;
        internal MaterialsSweetenersStructBlock sweeteners;
        [TagReference("foot")]
        internal Moonfish.Tags.TagReference materialEffects;
        
        public override int SerializedSize{get { return 180; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  MaterialsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            parentName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            oldMaterialType = (OldMaterialType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            generalArmor = binaryReader.ReadStringID();
            specificArmor = binaryReader.ReadStringID();
            physicsProperties = new MaterialPhysicsPropertiesStructBlock(binaryReader);
            oldMaterialPhysics = binaryReader.ReadTagReference();
            breakableSurface = binaryReader.ReadTagReference();
            sweeteners = new MaterialsSweetenersStructBlock(binaryReader);
            materialEffects = binaryReader.ReadTagReference();
        }
        public  MaterialsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            parentName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            flags = (Flags)binaryReader.ReadInt16();
            oldMaterialType = (OldMaterialType)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            generalArmor = binaryReader.ReadStringID();
            specificArmor = binaryReader.ReadStringID();
            physicsProperties = new MaterialPhysicsPropertiesStructBlock(binaryReader);
            oldMaterialPhysics = binaryReader.ReadTagReference();
            breakableSurface = binaryReader.ReadTagReference();
            sweeteners = new MaterialsSweetenersStructBlock(binaryReader);
            materialEffects = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(parentName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)oldMaterialType);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(generalArmor);
                binaryWriter.Write(specificArmor);
                physicsProperties.Write(binaryWriter);
                binaryWriter.Write(oldMaterialPhysics);
                binaryWriter.Write(breakableSurface);
                sweeteners.Write(binaryWriter);
                binaryWriter.Write(materialEffects);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Flammable = 1,
            Biomass = 2,
        };
        internal enum OldMaterialType : short
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
