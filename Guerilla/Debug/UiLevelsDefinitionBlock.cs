// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UiLevelsDefinitionBlock : UiLevelsDefinitionBlockBase
    {
        public  UiLevelsDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class UiLevelsDefinitionBlockBase
    {
        internal UiCampaignBlock[] campaigns;
        internal GlobalUiCampaignLevelBlock[] campaignLevels;
        internal GlobalUiMultiplayerLevelBlock[] multiplayerLevels;
        internal  UiLevelsDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadUiCampaignBlockArray(binaryReader);
            ReadGlobalUiCampaignLevelBlockArray(binaryReader);
            ReadGlobalUiMultiplayerLevelBlockArray(binaryReader);
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
        internal  virtual UiCampaignBlock[] ReadUiCampaignBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(UiCampaignBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new UiCampaignBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new UiCampaignBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalUiCampaignLevelBlock[] ReadGlobalUiCampaignLevelBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalUiCampaignLevelBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalUiCampaignLevelBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalUiCampaignLevelBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual GlobalUiMultiplayerLevelBlock[] ReadGlobalUiMultiplayerLevelBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(GlobalUiMultiplayerLevelBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new GlobalUiMultiplayerLevelBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new GlobalUiMultiplayerLevelBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteUiCampaignBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalUiCampaignLevelBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteGlobalUiMultiplayerLevelBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteUiCampaignBlockArray(binaryWriter);
                WriteGlobalUiCampaignLevelBlockArray(binaryWriter);
                WriteGlobalUiMultiplayerLevelBlockArray(binaryWriter);
            }
        }
    };
}
