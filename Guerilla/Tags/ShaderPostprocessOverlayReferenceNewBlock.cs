// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessOverlayReferenceNewBlock : ShaderPostprocessOverlayReferenceNewBlockBase
    {
        public  ShaderPostprocessOverlayReferenceNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPostprocessOverlayReferenceNewBlockBase  : IGuerilla
    {
        internal short overlayIndex;
        internal short transformIndex;
        internal  ShaderPostprocessOverlayReferenceNewBlockBase(BinaryReader binaryReader)
        {
            overlayIndex = binaryReader.ReadInt16();
            transformIndex = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(overlayIndex);
                binaryWriter.Write(transformIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
