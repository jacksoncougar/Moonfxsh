// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioDeviceStructBlock : ScenarioDeviceStructBlockBase
    {
        public  ScenarioDeviceStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioDeviceStructBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ShortBlockIndex1 powerGroup;
        internal Moonfish.Tags.ShortBlockIndex1 positionGroup;
        internal Flags flags;
        internal  ScenarioDeviceStructBlockBase(BinaryReader binaryReader)
        {
            powerGroup = binaryReader.ReadShortBlockIndex1();
            positionGroup = binaryReader.ReadShortBlockIndex1();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(powerGroup);
                binaryWriter.Write(positionGroup);
                binaryWriter.Write((Int32)flags);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
