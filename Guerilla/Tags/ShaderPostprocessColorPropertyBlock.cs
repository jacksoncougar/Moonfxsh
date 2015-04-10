using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessColorPropertyBlock : ShaderPostprocessColorPropertyBlockBase
    {
        public  ShaderPostprocessColorPropertyBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class ShaderPostprocessColorPropertyBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal  ShaderPostprocessColorPropertyBlockBase(BinaryReader binaryReader)
        {
            this.color = binaryReader.ReadColorR8G8B8();
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
