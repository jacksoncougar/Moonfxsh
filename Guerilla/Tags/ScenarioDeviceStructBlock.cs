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
    [LayoutAttribute(Size = 8)]
    public class ScenarioDeviceStructBlockBase
    {
        internal Moonfish.Tags.ShortBlockIndex1 powerGroup;
        internal Moonfish.Tags.ShortBlockIndex1 positionGroup;
        internal Flags flags;
        internal  ScenarioDeviceStructBlockBase(BinaryReader binaryReader)
        {
            this.powerGroup = binaryReader.ReadShortBlockIndex1();
            this.positionGroup = binaryReader.ReadShortBlockIndex1();
            this.flags = (Flags)binaryReader.ReadInt32();
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
