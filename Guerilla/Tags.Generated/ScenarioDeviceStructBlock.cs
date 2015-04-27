// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioDeviceStructBlock : ScenarioDeviceStructBlockBase
    {
        public  ScenarioDeviceStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioDeviceStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioDeviceStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 powerGroup;
        internal Moonfish.Tags.ShortBlockIndex1 positionGroup;
        internal Flags flags;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioDeviceStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            powerGroup = binaryReader.ReadShortBlockIndex1();
            positionGroup = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public  ScenarioDeviceStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            powerGroup = binaryReader.ReadShortBlockIndex1();
            positionGroup = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(powerGroup);
                binaryWriter.Write(positionGroup);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            InitiallyOpen10 = 1,
            InitiallyOff00 = 2,
            CanChangeOnlyOnce = 4,
            PositionReversed = 8,
            NotUsableFromAnySide = 16,
        };
    };
}
