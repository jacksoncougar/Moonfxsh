// ReSharper disable All
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
        public  DecoratorProjectedDecalBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorProjectedDecalBlockBase(System.IO.BinaryReader binaryReader)
        {
            decoratorSet = binaryReader.ReadByteBlockIndex1();
            decoratorClass = binaryReader.ReadByte();
            decoratorPermutation = binaryReader.ReadByte();
            spriteIndex = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
            left = binaryReader.ReadVector3();
            up = binaryReader.ReadVector3();
            extents = binaryReader.ReadVector3();
            previousPosition = binaryReader.ReadVector3();
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
                binaryWriter.Write(decoratorSet);
                binaryWriter.Write(decoratorClass);
                binaryWriter.Write(decoratorPermutation);
                binaryWriter.Write(spriteIndex);
                binaryWriter.Write(position);
                binaryWriter.Write(left);
                binaryWriter.Write(up);
                binaryWriter.Write(extents);
                binaryWriter.Write(previousPosition);
            }
        }
    };
}
