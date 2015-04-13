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
    [LayoutAttribute(Size = 132)]
    public class LimitedHingeConstraintsBlockBase
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float limitFriction;
        internal float limitMinAngle;
        internal float limitMaxAngle;
        internal  LimitedHingeConstraintsBlockBase(BinaryReader binaryReader)
        {
            this.constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.limitFriction = binaryReader.ReadSingle();
            this.limitMinAngle = binaryReader.ReadSingle();
            this.limitMaxAngle = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
    };
}
