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
    public partial class DecoratorProjectedDecalBlock : DecoratorProjectedDecalBlockBase
    {
        public DecoratorProjectedDecalBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class DecoratorProjectedDecalBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 64; } }
        public override int Alignment { get { return 4; } }
        public DecoratorProjectedDecalBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            decoratorSet = binaryReader.ReadByteBlockIndex1();
            decoratorClass = binaryReader.ReadByte();
            decoratorPermutation = binaryReader.ReadByte();
            spriteIndex = binaryReader.ReadByte();
            position = binaryReader.ReadVector3();
            left = binaryReader.ReadVector3();
            up = binaryReader.ReadVector3();
            extents = binaryReader.ReadVector3();
            previousPosition = binaryReader.ReadVector3();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
                return nextAddress;
            }
        }
    };
}
