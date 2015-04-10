// ReSharper disable All
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
        public  GlobalNewHudGlobalsStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  GlobalNewHudGlobalsStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            hudText = binaryReader.ReadTagReference();
            ReadHudDashlightsBlockArray(binaryReader);
            ReadHudWaypointArrowBlockArray(binaryReader);
            ReadHudWaypointBlockArray(binaryReader);
            ReadNewHudSoundBlockArray(binaryReader);
            ReadPlayerTrainingEntryDataBlockArray(binaryReader);
            constants = new GlobalNewHudGlobalsConstantsStructBlock(binaryReader);
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
        internal  virtual HudDashlightsBlock[] ReadHudDashlightsBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual HudWaypointArrowBlock[] ReadHudWaypointArrowBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual HudWaypointBlock[] ReadHudWaypointBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual NewHudSoundBlock[] ReadNewHudSoundBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PlayerTrainingEntryDataBlock[] ReadPlayerTrainingEntryDataBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudDashlightsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudWaypointArrowBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudWaypointBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteNewHudSoundBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePlayerTrainingEntryDataBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(hudText);
                WriteHudDashlightsBlockArray(binaryWriter);
                WriteHudWaypointArrowBlockArray(binaryWriter);
                WriteHudWaypointBlockArray(binaryWriter);
                WriteNewHudSoundBlockArray(binaryWriter);
                WritePlayerTrainingEntryDataBlockArray(binaryWriter);
                constants.Write(binaryWriter);
            }
        }
    };
}
