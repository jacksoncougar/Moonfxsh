// ReSharper disable All
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
        public  RagdollConstraintsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  RagdollConstraintsBlockBase(System.IO.BinaryReader binaryReader)
        {
            constraintBodies = new ConstraintBodiesStructBlock(binaryReader);
            invalidName_ = binaryReader.ReadBytes(4);
            minTwist = binaryReader.ReadSingle();
            maxTwist = binaryReader.ReadSingle();
            minCone = binaryReader.ReadSingle();
            maxCone = binaryReader.ReadSingle();
            minPlane = binaryReader.ReadSingle();
            maxPlane = binaryReader.ReadSingle();
            maxFricitonTorque = binaryReader.ReadSingle();
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
                binaryWriter.Write(minTwist);
                binaryWriter.Write(maxTwist);
                binaryWriter.Write(minCone);
                binaryWriter.Write(maxCone);
                binaryWriter.Write(minPlane);
                binaryWriter.Write(maxPlane);
                binaryWriter.Write(maxFricitonTorque);
            }
        }
    };
}
