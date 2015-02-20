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
        public  SpriteVerticesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  SpriteVerticesBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.offset = binaryReader.ReadVector3();
            this.axis = binaryReader.ReadVector3();
            this.texcoord = binaryReader.ReadVector2();
            this.color = binaryReader.ReadRGBColor();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
    };
}
