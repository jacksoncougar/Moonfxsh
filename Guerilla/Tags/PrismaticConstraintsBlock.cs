// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PrismaticConstraintsBlock : PrismaticConstraintsBlockBase
    {
        public  PrismaticConstraintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 132, Alignment = 4)]
    public class PrismaticConstraintsBlockBase  : IGuerilla
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float minLimit;
        internal float maxLimit;
        internal float maxFrictionForce;
        internal  PrismaticConstraintsBlockBase(BinaryReader binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            minLimit = binaryReader.ReadSingle();
            maxLimit = binaryReader.ReadSingle();
            maxFrictionForce = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
