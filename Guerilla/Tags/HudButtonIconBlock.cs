using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudButtonIconBlock : HudButtonIconBlockBase
    {
        public  HudButtonIconBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class HudButtonIconBlockBase
    {
        /// <summary>
        /// sequenceIndex into the global hud icon bitmap
        /// </summary>
        internal short sequenceIndex;
        /// <summary>
        /// extra spacing beyond bitmap width for text alignment
        /// </summary>
        internal short widthOffset;
        internal Moonfish.Tags.Point offsetFromReferenceCorner;
        internal Moonfish.Tags.ColourA1R1G1B1 overrideIconColor;
        internal byte frameRate030;
        internal Flags flags;
        internal short textIndex;
        internal  HudButtonIconBlockBase(BinaryReader binaryReader)
        {
            this.sequenceIndex = binaryReader.ReadInt16();
            this.widthOffset = binaryReader.ReadInt16();
            this.offsetFromReferenceCorner = binaryReader.ReadPoint();
            this.overrideIconColor = binaryReader.ReadColourA1R1G1B1();
            this.frameRate030 = binaryReader.ReadByte();
            this.flags = (Flags)binaryReader.ReadByte();
            this.textIndex = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
        [FlagsAttribute]
        internal enum Flags : byte
        
        {
            UseTextFromStringListInstead = 1,
            OverrideDefaultColor = 2,
            WidthOffsetIsAbsoluteIconWidth = 4,
        };
    };
}
