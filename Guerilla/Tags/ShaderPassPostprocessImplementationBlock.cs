using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassPostprocessImplementationBlock : ShaderPassPostprocessImplementationBlockBase
    {
        public  ShaderPassPostprocessImplementationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 438)]
    public class ShaderPassPostprocessImplementationBlockBase
    {
        internal ShaderGpuStateStructBlock gPUState;
        internal ShaderGpuStateReferenceStructBlock gPUConstantState;
        internal ShaderGpuStateReferenceStructBlock gPUVolatileState;
        internal ShaderGpuStateReferenceStructBlock gPUDefaultState;
        [TagReference("vrtx")]
        internal Moonfish.Tags.TagReference vertexShader;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal byte[] invalidName_2;
        internal ExternReferenceBlock[] valueExterns;
        internal ExternReferenceBlock[] colorExterns;
        internal ExternReferenceBlock[] switchExterns;
        internal short bitmapParameterCount;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal PixelShaderFragmentBlock[] pixelShaderFragments;
        internal PixelShaderPermutationBlock[] pixelShaderPermutations;
        internal PixelShaderCombinerBlock[] pixelShaderCombiners;
        internal PixelShaderConstantBlock[] pixelShaderConstants;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal  ShaderPassPostprocessImplementationBlockBase(BinaryReader binaryReader)
        {
            this.gPUState = new ShaderGpuStateStructBlock(binaryReader);
            this.gPUConstantState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            this.gPUVolatileState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            this.gPUDefaultState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            this.vertexShader = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(8);
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.valueExterns = ReadExternReferenceBlockArray(binaryReader);
            this.colorExterns = ReadExternReferenceBlockArray(binaryReader);
            this.switchExterns = ReadExternReferenceBlockArray(binaryReader);
            this.bitmapParameterCount = binaryReader.ReadInt16();
            this.invalidName_3 = binaryReader.ReadBytes(2);
            this.invalidName_4 = binaryReader.ReadBytes(240);
            this.pixelShaderFragments = ReadPixelShaderFragmentBlockArray(binaryReader);
            this.pixelShaderPermutations = ReadPixelShaderPermutationBlockArray(binaryReader);
            this.pixelShaderCombiners = ReadPixelShaderCombinerBlockArray(binaryReader);
            this.pixelShaderConstants = ReadPixelShaderConstantBlockArray(binaryReader);
            this.invalidName_5 = binaryReader.ReadBytes(4);
            this.invalidName_6 = binaryReader.ReadBytes(4);
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
        internal  virtual ExternReferenceBlock[] ReadExternReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ExternReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ExternReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ExternReferenceBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderFragmentBlock[] ReadPixelShaderFragmentBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderFragmentBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderFragmentBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderFragmentBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderPermutationBlock[] ReadPixelShaderPermutationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderPermutationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderPermutationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderPermutationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderCombinerBlock[] ReadPixelShaderCombinerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderCombinerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderCombinerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderCombinerBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual PixelShaderConstantBlock[] ReadPixelShaderConstantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PixelShaderConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PixelShaderConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PixelShaderConstantBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
