// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessAnimatedParameterNewBlock : ShaderPostprocessAnimatedParameterNewBlockBase
    {
        public  ShaderPostprocessAnimatedParameterNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class ShaderPostprocessAnimatedParameterNewBlockBase  : IGuerilla
    {
        internal TagBlockIndexStructBlock overlayReferences;
        internal  ShaderPostprocessAnimatedParameterNewBlockBase(BinaryReader binaryReader)
        {
            overlayReferences = new TagBlockIndexStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                overlayReferences.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
