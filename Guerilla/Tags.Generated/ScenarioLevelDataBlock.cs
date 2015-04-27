// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioLevelDataBlock : ScenarioLevelDataBlockBase
    {
        public  ScenarioLevelDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class ScenarioLevelDataBlockBase : GuerillaBlock
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference levelDescription;
        internal GlobalUiCampaignLevelBlock[] campaignLevelData;
        internal GlobalUiMultiplayerLevelBlock[] multiplayer;
        
        public override int SerializedSize{get { return 24; }}
        
        internal  ScenarioLevelDataBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            levelDescription = binaryReader.ReadTagReference();
            campaignLevelData = Guerilla.ReadBlockArray<GlobalUiCampaignLevelBlock>(binaryReader);
            multiplayer = Guerilla.ReadBlockArray<GlobalUiMultiplayerLevelBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(levelDescription);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiCampaignLevelBlock>(binaryWriter, campaignLevelData, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<GlobalUiMultiplayerLevelBlock>(binaryWriter, multiplayer, nextAddress);
                return nextAddress;
            }
        }
    };
}
