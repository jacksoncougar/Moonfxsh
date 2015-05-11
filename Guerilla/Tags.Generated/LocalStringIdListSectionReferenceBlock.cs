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
    public partial class LocalStringIdListSectionReferenceBlock : LocalStringIdListSectionReferenceBlockBase
    {
        public LocalStringIdListSectionReferenceBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class LocalStringIdListSectionReferenceBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent sectionName;
        internal LocalStringIdListStringReferenceBlock[] localStringSectionReferences;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public LocalStringIdListSectionReferenceBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sectionName = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<LocalStringIdListStringReferenceBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            localStringSectionReferences = ReadBlockArrayData<LocalStringIdListStringReferenceBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sectionName);
                nextAddress = Guerilla.WriteBlockArray<LocalStringIdListStringReferenceBlock>(binaryWriter,
                    localStringSectionReferences, nextAddress);
                return nextAddress;
            }
        }
    };
}