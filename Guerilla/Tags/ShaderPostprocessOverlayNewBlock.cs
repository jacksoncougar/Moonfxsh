// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessOverlayNewBlock : ShaderPostprocessOverlayNewBlockBase
    {
        public  ShaderPostprocessOverlayNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ShaderPostprocessOverlayNewBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodInSeconds;
        internal ScalarFunctionStructBlock function;
        internal  ShaderPostprocessOverlayNewBlockBase(BinaryReader binaryReader)
        {
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodInSeconds = binaryReader.ReadSingle();
            function = new ScalarFunctionStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(inputName);
                binaryWriter.Write(rangeName);
                binaryWriter.Write(timePeriodInSeconds);
                function.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
