// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalNewHudGlobalsStructBlock : GlobalNewHudGlobalsStructBlockBase
    {
        public  GlobalNewHudGlobalsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalNewHudGlobalsStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 144, Alignment = 4)]
    public class GlobalNewHudGlobalsStructBlockBase : GuerillaBlock
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference hudText;
        internal HudDashlightsBlock[] dashlights;
        internal HudWaypointArrowBlock[] waypointArrows;
        internal HudWaypointBlock[] waypoints;
        internal NewHudSoundBlock[] hudSounds;
        internal PlayerTrainingEntryDataBlock[] playerTrainingData;
        internal GlobalNewHudGlobalsConstantsStructBlock constants;
        
        public override int SerializedSize{get { return 144; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalNewHudGlobalsStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            hudText = binaryReader.ReadTagReference();
            dashlights = Guerilla.ReadBlockArray<HudDashlightsBlock>(binaryReader);
            waypointArrows = Guerilla.ReadBlockArray<HudWaypointArrowBlock>(binaryReader);
            waypoints = Guerilla.ReadBlockArray<HudWaypointBlock>(binaryReader);
            hudSounds = Guerilla.ReadBlockArray<NewHudSoundBlock>(binaryReader);
            playerTrainingData = Guerilla.ReadBlockArray<PlayerTrainingEntryDataBlock>(binaryReader);
            constants = new GlobalNewHudGlobalsConstantsStructBlock(binaryReader);
        }
        public  GlobalNewHudGlobalsStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(hudText);
                nextAddress = Guerilla.WriteBlockArray<HudDashlightsBlock>(binaryWriter, dashlights, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudWaypointArrowBlock>(binaryWriter, waypointArrows, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudWaypointBlock>(binaryWriter, waypoints, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<NewHudSoundBlock>(binaryWriter, hudSounds, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerTrainingEntryDataBlock>(binaryWriter, playerTrainingData, nextAddress);
                constants.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
