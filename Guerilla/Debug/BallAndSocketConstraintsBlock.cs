// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BallAndSocketConstraintsBlock : BallAndSocketConstraintsBlockBase
    {
        public  BallAndSocketConstraintsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 120)]
    public class BallAndSocketConstraintsBlockBase
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal  BallAndSocketConstraintsBlockBase(System.IO.BinaryReader binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
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
            }
        }
    };
}
