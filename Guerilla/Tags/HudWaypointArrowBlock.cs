using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudWaypointArrowBlock : HudWaypointArrowBlockBase
    {
        public  HudWaypointArrowBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 103)]
    public class HudWaypointArrowBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal byte[] invalidName_;
        internal Moonfish.Tags.RGBColor color;
        internal float opacity;
        internal float translucency;
        internal short onScreenSequenceIndex;
        internal short offScreenSequenceIndex;
        internal short occludedSequenceIndex;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal Flags flags;
        internal byte[] invalidName_2;
        internal  HudWaypointArrowBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.invalidName_ = binaryReader.ReadBytes(8);
            this.color = binaryReader.ReadRGBColor();
            this.opacity = binaryReader.ReadSingle();
            this.translucency = binaryReader.ReadSingle();
            this.onScreenSequenceIndex = binaryReader.ReadInt16();
            this.offScreenSequenceIndex = binaryReader.ReadInt16();
            this.occludedSequenceIndex = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(16);
            this.flags = (Flags)binaryReader.ReadInt32();
            this.invalidName_2 = binaryReader.ReadBytes(24);
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
        internal enum Flags : int
        
        {
            DontRotateWhenPointingOffscreen = 1,
        };
    };
}
