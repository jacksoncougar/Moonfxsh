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
        public  DecoratorModelVerticesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  DecoratorModelVerticesBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.normal = binaryReader.ReadVector3();
            this.tangent = binaryReader.ReadVector3();
            this.binormal = binaryReader.ReadVector3();
            this.texcoord = binaryReader.ReadVector2();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
        }
    };
}
