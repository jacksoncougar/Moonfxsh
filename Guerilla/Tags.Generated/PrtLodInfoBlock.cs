// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrtLodInfoBlock : PrtLodInfoBlockBase
    {
        public PrtLodInfoBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PrtLodInfoBlockBase : GuerillaBlock
    {
        internal int clusterOffset;
        internal PrtSectionInfoBlock[] sectionInfo;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public PrtLodInfoBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            clusterOffset = binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<PrtSectionInfoBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            sectionInfo = ReadBlockArrayData<PrtSectionInfoBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(clusterOffset);
                nextAddress = Guerilla.WriteBlockArray<PrtSectionInfoBlock>(binaryWriter, sectionInfo, nextAddress);
                return nextAddress;
            }
        }
    };
}