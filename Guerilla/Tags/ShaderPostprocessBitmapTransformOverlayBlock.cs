using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessBitmapTransformOverlayBlock : ShaderPostprocessBitmapTransformOverlayBlockBase
    {
        public  ShaderPostprocessBitmapTransformOverlayBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 23)]
    public class ShaderPostprocessBitmapTransformOverlayBlockBase
    {
        internal byte parameterIndex;
        internal byte transformIndex;
        internal byte animationPropertyType;
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodInSeconds;
        internal ScalarFunctionStructBlock function;
        internal  ShaderPostprocessBitmapTransformOverlayBlockBase(BinaryReader binaryReader)
        {
            this.parameterIndex = binaryReader.ReadByte();
            this.transformIndex = binaryReader.ReadByte();
            this.animationPropertyType = binaryReader.ReadByte();
            this.inputName = binaryReader.ReadStringID();
            this.rangeName = binaryReader.ReadStringID();
            this.timePeriodInSeconds = binaryReader.ReadSingle();
            this.function = new ScalarFunctionStructBlock(binaryReader);
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
