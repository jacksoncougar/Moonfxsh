// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderPostprocessOverlayReferenceNewBlock : ShaderPostprocessOverlayReferenceNewBlockBase
    {
        public  ShaderPostprocessOverlayReferenceNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderPostprocessOverlayReferenceNewBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPostprocessOverlayReferenceNewBlockBase : GuerillaBlock
    {
        internal short overlayIndex;
        internal short transformIndex;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderPostprocessOverlayReferenceNewBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            overlayIndex = binaryReader.ReadInt16();
            transformIndex = binaryReader.ReadInt16();
        }
        public  ShaderPostprocessOverlayReferenceNewBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            overlayIndex = binaryReader.ReadInt16();
            transformIndex = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(overlayIndex);
                binaryWriter.Write(transformIndex);
                return nextAddress;
            }
        }
    };
}
