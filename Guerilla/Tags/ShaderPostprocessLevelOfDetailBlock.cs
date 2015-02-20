using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessLevelOfDetailBlock : ShaderPostprocessLevelOfDetailBlockBase
    {
        public  ShaderPostprocessLevelOfDetailBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152)]
    public class ShaderPostprocessLevelOfDetailBlockBase
    {
        internal float projectedHeightPercentage;
        internal int availableLayers;
        internal ShaderPostprocessLayerBlock[] layers;
        internal ShaderPostprocessPassBlock[] passes;
        internal ShaderPostprocessImplementationBlock[] implementations;
        internal ShaderPostprocessBitmapBlock[] bitmaps;
        internal ShaderPostprocessBitmapTransformBlock[] bitmapTransforms;
        internal ShaderPostprocessValueBlock[] values;
        internal ShaderPostprocessColorBlock[] colors;
        internal ShaderPostprocessBitmapTransformOverlayBlock[] bitmapTransformOverlays;
        internal ShaderPostprocessValueOverlayBlock[] valueOverlays;
        internal ShaderPostprocessColorOverlayBlock[] colorOverlays;
        internal ShaderPostprocessVertexShaderConstantBlock[] vertexShaderConstants;
        internal ShaderGpuStateStructBlock gPUState;
        internal  ShaderPostprocessLevelOfDetailBlockBase(BinaryReader binaryReader)
        {
            this.projectedHeightPercentage = binaryReader.ReadSingle();
            this.availableLayers = binaryReader.ReadInt32();
            this.layers = ReadShaderPostprocessLayerBlockArray(binaryReader);
            this.passes = ReadShaderPostprocessPassBlockArray(binaryReader);
            this.implementations = ReadShaderPostprocessImplementationBlockArray(binaryReader);
            this.bitmaps = ReadShaderPostprocessBitmapBlockArray(binaryReader);
            this.bitmapTransforms = ReadShaderPostprocessBitmapTransformBlockArray(binaryReader);
            this.values = ReadShaderPostprocessValueBlockArray(binaryReader);
            this.colors = ReadShaderPostprocessColorBlockArray(binaryReader);
            this.bitmapTransformOverlays = ReadShaderPostprocessBitmapTransformOverlayBlockArray(binaryReader);
            this.valueOverlays = ReadShaderPostprocessValueOverlayBlockArray(binaryReader);
            this.colorOverlays = ReadShaderPostprocessColorOverlayBlockArray(binaryReader);
            this.vertexShaderConstants = ReadShaderPostprocessVertexShaderConstantBlockArray(binaryReader);
            this.gPUState = new ShaderGpuStateStructBlock(binaryReader);
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
        internal  virtual ShaderPostprocessLayerBlock[] ReadShaderPostprocessLayerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessLayerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessLayerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessLayerBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessPassBlock[] ReadShaderPostprocessPassBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessPassBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessPassBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessPassBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessImplementationBlock[] ReadShaderPostprocessImplementationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessImplementationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessImplementationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessImplementationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessBitmapBlock[] ReadShaderPostprocessBitmapBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessBitmapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessBitmapBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessBitmapBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessBitmapTransformBlock[] ReadShaderPostprocessBitmapTransformBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessBitmapTransformBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessBitmapTransformBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessBitmapTransformBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessValueBlock[] ReadShaderPostprocessValueBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessValueBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessValueBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessValueBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessColorBlock[] ReadShaderPostprocessColorBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessColorBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessColorBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessColorBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessBitmapTransformOverlayBlock[] ReadShaderPostprocessBitmapTransformOverlayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessBitmapTransformOverlayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessBitmapTransformOverlayBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessBitmapTransformOverlayBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessValueOverlayBlock[] ReadShaderPostprocessValueOverlayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessValueOverlayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessValueOverlayBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessValueOverlayBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessColorOverlayBlock[] ReadShaderPostprocessColorOverlayBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessColorOverlayBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessColorOverlayBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessColorOverlayBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessVertexShaderConstantBlock[] ReadShaderPostprocessVertexShaderConstantBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessVertexShaderConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessVertexShaderConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessVertexShaderConstantBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
