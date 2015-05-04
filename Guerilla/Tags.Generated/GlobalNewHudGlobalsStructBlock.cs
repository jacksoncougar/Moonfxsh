// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalNewHudGlobalsStructBlock : GlobalNewHudGlobalsStructBlockBase
    {
        public GlobalNewHudGlobalsStructBlock() : base()
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
        public override int SerializedSize { get { return 144; } }
        public override int Alignment { get { return 4; } }
        public GlobalNewHudGlobalsStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            hudText = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<HudDashlightsBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudWaypointArrowBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudWaypointBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<NewHudSoundBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlayerTrainingEntryDataBlock>(binaryReader));
            constants = new GlobalNewHudGlobalsConstantsStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(constants.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            dashlights = ReadBlockArrayData<HudDashlightsBlock>(binaryReader, blamPointers.Dequeue());
            waypointArrows = ReadBlockArrayData<HudWaypointArrowBlock>(binaryReader, blamPointers.Dequeue());
            waypoints = ReadBlockArrayData<HudWaypointBlock>(binaryReader, blamPointers.Dequeue());
            hudSounds = ReadBlockArrayData<NewHudSoundBlock>(binaryReader, blamPointers.Dequeue());
            playerTrainingData = ReadBlockArrayData<PlayerTrainingEntryDataBlock>(binaryReader, blamPointers.Dequeue());
            constants.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
