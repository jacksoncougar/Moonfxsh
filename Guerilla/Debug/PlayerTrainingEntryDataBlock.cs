// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PlayerTrainingEntryDataBlock : PlayerTrainingEntryDataBlockBase
    {
        public  PlayerTrainingEntryDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 28)]
    public class PlayerTrainingEntryDataBlockBase
    {
        /// <summary>
        /// comes out of the HUD text globals
        /// </summary>
        internal Moonfish.Tags.StringID displayString;
        /// <summary>
        /// comes out of the HUD text globals, used for grouped prompt
        /// </summary>
        internal Moonfish.Tags.StringID displayString2;
        /// <summary>
        /// comes out of the HUD text globals, used for ungrouped prompt
        /// </summary>
        internal Moonfish.Tags.StringID displayString3;
        /// <summary>
        /// how long the message can be on screen before being hidden
        /// </summary>
        internal short maxDisplayTime;
        /// <summary>
        /// how many times a training message will get displayed (0-3 only!)
        /// </summary>
        internal short displayCount;
        /// <summary>
        /// how long a displayed but untriggered message stays up
        /// </summary>
        internal short dissapearDelay;
        /// <summary>
        /// how long after display this message will stay hidden
        /// </summary>
        internal short redisplayDelay;
        /// <summary>
        /// how long the event can be triggered before it's displayed
        /// </summary>
        internal float displayDelayS;
        internal Flags flags;
        internal byte[] invalidName_;
        internal  PlayerTrainingEntryDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            displayString = binaryReader.ReadStringID();
            displayString2 = binaryReader.ReadStringID();
            displayString3 = binaryReader.ReadStringID();
            maxDisplayTime = binaryReader.ReadInt16();
            displayCount = binaryReader.ReadInt16();
            dissapearDelay = binaryReader.ReadInt16();
            redisplayDelay = binaryReader.ReadInt16();
            displayDelayS = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(displayString);
                binaryWriter.Write(displayString2);
                binaryWriter.Write(displayString3);
                binaryWriter.Write(maxDisplayTime);
                binaryWriter.Write(displayCount);
                binaryWriter.Write(dissapearDelay);
                binaryWriter.Write(redisplayDelay);
                binaryWriter.Write(displayDelayS);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            NotInMultiplayer = 1,
        };
    };
}
