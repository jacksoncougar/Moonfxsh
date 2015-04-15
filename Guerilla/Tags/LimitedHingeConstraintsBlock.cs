// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LimitedHingeConstraintsBlock : LimitedHingeConstraintsBlockBase
    {
        public  LimitedHingeConstraintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 132, Alignment = 4)]
    public class LimitedHingeConstraintsBlockBase  : IGuerilla
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float limitFriction;
        internal float limitMinAngle;
        internal float limitMaxAngle;
        internal  LimitedHingeConstraintsBlockBase(BinaryReader binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            limitFriction = binaryReader.ReadSingle();
            limitMinAngle = binaryReader.ReadSingle();
            limitMaxAngle = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                constraintBodies.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(limitFriction);
                binaryWriter.Write(limitMinAngle);
                binaryWriter.Write(limitMaxAngle);
                return nextAddress;
            }
        }
    };
}
