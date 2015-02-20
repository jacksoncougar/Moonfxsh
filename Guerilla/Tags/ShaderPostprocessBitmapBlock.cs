using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessBitmapBlock : ShaderPostprocessBitmapBlockBase
    {
        public  ShaderPostprocessBitmapBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 10)]
    public class ShaderPostprocessBitmapBlockBase
    {
        internal byte parameterIndex;
        internal byte flags;
        internal int bitmapGroupIndex;
        internal float logBitmapDimension;
        internal  ShaderPostprocessBitmapBlockBase(BinaryReader binaryReader)
        {
            this.parameterIndex = binaryReader.ReadByte();
            this.flags = binaryReader.ReadByte();
            this.bitmapGroupIndex = binaryReader.ReadInt32();
            this.logBitmapDimension = binaryReader.ReadSingle();
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
