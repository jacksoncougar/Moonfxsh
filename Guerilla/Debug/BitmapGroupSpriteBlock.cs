// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BitmapGroupSpriteBlock : BitmapGroupSpriteBlockBase
    {
        public  BitmapGroupSpriteBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class BitmapGroupSpriteBlockBase
    {
        internal short bitmapIndex;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal float left;
        internal float right;
        internal float top;
        internal float bottom;
        internal OpenTK.Vector2 registrationPoint;
        internal  BitmapGroupSpriteBlockBase(System.IO.BinaryReader binaryReader)
        {
            bitmapIndex = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(4);
            left = binaryReader.ReadSingle();
            right = binaryReader.ReadSingle();
            top = binaryReader.ReadSingle();
            bottom = binaryReader.ReadSingle();
            registrationPoint = binaryReader.ReadVector2();
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
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(left);
                binaryWriter.Write(right);
                binaryWriter.Write(top);
                binaryWriter.Write(bottom);
                binaryWriter.Write(registrationPoint);
            }
        }
    };
}
