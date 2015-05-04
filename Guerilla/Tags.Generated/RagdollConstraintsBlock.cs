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
    public partial class RagdollConstraintsBlock : RagdollConstraintsBlockBase
    {
        public RagdollConstraintsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 148, Alignment = 4)]
    public class RagdollConstraintsBlockBase : GuerillaBlock
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

        public override int SerializedSize
        {
            get { return 148; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RagdollConstraintsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            constraintBodies = new ConstraintBodiesStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(constraintBodies.ReadFields(binaryReader)));
            invalidName_ = binaryReader.ReadBytes(4);
            minTwist = binaryReader.ReadSingle();
            maxTwist = binaryReader.ReadSingle();
            minCone = binaryReader.ReadSingle();
            maxCone = binaryReader.ReadSingle();
            minPlane = binaryReader.ReadSingle();
            maxPlane = binaryReader.ReadSingle();
            maxFricitonTorque = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            constraintBodies.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
                return nextAddress;
            }
        }
    };
}