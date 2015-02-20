using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorProjectedDecalBlock : DecoratorProjectedDecalBlockBase
    {
        public  DecoratorProjectedDecalBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 64)]
    public class DecoratorProjectedDecalBlockBase
    {
        internal Moonfish.Tags.ByteBlockIndex1 decoratorSet;
        internal byte decoratorClass;
        internal byte decoratorPermutation;
        internal byte spriteIndex;
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 left;
        internal OpenTK.Vector3 up;
        internal OpenTK.Vector3 extents;
        internal OpenTK.Vector3 previousPosition;
        internal  DecoratorProjectedDecalBlockBase(BinaryReader binaryReader)
        {
            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
            this.decoratorClass = binaryReader.ReadByte();
            this.decoratorPermutation = binaryReader.ReadByte();
            this.spriteIndex = binaryReader.ReadByte();
            this.position = binaryReader.ReadVector3();
            this.left = binaryReader.ReadVector3();
            this.up = binaryReader.ReadVector3();
            this.extents = binaryReader.ReadVector3();
            this.previousPosition = binaryReader.ReadVector3();
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
    };
}
