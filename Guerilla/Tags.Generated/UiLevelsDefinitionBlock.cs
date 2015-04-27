// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UiLevelsDefinitionBlock : UiLevelsDefinitionBlockBase
    {
        public  UiLevelsDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UiLevelsDefinitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class UiLevelsDefinitionBlockBase : GuerillaBlock
    {
        internal UiCampaignBlock[] campaigns;
        internal GlobalUiCampaignLevelBlock[] campaignLevels;
        internal GlobalUiMultiplayerLevelBlock[] multiplayerLevels;
        
        public override int SerializedSize{get { return 24; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UiLevelsDefinitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            campaigns = Guerilla.ReadBlockArray<UiCampaignBlock>(binaryReader);
            campaignLevels = Guerilla.ReadBlockArray<GlobalUiCampaignLevelBlock>(binaryReader);
            multiplayerLevels = Guerilla.ReadBlockArray<GlobalUiMultiplayerLevelBlock>(binaryReader);
        }
        public  UiLevelsDefinitionBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<UiCampaignBlock>(binaryWriter, campaigns, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiCampaignLevelBlock>(binaryWriter, campaignLevels, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiMultiplayerLevelBlock>(binaryWriter, multiplayerLevels, nextAddress);
                return nextAddress;
            }
        }
    };
}
