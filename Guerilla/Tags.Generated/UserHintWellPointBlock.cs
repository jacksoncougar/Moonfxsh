// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintWellPointBlock : UserHintWellPointBlockBase
    {
        public UserHintWellPointBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class UserHintWellPointBlockBase : GuerillaBlock
    {
        internal Type type;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point;
        internal short referenceFrame;
        internal byte[] invalidName_0;
        internal int sectorIndex;
        internal OpenTK.Vector2 normal;

        public override int SerializedSize
        {
            get { return 32; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public UserHintWellPointBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            sectorIndex = binaryReader.ReadInt32();
            normal = binaryReader.ReadVector2();
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
                binaryWriter.Write((Int16) type);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(point);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(sectorIndex);
                binaryWriter.Write(normal);
                return nextAddress;
            }
        }

        internal enum Type : short
        {
            Jump = 0,
            Climb = 1,
            Hoist = 2,
        };
    };
}