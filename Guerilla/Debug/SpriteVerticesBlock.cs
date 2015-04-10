// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SpriteVerticesBlock : SpriteVerticesBlockBase
    {
        public  SpriteVerticesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 47)]
    public class SpriteVerticesBlockBase
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 offset;
        internal OpenTK.Vector3 axis;
        internal OpenTK.Vector2 texcoord;
        internal Moonfish.Tags.RGBColor color;
        internal  SpriteVerticesBlockBase(System.IO.BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            offset = binaryReader.ReadVector3();
            axis = binaryReader.ReadVector3();
            texcoord = binaryReader.ReadVector2();
            color = binaryReader.ReadRGBColor();
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
                binaryWriter.Write(position);
                binaryWriter.Write(offset);
                binaryWriter.Write(axis);
                binaryWriter.Write(texcoord);
                binaryWriter.Write(color);
            }
        }
    };
}
