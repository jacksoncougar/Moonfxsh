// ReSharper disable All
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
        public  RuntimeLevelsDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class RuntimeLevelsDefinitionBlockBase
    {
        internal RuntimeCampaignLevelBlock[] campaignLevels;
        internal  RuntimeLevelsDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadRuntimeCampaignLevelBlockArray(binaryReader);
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
        internal  virtual RuntimeCampaignLevelBlock[] ReadRuntimeCampaignLevelBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRuntimeCampaignLevelBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteRuntimeCampaignLevelBlockArray(binaryWriter);
            }
        }
    };
}
