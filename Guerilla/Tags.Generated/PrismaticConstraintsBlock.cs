// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrismaticConstraintsBlock : PrismaticConstraintsBlockBase
    {
        public  PrismaticConstraintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PrismaticConstraintsBlock(): base()
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
        
        public override int SerializedSize{get { return 132; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PrismaticConstraintsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            minLimit = binaryReader.ReadSingle();
            maxLimit = binaryReader.ReadSingle();
            maxFrictionForce = binaryReader.ReadSingle();
        }
        public  PrismaticConstraintsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
