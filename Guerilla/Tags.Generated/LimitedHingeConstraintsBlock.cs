// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LimitedHingeConstraintsBlock : LimitedHingeConstraintsBlockBase
    {
        public  LimitedHingeConstraintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LimitedHingeConstraintsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 132, Alignment = 4)]
    public class LimitedHingeConstraintsBlockBase : GuerillaBlock
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float limitFriction;
        internal float limitMinAngle;
        internal float limitMaxAngle;
        
        public override int SerializedSize{get { return 132; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LimitedHingeConstraintsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            limitFriction = binaryReader.ReadSingle();
            limitMinAngle = binaryReader.ReadSingle();
            limitMaxAngle = binaryReader.ReadSingle();
        }
        public  LimitedHingeConstraintsBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            limitFriction = binaryReader.ReadSingle();
            limitMinAngle = binaryReader.ReadSingle();
            limitMaxAngle = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
