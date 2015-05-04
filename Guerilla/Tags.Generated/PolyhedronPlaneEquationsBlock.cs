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
    public partial class PolyhedronPlaneEquationsBlock : PolyhedronPlaneEquationsBlockBase
    {
        public PolyhedronPlaneEquationsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 16)]
    public class PolyhedronPlaneEquationsBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 16; }
        }

        public PolyhedronPlaneEquationsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(16);
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
                binaryWriter.Write(invalidName_, 0, 16);
                return nextAddress;
            }
        }
    };
}