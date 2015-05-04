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
    public partial class StiffSpringConstraintsBlock : StiffSpringConstraintsBlockBase
    {
        public StiffSpringConstraintsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 124, Alignment = 4)]
    public class StiffSpringConstraintsBlockBase : GuerillaBlock
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float springLength;

        public override int SerializedSize
        {
            get { return 124; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StiffSpringConstraintsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            constraintBodies = new ConstraintBodiesStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(constraintBodies.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(4);
            springLength = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            constraintBodies.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                constraintBodies.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(springLength);
                return nextAddress;
            }
        }
    };
}