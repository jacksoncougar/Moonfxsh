using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RuntimeLevelsDefinitionBlock : RuntimeLevelsDefinitionBlockBase
    {
        public  RuntimeLevelsDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class RuntimeLevelsDefinitionBlockBase
    {
        internal RuntimeCampaignLevelBlock[] campaignLevels;
        internal  RuntimeLevelsDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.campaignLevels = ReadRuntimeCampaignLevelBlockArray(binaryReader);
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
        internal  virtual RuntimeCampaignLevelBlock[] ReadRuntimeCampaignLevelBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RuntimeCampaignLevelBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RuntimeCampaignLevelBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RuntimeCampaignLevelBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
