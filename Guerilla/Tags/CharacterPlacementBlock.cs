using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CharacterPlacementBlock : CharacterPlacementBlockBase
    {
        public  CharacterPlacementBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 52)]
    public class CharacterPlacementBlockBase
    {
        internal byte[] invalidName_;
        internal float fewUpgradeChanceEasy;
        internal float fewUpgradeChanceNormal;
        internal float fewUpgradeChanceHeroic;
        internal float fewUpgradeChanceLegendary;
        internal float normalUpgradeChanceEasy;
        internal float normalUpgradeChanceNormal;
        internal float normalUpgradeChanceHeroic;
        internal float normalUpgradeChanceLegendary;
        internal float manyUpgradeChanceEasy;
        internal float manyUpgradeChanceNormal;
        internal float manyUpgradeChanceHeroic;
        internal float manyUpgradeChanceLegendary;
        internal  CharacterPlacementBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.fewUpgradeChanceEasy = binaryReader.ReadSingle();
            this.fewUpgradeChanceNormal = binaryReader.ReadSingle();
            this.fewUpgradeChanceHeroic = binaryReader.ReadSingle();
            this.fewUpgradeChanceLegendary = binaryReader.ReadSingle();
            this.normalUpgradeChanceEasy = binaryReader.ReadSingle();
            this.normalUpgradeChanceNormal = binaryReader.ReadSingle();
            this.normalUpgradeChanceHeroic = binaryReader.ReadSingle();
            this.normalUpgradeChanceLegendary = binaryReader.ReadSingle();
            this.manyUpgradeChanceEasy = binaryReader.ReadSingle();
            this.manyUpgradeChanceNormal = binaryReader.ReadSingle();
            this.manyUpgradeChanceHeroic = binaryReader.ReadSingle();
            this.manyUpgradeChanceLegendary = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
