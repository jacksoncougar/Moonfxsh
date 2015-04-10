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
        public  CsPointBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class CsPointBlockBase
    {
        internal Moonfish.Tags.String32 name;
        internal OpenTK.Vector3 position;
        internal short referenceFrame;
        internal byte[] invalidName_;
        internal int surfaceIndex;
        internal OpenTK.Vector2 facingDirection;
        internal  CsPointBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            position = binaryReader.ReadVector3();
            referenceFrame = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            surfaceIndex = binaryReader.ReadInt32();
            facingDirection = binaryReader.ReadVector2();
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
                binaryWriter.Write(name);
                binaryWriter.Write(position);
                binaryWriter.Write(referenceFrame);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(surfaceIndex);
                binaryWriter.Write(facingDirection);
            }
        }
    };
}
