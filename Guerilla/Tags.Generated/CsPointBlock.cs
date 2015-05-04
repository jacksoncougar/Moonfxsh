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
    public partial class CsPointBlock : CsPointBlockBase
    {
        public CsPointBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class CsPointBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal int surfaceIndex;
        internal OpenTK.Vector2 facingDirection;
        public override int SerializedSize { get { return 60; } }
        public override int Alignment { get { return 4; } }
        public CsPointBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            surfaceIndex = binaryReader.ReadInt32();
            facingDirection = binaryReader.ReadVector2();
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
                binaryWriter.Write(name);
                binaryWriter.Write(position);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(surfaceIndex);
                binaryWriter.Write(facingDirection);
                return nextAddress;
            }
        }
    };
}
