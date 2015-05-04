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
    public partial class EnvironmentObjectRefs : EnvironmentObjectRefsBase
    {
        public EnvironmentObjectRefs() : base()
        {
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class EnvironmentObjectRefsBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal int firstSector;
        internal int lastSector;
        internal EnvironmentObjectBspRefs[] bsps;
        internal EnvironmentObjectNodes[] nodes;
        public override int SerializedSize { get { return 28; } }
        public override int Alignment { get { return 4; } }
        public EnvironmentObjectRefsBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            firstSector = binaryReader.ReadInt32();
            lastSector = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<EnvironmentObjectBspRefs>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<EnvironmentObjectNodes>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            bsps = ReadBlockArrayData<EnvironmentObjectBspRefs>(binaryReader, blamPointers.Dequeue());
            nodes = ReadBlockArrayData<EnvironmentObjectNodes>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(firstSector);
                binaryWriter.Write(lastSector);
                nextAddress = Guerilla.WriteBlockArray<EnvironmentObjectBspRefs>(binaryWriter, bsps, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EnvironmentObjectNodes>(binaryWriter, nodes, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            Mobile = 1,
        };
    };
}
