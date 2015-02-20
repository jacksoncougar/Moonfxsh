using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioLevelDataBlock : ScenarioLevelDataBlockBase
    {
        public  ScenarioLevelDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class ScenarioLevelDataBlockBase
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference levelDescription;
        internal GlobalUiCampaignLevelBlock[] campaignLevelData;
        internal GlobalUiMultiplayerLevelBlock[] multiplayer;
        internal  ScenarioLevelDataBlockBase(BinaryReader binaryReader)
        {
            this.levelDescription = binaryReader.ReadTagReference();
            this.campaignLevelData = ReadGlobalUiCampaignLevelBlockArray(binaryReader);
            this.multiplayer = ReadGlobalUiMultiplayerLevelBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual GlobalUiCampaignLevelBlock[] ReadGlobalUiCampaignLevelBlockArray(BinaryReader binaryReader)
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
        internal  virtual GlobalUiMultiplayerLevelBlock[] ReadGlobalUiMultiplayerLevelBlockArray(BinaryReader binaryReader)
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
    };
}
