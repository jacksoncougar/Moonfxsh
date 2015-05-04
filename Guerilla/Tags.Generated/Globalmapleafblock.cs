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
    public partial class GlobalMapLeafBlock : GlobalMapLeafBlockBase
    {
        public GlobalMapLeafBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class GlobalMapLeafBlockBase : GuerillaBlock
    {
        internal MapLeafFaceBlock[] faces;
        internal MapLeafConnectionIndexBlock[] connectionIndices;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalMapLeafBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MapLeafFaceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MapLeafConnectionIndexBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            faces = ReadBlockArrayData<MapLeafFaceBlock>(binaryReader, blamPointers.Dequeue());
            connectionIndices = ReadBlockArrayData<MapLeafConnectionIndexBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MapLeafFaceBlock>(binaryWriter, faces, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MapLeafConnectionIndexBlock>(binaryWriter, connectionIndices,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}