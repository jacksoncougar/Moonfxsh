// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintWellPointBlock : UserHintWellPointBlockBase
    {
        public  UserHintWellPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class UserHintWellPointBlockBase  : IGuerilla
    {
        internal Type type;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 point;
        internal short referenceFrame;
        internal byte[] invalidName_0;
        internal int sectorIndex;
        internal OpenTK.Vector2 normal;
        internal  UserHintWellPointBlockBase(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            point = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            sectorIndex = binaryReader.ReadInt32();
            normal = binaryReader.ReadVector2();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
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
