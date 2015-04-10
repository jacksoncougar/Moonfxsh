// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecalVerticesBlock : DecalVerticesBlockBase
    {
        public  DecalVerticesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 31)]
    public class DecalVerticesBlockBase
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 texcoord0;
        internal OpenTK.Vector2 texcoord1;
        internal Moonfish.Tags.RGBColor color;
        internal  DecalVerticesBlockBase(System.IO.BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            texcoord0 = binaryReader.ReadVector2();
            texcoord1 = binaryReader.ReadVector2();
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
                binaryWriter.Write(texcoord0);
                binaryWriter.Write(texcoord1);
                binaryWriter.Write(color);
            }
        }
    };
}
