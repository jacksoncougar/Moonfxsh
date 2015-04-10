// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CollisionModelPermutationBlock : CollisionModelPermutationBlockBase
    {
        public  CollisionModelPermutationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class CollisionModelPermutationBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal CollisionModelBspBlock[] bsps;
        internal CollisionBspPhysicsBlock[] bspPhysics;
        internal  CollisionModelPermutationBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            ReadCollisionModelBspBlockArray(binaryReader);
            ReadCollisionBspPhysicsBlockArray(binaryReader);
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
        internal  virtual CollisionModelBspBlock[] ReadCollisionModelBspBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionModelBspBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionModelBspBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionModelBspBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual CollisionBspPhysicsBlock[] ReadCollisionBspPhysicsBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(CollisionBspPhysicsBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new CollisionBspPhysicsBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new CollisionBspPhysicsBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionModelBspBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteCollisionBspPhysicsBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                WriteCollisionModelBspBlockArray(binaryWriter);
                WriteCollisionBspPhysicsBlockArray(binaryWriter);
            }
        }
    };
}
