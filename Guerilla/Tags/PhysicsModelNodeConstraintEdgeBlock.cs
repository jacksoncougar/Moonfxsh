using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PhysicsModelNodeConstraintEdgeBlock : PhysicsModelNodeConstraintEdgeBlockBase
    {
        public  PhysicsModelNodeConstraintEdgeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class PhysicsModelNodeConstraintEdgeBlockBase
    {
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 nodeA;
        internal Moonfish.Tags.ShortBlockIndex1 nodeB;
        internal PhysicsModelConstraintEdgeConstraintBlock[] constraints;
        /// <summary>
        /// if you don't fill this out we will pluck the material from the first primitive, of the first rigid body attached to node a
        /// </summary>
        internal Moonfish.Tags.StringID nodeAMaterial;
        /// <summary>
        /// if you don't fill this out we will pluck the material from the first primitive, of the first rigid body attached to node b, if node b is none we use whatever material a has
        /// </summary>
        internal Moonfish.Tags.StringID nodeBMaterial;
        internal  PhysicsModelNodeConstraintEdgeBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.nodeA = binaryReader.ReadShortBlockIndex1();
            this.nodeB = binaryReader.ReadShortBlockIndex1();
            this.constraints = ReadPhysicsModelConstraintEdgeConstraintBlockArray(binaryReader);
            this.nodeAMaterial = binaryReader.ReadStringID();
            this.nodeBMaterial = binaryReader.ReadStringID();
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
        internal  virtual PhysicsModelConstraintEdgeConstraintBlock[] ReadPhysicsModelConstraintEdgeConstraintBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhysicsModelConstraintEdgeConstraintBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhysicsModelConstraintEdgeConstraintBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhysicsModelConstraintEdgeConstraintBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
