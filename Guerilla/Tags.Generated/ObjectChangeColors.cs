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
    public partial class ObjectChangeColors : ObjectChangeColorsBase
    {
        public ObjectChangeColors() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ObjectChangeColorsBase : GuerillaBlock
    {
        internal ObjectChangeColorInitialPermutation[] initialPermutations;
        internal ObjectChangeColorFunction[] functions;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ObjectChangeColorsBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ObjectChangeColorInitialPermutation>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<ObjectChangeColorFunction>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            initialPermutations = ReadBlockArrayData<ObjectChangeColorInitialPermutation>(binaryReader, blamPointers.Dequeue());
            functions = ReadBlockArrayData<ObjectChangeColorFunction>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<ObjectChangeColorInitialPermutation>(binaryWriter, initialPermutations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ObjectChangeColorFunction>(binaryWriter, functions, nextAddress);
                return nextAddress;
            }
        }
    };
}
