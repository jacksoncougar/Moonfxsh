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
    public partial class PhysicsModelNodeConstraintEdgeBlock : PhysicsModelNodeConstraintEdgeBlockBase
    {
        public PhysicsModelNodeConstraintEdgeBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class PhysicsModelNodeConstraintEdgeBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 nodeA;
        internal Moonfish.Tags.ShortBlockIndex1 nodeB;
        internal PhysicsModelConstraintEdgeConstraintBlock[] constraints;
        /// <summary>
        /// if you don't fill this out we will pluck the material from the first primitive, of the first rigid body attached to node a
        /// </summary>
        internal Moonfish.Tags.StringIdent nodeAMaterial;
        /// <summary>
        /// if you don't fill this out we will pluck the material from the first primitive, of the first rigid body attached to node b, if node b is none we use whatever material a has
        /// </summary>
        internal Moonfish.Tags.StringIdent nodeBMaterial;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public PhysicsModelNodeConstraintEdgeBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            nodeA = binaryReader.ReadShortBlockIndex1();
            nodeB = binaryReader.ReadShortBlockIndex1();
            blamPointers.Enqueue(ReadBlockArrayPointer<PhysicsModelConstraintEdgeConstraintBlock>(binaryReader));
            nodeAMaterial = binaryReader.ReadStringID();
            nodeBMaterial = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            constraints = ReadBlockArrayData<PhysicsModelConstraintEdgeConstraintBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(nodeA);
                binaryWriter.Write(nodeB);
                nextAddress = Guerilla.WriteBlockArray<PhysicsModelConstraintEdgeConstraintBlock>(binaryWriter, constraints, nextAddress);
                binaryWriter.Write(nodeAMaterial);
                binaryWriter.Write(nodeBMaterial);
                return nextAddress;
            }
        }
    };
}
