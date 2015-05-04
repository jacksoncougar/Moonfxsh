// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessBitmapNewBlock : ShaderPostprocessBitmapNewBlockBase
    {
        public  ShaderPostprocessBitmapNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessBitmapNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderPostprocessBitmapNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.TagIdent bitmapGroup;
        internal int bitmapIndex;
        internal float logBitmapDimension;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessBitmapNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            bitmapGroup = binaryReader.ReadTagIdent();
            bitmapIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
        }
        public  ShaderPostprocessBitmapNewBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            bitmapGroup = binaryReader.ReadTagIdent();
            bitmapIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(bitmapGroup);
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(logBitmapDimension);
                return nextAddress;
            }
        }
    };
}
