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
    public partial class PrismaticConstraintsBlock : PrismaticConstraintsBlockBase
    {
        public PrismaticConstraintsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 132, Alignment = 4)]
    public class PrismaticConstraintsBlockBase : GuerillaBlock
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float minLimit;
        internal float maxLimit;
        internal float maxFrictionForce;
        public override int SerializedSize { get { return 132; } }
        public override int Alignment { get { return 4; } }
        public PrismaticConstraintsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            constraintBodies = new ConstraintBodiesStructBlock();
            blamPointers.Concat(constraintBodies.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            minLimit = binaryReader.ReadSingle();
            maxLimit = binaryReader.ReadSingle();
            maxFrictionForce = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            constraintBodies.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                constraintBodies.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(minLimit);
                binaryWriter.Write(maxLimit);
                binaryWriter.Write(maxFrictionForce);
                return nextAddress;
            }
        }
    };
}
