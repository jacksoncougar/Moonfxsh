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
    public partial class STextValuePairBlocksBlockUNUSED : STextValuePairBlocksBlockUNUSEDBase
    {
        public STextValuePairBlocksBlockUNUSED() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class STextValuePairBlocksBlockUNUSEDBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal STextValuePairReferenceBlockUNUSED[] textValuePairs;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public STextValuePairBlocksBlockUNUSEDBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            blamPointers.Enqueue(ReadBlockArrayPointer<STextValuePairReferenceBlockUNUSED>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            textValuePairs = ReadBlockArrayData<STextValuePairReferenceBlockUNUSED>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<STextValuePairReferenceBlockUNUSED>(binaryWriter, textValuePairs, nextAddress);
                return nextAddress;
            }
        }
    };
}
