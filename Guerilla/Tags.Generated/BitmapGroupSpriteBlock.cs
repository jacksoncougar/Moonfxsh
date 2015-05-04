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
    public partial class BitmapGroupSpriteBlock : BitmapGroupSpriteBlockBase
    {
        public BitmapGroupSpriteBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class BitmapGroupSpriteBlockBase : GuerillaBlock
    {
        internal short bitmapIndex;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal float left;
        internal float right;
        internal float top;
        internal float bottom;
        internal OpenTK.Vector2 registrationPoint;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public BitmapGroupSpriteBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmapIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            left = binaryReader.ReadSingle();
            right = binaryReader.ReadSingle();
            top = binaryReader.ReadSingle();
            bottom = binaryReader.ReadSingle();
            registrationPoint = binaryReader.ReadVector2();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(left);
                binaryWriter.Write(right);
                binaryWriter.Write(top);
                binaryWriter.Write(bottom);
                binaryWriter.Write(registrationPoint);
                return nextAddress;
            }
        }
    };
}