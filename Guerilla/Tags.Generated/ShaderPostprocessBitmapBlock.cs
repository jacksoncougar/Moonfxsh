// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessBitmapBlock : ShaderPostprocessBitmapBlockBase
    {
        public  ShaderPostprocessBitmapBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessBitmapBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderPostprocessBitmapBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte flags;
        internal int bitmapGroupIndex;
        internal float logBitmapDimension;
        
        public override int SerializedSize{get { return 10; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessBitmapBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
            bitmapGroupIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
        }
        public  ShaderPostprocessBitmapBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
            bitmapGroupIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(flags);
                binaryWriter.Write(bitmapGroupIndex);
                binaryWriter.Write(logBitmapDimension);
                return nextAddress;
            }
        }
    };
}
