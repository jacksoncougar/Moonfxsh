// ReSharper disable All
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
    [LayoutAttribute(Size = 103, Alignment = 4)]
    public class HudWaypointArrowBlockBase  : IGuerilla
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
            name = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            color = binaryReader.ReadRGBColor();
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            onScreenSequenceIndex = binaryReader.ReadInt16();
            offScreenSequenceIndex = binaryReader.ReadInt16();
            occludedSequenceIndex = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(16);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_2 = binaryReader.ReadBytes(24);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(color);
                binaryWriter.Write(opacity);
                binaryWriter.Write(translucency);
                binaryWriter.Write(onScreenSequenceIndex);
                binaryWriter.Write(offScreenSequenceIndex);
                binaryWriter.Write(occludedSequenceIndex);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_2, 0, 24);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            DontRotateWhenPointingOffscreen = 1,
        };
    };
}
