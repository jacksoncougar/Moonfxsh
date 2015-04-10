using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalNewHudGlobalsStructBlock : GlobalNewHudGlobalsStructBlockBase
    {
        public  GlobalNewHudGlobalsStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 144)]
    public class GlobalNewHudGlobalsStructBlockBase
    {
        [TagReference("unic")]
        internal Moonfish.Tags.TagReference hudText;
        internal HudDashlightsBlock[] dashlights;
        internal HudWaypointArrowBlock[] waypointArrows;
        internal HudWaypointBlock[] waypoints;
        internal NewHudSoundBlock[] hudSounds;
        internal PlayerTrainingEntryDataBlock[] playerTrainingData;
        internal GlobalNewHudGlobalsConstantsStructBlock constants;
        internal  GlobalNewHudGlobalsStructBlockBase(BinaryReader binaryReader)
        {
            this.hudText = binaryReader.ReadTagReference();
            this.dashlights = ReadHudDashlightsBlockArray(binaryReader);
            this.waypointArrows = ReadHudWaypointArrowBlockArray(binaryReader);
            this.waypoints = ReadHudWaypointBlockArray(binaryReader);
            this.hudSounds = ReadNewHudSoundBlockArray(binaryReader);
            this.playerTrainingData = ReadPlayerTrainingEntryDataBlockArray(binaryReader);
            this.constants = new GlobalNewHudGlobalsConstantsStructBlock(binaryReader);
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
        internal  virtual HudDashlightsBlock[] ReadHudDashlightsBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudDashlightsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudDashlightsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudDashlightsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudWaypointArrowBlock[] ReadHudWaypointArrowBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudWaypointArrowBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudWaypointArrowBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudWaypointArrowBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudWaypointBlock[] ReadHudWaypointBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudWaypointBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudWaypointBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudWaypointBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual NewHudSoundBlock[] ReadNewHudSoundBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(NewHudSoundBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new NewHudSoundBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new NewHudSoundBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PlayerTrainingEntryDataBlock[] ReadPlayerTrainingEntryDataBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlayerTrainingEntryDataBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlayerTrainingEntryDataBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlayerTrainingEntryDataBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
