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
        public  LimitedHingeConstraintsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  LimitedHingeConstraintsBlockBase(System.IO.BinaryReader binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            limitFriction = binaryReader.ReadSingle();
            limitMinAngle = binaryReader.ReadSingle();
            limitMaxAngle = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                constraintBodies.Write(binaryWriter);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(limitFriction);
                binaryWriter.Write(limitMinAngle);
                binaryWriter.Write(limitMaxAngle);
            }
        }
    };
}
