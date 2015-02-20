using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessPixelShader : ShaderPostprocessPixelShaderBase
    {
        public  ShaderPostprocessPixelShader(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 44)]
    public class ShaderPostprocessPixelShaderBase
    {
        internal int pixelShaderHandleRuntime;
        internal int pixelShaderHandleRuntime0;
        internal int pixelShaderHandleRuntime1;
        internal ShaderPostprocessPixelShaderConstantDefaults[] constantRegisterDefaults;
        internal byte[] compiledShader;
        internal byte[] compiledShader0;
        internal byte[] compiledShader1;
        internal  ShaderPostprocessPixelShaderBase(BinaryReader binaryReader)
        {
            this.pixelShaderHandleRuntime = binaryReader.ReadInt32();
            this.pixelShaderHandleRuntime0 = binaryReader.ReadInt32();
            this.pixelShaderHandleRuntime1 = binaryReader.ReadInt32();
            this.constantRegisterDefaults = ReadShaderPostprocessPixelShaderConstantDefaultsArray(binaryReader);
            this.compiledShader = ReadData(binaryReader);
            this.compiledShader0 = ReadData(binaryReader);
            this.compiledShader1 = ReadData(binaryReader);
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
        internal  virtual ShaderPostprocessPixelShaderConstantDefaults[] ReadShaderPostprocessPixelShaderConstantDefaultsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessPixelShaderConstantDefaults));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessPixelShaderConstantDefaults[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessPixelShaderConstantDefaults(binaryReader);
                }
            }
            return array;
        }
    };
}
