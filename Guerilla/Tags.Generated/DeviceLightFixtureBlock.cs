// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Lifi = (TagClass) "lifi";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("lifi")]
    public partial class DeviceLightFixtureBlock : DeviceLightFixtureBlockBase
    {
        public DeviceLightFixtureBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 0, Alignment = 4)]
    public class DeviceLightFixtureBlockBase : DeviceBlock
    {
        public override int SerializedSize
        {
            get { return 284; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public DeviceLightFixtureBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                return nextAddress;
            }
        }
    };
}