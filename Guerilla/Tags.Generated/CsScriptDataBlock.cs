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
    public partial class CsScriptDataBlock : CsScriptDataBlockBase
    {
        public CsScriptDataBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 128, Alignment = 4)]
    public class CsScriptDataBlockBase : GuerillaBlock
    {
        internal CsPointSetBlock[] pointSets;
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 128; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CsScriptDataBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CsPointSetBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(120);
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            pointSets = ReadBlockArrayData<CsPointSetBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<CsPointSetBlock>(binaryWriter, pointSets, nextAddress);
                binaryWriter.Write(invalidName_, 0, 120);
                return nextAddress;
            }
        }
    };
}