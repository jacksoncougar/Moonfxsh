// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioUnitStructBlock : ScenarioUnitStructBlockBase
    {
        public ScenarioUnitStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ScenarioUnitStructBlockBase : GuerillaBlock
    {
        internal float bodyVitality01;
        internal Flags flags;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public ScenarioUnitStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bodyVitality01 = binaryReader.ReadSingle();
            flags = (Flags)binaryReader.ReadInt32();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bodyVitality01);
                binaryWriter.Write((Int32)flags);
                return nextAddress;
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
