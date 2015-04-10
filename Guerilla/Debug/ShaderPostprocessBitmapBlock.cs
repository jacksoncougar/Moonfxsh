// ReSharper disable All
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
        public  ShaderPostprocessBitmapBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPostprocessBitmapBlockBase(System.IO.BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
            bitmapGroupIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
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
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(flags);
                binaryWriter.Write(bitmapGroupIndex);
                binaryWriter.Write(logBitmapDimension);
            }
        }
    };
}
