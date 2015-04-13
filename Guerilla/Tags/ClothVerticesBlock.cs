// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ClothVerticesBlock : ClothVerticesBlockBase
    {
        public  ClothVerticesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ClothVerticesBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 initialPosition;
        internal OpenTK.Vector2 uv;
        internal  ClothVerticesBlockBase(BinaryReader binaryReader)
        {
            initialPosition = binaryReader.ReadVector3();
            uv = binaryReader.ReadVector2();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(initialPosition);
                binaryWriter.Write(uv);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
