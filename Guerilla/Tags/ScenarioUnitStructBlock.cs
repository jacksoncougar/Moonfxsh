// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioUnitStructBlock : ScenarioUnitStructBlockBase
    {
        public  ScenarioUnitStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioUnitStructBlockBase  : IGuerilla
    {
        internal float bodyVitality01;
        internal Flags flags;
        internal  ScenarioUnitStructBlockBase(BinaryReader binaryReader)
        {
            bodyVitality01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bodyVitality01);
                binaryWriter.Write((Int32)flags);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            Dead = 1,
            Closed = 2,
            NotEnterableByPlayer = 4,
        };
    };
}
