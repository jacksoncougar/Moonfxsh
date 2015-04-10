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
        public  CollisionModelPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class CollisionModelPermutationBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal CollisionModelBspBlock[] bsps;
        internal CollisionBspPhysicsBlock[] bspPhysics;
        internal  CollisionModelPermutationBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.bsps = ReadCollisionModelBspBlockArray(binaryReader);
            this.bspPhysics = ReadCollisionBspPhysicsBlockArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        internal  virtual CollisionModelBspBlock[] ReadCollisionModelBspBlockArray(BinaryReader binaryReader)
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
        internal  virtual CollisionBspPhysicsBlock[] ReadCollisionBspPhysicsBlockArray(BinaryReader binaryReader)
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
    };
}
