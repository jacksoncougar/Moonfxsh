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
    public partial class ZoneSetBlock : ZoneSetBlockBase
    {
        public ZoneSetBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ZoneSetBlockBase : GuerillaBlock
    {
        internal AreaType areaType;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 zone;
        internal Moonfish.Tags.ShortBlockIndex2 area;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public ZoneSetBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            areaType = (AreaType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            zone = binaryReader.ReadShortBlockIndex1();
            area = binaryReader.ReadShortBlockIndex2();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)areaType);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(zone);
                binaryWriter.Write(area);
                return nextAddress;
            }
        }
        internal enum AreaType : short
        {
            Deault = 0,
            Search = 1,
            Goal = 2,
        };
    };
}
