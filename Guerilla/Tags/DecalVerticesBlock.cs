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
        public  DecalVerticesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 31, Alignment = 4)]
    public class DecalVerticesBlockBase  : IGuerilla
    {
        internal OpenTK.Vector3 position;
        internal OpenTK.Vector2 texcoord0;
        internal OpenTK.Vector2 texcoord1;
        internal Moonfish.Tags.RGBColor color;
        internal  DecalVerticesBlockBase(BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            texcoord0 = binaryReader.ReadVector2();
            texcoord1 = binaryReader.ReadVector2();
            color = binaryReader.ReadRGBColor();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                binaryWriter.Write(texcoord0);
                binaryWriter.Write(texcoord1);
                binaryWriter.Write(color);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
