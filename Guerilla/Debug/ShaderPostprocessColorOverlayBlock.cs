// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessColorOverlayBlock : ShaderPostprocessColorOverlayBlockBase
    {
        public  ShaderPostprocessColorOverlayBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 21)]
    public class ShaderPostprocessColorOverlayBlockBase
    {
        internal byte parameterIndex;
        internal Moonfish.Tags.StringID inputName;
        internal Moonfish.Tags.StringID rangeName;
        internal float timePeriodInSeconds;
        internal ColorFunctionStructBlock function;
        internal  ShaderPostprocessColorOverlayBlockBase(System.IO.BinaryReader binaryReader)
        {
            parameterIndex = binaryReader.ReadByte();
            inputName = binaryReader.ReadStringID();
            rangeName = binaryReader.ReadStringID();
            timePeriodInSeconds = binaryReader.ReadSingle();
            function = new ColorFunctionStructBlock(binaryReader);
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
                binaryWriter.Write(inputName);
                binaryWriter.Write(rangeName);
                binaryWriter.Write(timePeriodInSeconds);
                function.Write(binaryWriter);
            }
        }
    };
}
