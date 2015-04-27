// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessBitmapTransformBlock : ShaderPostprocessBitmapTransformBlockBase
    {
        public  ShaderPostprocessBitmapTransformBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessBitmapTransformBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderPostprocessBitmapTransformBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte bitmapTransformIndex;
        internal float value;
        
        public override int SerializedSize{get { return 6; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessBitmapTransformBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            bitmapTransformIndex = binaryReader.ReadByte();
            value = binaryReader.ReadSingle();
        }
        public  ShaderPostprocessBitmapTransformBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            bitmapTransformIndex = binaryReader.ReadByte();
            value = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(bitmapTransformIndex);
                binaryWriter.Write(value);
                return nextAddress;
            }
        }
    };
}
