// ReSharper disable All
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
        public  CharacterPlacementBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  CharacterPlacementBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            fewUpgradeChanceEasy = binaryReader.ReadSingle();
            fewUpgradeChanceNormal = binaryReader.ReadSingle();
            fewUpgradeChanceHeroic = binaryReader.ReadSingle();
            fewUpgradeChanceLegendary = binaryReader.ReadSingle();
            normalUpgradeChanceEasy = binaryReader.ReadSingle();
            normalUpgradeChanceNormal = binaryReader.ReadSingle();
            normalUpgradeChanceHeroic = binaryReader.ReadSingle();
            normalUpgradeChanceLegendary = binaryReader.ReadSingle();
            manyUpgradeChanceEasy = binaryReader.ReadSingle();
            manyUpgradeChanceNormal = binaryReader.ReadSingle();
            manyUpgradeChanceHeroic = binaryReader.ReadSingle();
            manyUpgradeChanceLegendary = binaryReader.ReadSingle();
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
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(fewUpgradeChanceEasy);
                binaryWriter.Write(fewUpgradeChanceNormal);
                binaryWriter.Write(fewUpgradeChanceHeroic);
                binaryWriter.Write(fewUpgradeChanceLegendary);
                binaryWriter.Write(normalUpgradeChanceEasy);
                binaryWriter.Write(normalUpgradeChanceNormal);
                binaryWriter.Write(normalUpgradeChanceHeroic);
                binaryWriter.Write(normalUpgradeChanceLegendary);
                binaryWriter.Write(manyUpgradeChanceEasy);
                binaryWriter.Write(manyUpgradeChanceNormal);
                binaryWriter.Write(manyUpgradeChanceHeroic);
                binaryWriter.Write(manyUpgradeChanceLegendary);
            }
        }
    };
}
