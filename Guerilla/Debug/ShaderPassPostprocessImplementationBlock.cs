// ReSharper disable All
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
        public  ShaderPassPostprocessImplementationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPassPostprocessImplementationBlockBase(System.IO.BinaryReader binaryReader)
        {
            gPUState = new ShaderGpuStateStructBlock(binaryReader);
            gPUConstantState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            gPUVolatileState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            gPUDefaultState = new ShaderGpuStateReferenceStructBlock(binaryReader);
            vertexShader = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(8);
            invalidName_0 = binaryReader.ReadBytes(8);
            invalidName_1 = binaryReader.ReadBytes(4);
            invalidName_2 = binaryReader.ReadBytes(4);
            ReadExternReferenceBlockArray(binaryReader);
            ReadExternReferenceBlockArray(binaryReader);
            ReadExternReferenceBlockArray(binaryReader);
            bitmapParameterCount = binaryReader.ReadInt16();
            invalidName_3 = binaryReader.ReadBytes(2);
            invalidName_4 = binaryReader.ReadBytes(240);
            ReadPixelShaderFragmentBlockArray(binaryReader);
            ReadPixelShaderPermutationBlockArray(binaryReader);
            ReadPixelShaderCombinerBlockArray(binaryReader);
            ReadPixelShaderConstantBlockArray(binaryReader);
            invalidName_5 = binaryReader.ReadBytes(4);
            invalidName_6 = binaryReader.ReadBytes(4);
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
        internal  virtual ExternReferenceBlock[] ReadExternReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PixelShaderFragmentBlock[] ReadPixelShaderFragmentBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PixelShaderPermutationBlock[] ReadPixelShaderPermutationBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PixelShaderCombinerBlock[] ReadPixelShaderCombinerBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual PixelShaderConstantBlock[] ReadPixelShaderConstantBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteExternReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePixelShaderFragmentBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePixelShaderPermutationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePixelShaderCombinerBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePixelShaderConstantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                gPUState.Write(binaryWriter);
                gPUConstantState.Write(binaryWriter);
                gPUVolatileState.Write(binaryWriter);
                gPUDefaultState.Write(binaryWriter);
                binaryWriter.Write(vertexShader);
                binaryWriter.Write(invalidName_, 0, 8);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(invalidName_2, 0, 4);
                WriteExternReferenceBlockArray(binaryWriter);
                WriteExternReferenceBlockArray(binaryWriter);
                WriteExternReferenceBlockArray(binaryWriter);
                binaryWriter.Write(bitmapParameterCount);
                binaryWriter.Write(invalidName_3, 0, 2);
                binaryWriter.Write(invalidName_4, 0, 240);
                WritePixelShaderFragmentBlockArray(binaryWriter);
                WritePixelShaderPermutationBlockArray(binaryWriter);
                WritePixelShaderCombinerBlockArray(binaryWriter);
                WritePixelShaderConstantBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_5, 0, 4);
                binaryWriter.Write(invalidName_6, 0, 4);
            }
        }
    };
}
