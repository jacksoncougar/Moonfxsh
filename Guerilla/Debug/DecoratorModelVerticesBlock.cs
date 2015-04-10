// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class DecoratorModelVerticesBlock : DecoratorModelVerticesBlockBase
    {
        public  DecoratorModelVerticesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class DecoratorModelVerticesBlockBase
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector3 normal;
        internal OpenTK.Vector3 tangent;
        internal OpenTK.Vector3 binormal;
        internal OpenTK.Vector2 texcoord;
        internal  DecoratorModelVerticesBlockBase(System.IO.BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            normal = binaryReader.ReadVector3();
            tangent = binaryReader.ReadVector3();
            binormal = binaryReader.ReadVector3();
            texcoord = binaryReader.ReadVector2();
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
                binaryWriter.Write(normal);
                binaryWriter.Write(tangent);
                binaryWriter.Write(binormal);
                binaryWriter.Write(texcoord);
            }
        }
    };
}
