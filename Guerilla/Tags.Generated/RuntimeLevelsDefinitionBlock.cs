// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RuntimeLevelsDefinitionBlock : RuntimeLevelsDefinitionBlockBase
    {
        public  RuntimeLevelsDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RuntimeLevelsDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class RuntimeLevelsDefinitionBlockBase : GuerillaBlock
    {
        internal RuntimeCampaignLevelBlock[] campaignLevels;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RuntimeLevelsDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            campaignLevels = Guerilla.ReadBlockArray<RuntimeCampaignLevelBlock>(binaryReader);
        }
        public  RuntimeLevelsDefinitionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<RuntimeCampaignLevelBlock>(binaryWriter, campaignLevels, nextAddress);
                return nextAddress;
            }
        }
    };
}
