using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RagdollConstraintsBlock : RagdollConstraintsBlockBase
    {
        public  RagdollConstraintsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 148)]
    public class RagdollConstraintsBlockBase
    {
        internal ConstraintBodiesStructBlock constraintBodies;
        internal byte[] invalidName_;
        internal float minTwist;
        internal float maxTwist;
        internal float minCone;
        internal float maxCone;
        internal float minPlane;
        internal float maxPlane;
        internal float maxFricitonTorque;
        internal  RagdollConstraintsBlockBase(BinaryReader binaryReader)
        {
            this.constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.minTwist = binaryReader.ReadSingle();
            this.maxTwist = binaryReader.ReadSingle();
            this.minCone = binaryReader.ReadSingle();
            this.maxCone = binaryReader.ReadSingle();
            this.minPlane = binaryReader.ReadSingle();
            this.maxPlane = binaryReader.ReadSingle();
            this.maxFricitonTorque = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
