using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PermutationsBlock : PermutationsBlockBase
    {
        public  PermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class PermutationsBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal RigidBodyIndicesBlock[] rigidBodies;
        internal  PermutationsBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.rigidBodies = ReadRigidBodyIndicesBlockArray(binaryReader);
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
        internal  virtual RigidBodyIndicesBlock[] ReadRigidBodyIndicesBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RigidBodyIndicesBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RigidBodyIndicesBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RigidBodyIndicesBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
