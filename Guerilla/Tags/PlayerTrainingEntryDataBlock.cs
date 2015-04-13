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
        public  PlayerTrainingEntryDataBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  PlayerTrainingEntryDataBlockBase(BinaryReader binaryReader)
        {
            this.displayString = binaryReader.ReadStringID();
            this.displayString2 = binaryReader.ReadStringID();
            this.displayString3 = binaryReader.ReadStringID();
            this.maxDisplayTime = binaryReader.ReadInt16();
            this.displayCount = binaryReader.ReadInt16();
            this.dissapearDelay = binaryReader.ReadInt16();
            this.redisplayDelay = binaryReader.ReadInt16();
            this.displayDelayS = binaryReader.ReadSingle();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            NotInMultiplayer = 1,
        };
    };
}
