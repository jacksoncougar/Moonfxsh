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
        public  VariantSettingEditReferenceBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class VariantSettingEditReferenceBlockBase
    {
        internal SettingCategory settingCategory;
        internal byte[] invalidName_;
        internal TextValuePairBlock[] options;
        internal NullBlock[] nullBlock;
        internal  VariantSettingEditReferenceBlockBase(System.IO.BinaryReader binaryReader)
        {
            settingCategory = (SettingCategory)binaryReader.ReadInt32();
            invalidName_ = binaryReader.ReadBytes(4);
            ReadTextValuePairBlockArray(binaryReader);
            ReadNullBlockArray(binaryReader);
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
        internal  virtual TextValuePairBlock[] ReadTextValuePairBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TextValuePairBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TextValuePairBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TextValuePairBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual NullBlock[] ReadNullBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(NullBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new NullBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new NullBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTextValuePairBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteNullBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)settingCategory);
                binaryWriter.Write(invalidName_, 0, 4);
                WriteTextValuePairBlockArray(binaryWriter);
                WriteNullBlockArray(binaryWriter);
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
