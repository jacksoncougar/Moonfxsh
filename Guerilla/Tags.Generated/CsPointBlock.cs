// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class CsPointBlock : CsPointBlockBase
    {
        public  CsPointBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class CsPointBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal int surfaceIndex;
        internal OpenTK.Vector2 facingDirection;
        internal  CsPointBlockBase(BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            surfaceIndex = binaryReader.ReadInt32();
            facingDirection = binaryReader.ReadVector2();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
