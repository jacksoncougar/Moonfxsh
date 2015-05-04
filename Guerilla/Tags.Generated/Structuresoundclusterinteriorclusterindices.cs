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
    public partial class StructureSoundClusterInteriorClusterIndices : StructureSoundClusterInteriorClusterIndicesBase
    {
        public StructureSoundClusterInteriorClusterIndices() : base()
        {
        }
    };

    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class StructureSoundClusterInteriorClusterIndicesBase : GuerillaBlock
    {
        internal short interiorClusterIndex;

        public override int SerializedSize
        {
            get { return 2; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureSoundClusterInteriorClusterIndicesBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            interiorClusterIndex = binaryReader.ReadInt16();
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
                binaryWriter.Write(interiorClusterIndex);
                return nextAddress;
            }
        }
    };
}