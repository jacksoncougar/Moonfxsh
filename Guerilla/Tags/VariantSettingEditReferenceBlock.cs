// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class VariantSettingEditReferenceBlock : VariantSettingEditReferenceBlockBase
    {
        public  VariantSettingEditReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class VariantSettingEditReferenceBlockBase  : IGuerilla
    {
        internal SettingCategory settingCategory;
        internal byte[] invalidName_;
        internal TextValuePairBlock[] options;
        internal NullBlock[] nullBlock;
        internal  VariantSettingEditReferenceBlockBase(BinaryReader binaryReader)
        {
            settingCategory = (SettingCategory)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(4);
            options = Guerilla.ReadBlockArray<TextValuePairBlock>(binaryReader);
            nullBlock = Guerilla.ReadBlockArray<NullBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)settingCategory);
                binaryWriter.Write(invalidName_, 0, 4);
                Guerilla.WriteBlockArray<TextValuePairBlock>(binaryWriter, options, nextAddress);
                Guerilla.WriteBlockArray<NullBlock>(binaryWriter, nullBlock, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        internal enum SettingCategory : int
        {
            MatchCtf = 0,
            MatchSlayer = 1,
            MatchOddball = 2,
            MatchKing = 3,
            MatchRace = 4,
            MatchHeadhunter = 5,
            MatchJuggernaut = 6,
            MatchTerritories = 7,
            MatchAssault = 8,
            Players = 9,
            OBSOLETE = 10,
            Vehicles = 11,
            Equipment = 12,
            GameCtf = 13,
            GameSlayer = 14,
            GameOddball = 15,
            GameKing = 16,
            GameRace = 17,
            GameHeadhunter = 18,
            GameJuggernaut = 19,
            GameTerritories = 20,
            GameAssault = 21,
            QuickOptionsCtf = 22,
            QuickOptionsSlayer = 23,
            QuickOptionsOddball = 24,
            QuickOptionsKing = 25,
            QuickOptionsRace = 26,
            QuickOptionsHeadhunter = 27,
            QuickOptionsJuggernaut = 28,
            QuickOptionsTerritories = 29,
            QuickOptionsAssault = 30,
            TeamCtf = 31,
            TeamSlayer = 32,
            TeamOddball = 33,
            TeamKing = 34,
            TeamRace = 35,
            TeamHeadhunter = 36,
            TeamJuggernaut = 37,
            TeamTerritories = 38,
            TeamAssault = 39,
        };
    };
}
