// ReSharper disable All
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
        public  PhysicsModelNodeConstraintEdgeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PhysicsModelNodeConstraintEdgeBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            nodeA = binaryReader.ReadShortBlockIndex1();
            nodeB = binaryReader.ReadShortBlockIndex1();
            ReadPhysicsModelConstraintEdgeConstraintBlockArray(binaryReader);
            nodeAMaterial = binaryReader.ReadStringID();
            nodeBMaterial = binaryReader.ReadStringID();
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
        internal  virtual PhysicsModelConstraintEdgeConstraintBlock[] ReadPhysicsModelConstraintEdgeConstraintBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PhysicsModelConstraintEdgeConstraintBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PhysicsModelConstraintEdgeConstraintBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PhysicsModelConstraintEdgeConstraintBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePhysicsModelConstraintEdgeConstraintBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(nodeA);
                binaryWriter.Write(nodeB);
                WritePhysicsModelConstraintEdgeConstraintBlockArray(binaryWriter);
                binaryWriter.Write(nodeAMaterial);
                binaryWriter.Write(nodeBMaterial);
            }
        }
    };
}
