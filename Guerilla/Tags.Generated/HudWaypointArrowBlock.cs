// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudWaypointArrowBlock : HudWaypointArrowBlockBase
    {
        public  HudWaypointArrowBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HudWaypointArrowBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class HudWaypointArrowBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal byte[] invalidName_;
        internal Moonfish.Tags.RGBColor color;
        internal byte[] invalidName_0;
        internal float opacity;
        internal float translucency;
        internal short onScreenSequenceIndex;
        internal short offScreenSequenceIndex;
        internal short occludedSequenceIndex;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal Flags flags;
        internal byte[] invalidName_3;
        
        public override int SerializedSize{get { return 104; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudWaypointArrowBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            color = binaryReader.ReadRGBColor();
            invalidName_0 = binaryReader.ReadBytes(1);
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            onScreenSequenceIndex = binaryReader.ReadInt16();
            offScreenSequenceIndex = binaryReader.ReadInt16();
            occludedSequenceIndex = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(16);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_3 = binaryReader.ReadBytes(24);
        }
        public  HudWaypointArrowBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            invalidName_ = binaryReader.ReadBytes(8);
            color = binaryReader.ReadRGBColor();
            invalidName_0 = binaryReader.ReadBytes(1);
            opacity = binaryReader.ReadSingle();
            translucency = binaryReader.ReadSingle();
            onScreenSequenceIndex = binaryReader.ReadInt16();
            offScreenSequenceIndex = binaryReader.ReadInt16();
            occludedSequenceIndex = binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            invalidName_2 = binaryReader.ReadBytes(16);
            flags = (Flags)binaryReader.ReadInt32();
            invalidName_3 = binaryReader.ReadBytes(24);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(color);
                binaryWriter.Write(invalidName_0, 0, 1);
                binaryWriter.Write(opacity);
                binaryWriter.Write(translucency);
                binaryWriter.Write(onScreenSequenceIndex);
                binaryWriter.Write(offScreenSequenceIndex);
                binaryWriter.Write(occludedSequenceIndex);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write(invalidName_2, 0, 16);
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(invalidName_3, 0, 24);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            DontRotateWhenPointingOffscreen = 1,
        };
    };
}
