using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPostprocessDefinitionNewBlock : ShaderPostprocessDefinitionNewBlockBase
    {
        public  ShaderPostprocessDefinitionNewBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 124)]
    public class ShaderPostprocessDefinitionNewBlockBase
    {
        internal int shaderTemplateIndex;
        internal ShaderPostprocessBitmapNewBlock[] bitmaps;
        internal Pixel32Block[] pixelConstants;
        internal RealVector4dBlock[] vertexConstants;
        internal ShaderPostprocessLevelOfDetailNewBlock[] levelsOfDetail;
        internal TagBlockIndexBlock[] layers;
        internal TagBlockIndexBlock[] passes;
        internal ShaderPostprocessImplementationNewBlock[] implementations;
        internal ShaderPostprocessOverlayNewBlock[] overlays;
        internal ShaderPostprocessOverlayReferenceNewBlock[] overlayReferences;
        internal ShaderPostprocessAnimatedParameterNewBlock[] animatedParameters;
        internal ShaderPostprocessAnimatedParameterReferenceNewBlock[] animatedParameterReferences;
        internal ShaderPostprocessBitmapPropertyBlock[] bitmapProperties;
        internal ShaderPostprocessColorPropertyBlock[] colorProperties;
        internal ShaderPostprocessValuePropertyBlock[] valueProperties;
        internal ShaderPostprocessLevelOfDetailBlock[] oldLevelsOfDetail;
        internal  ShaderPostprocessDefinitionNewBlockBase(BinaryReader binaryReader)
        {
            this.shaderTemplateIndex = binaryReader.ReadInt32();
            this.bitmaps = ReadShaderPostprocessBitmapNewBlockArray(binaryReader);
            this.pixelConstants = ReadPixel32BlockArray(binaryReader);
            this.vertexConstants = ReadRealVector4dBlockArray(binaryReader);
            this.levelsOfDetail = ReadShaderPostprocessLevelOfDetailNewBlockArray(binaryReader);
            this.layers = ReadTagBlockIndexBlockArray(binaryReader);
            this.passes = ReadTagBlockIndexBlockArray(binaryReader);
            this.implementations = ReadShaderPostprocessImplementationNewBlockArray(binaryReader);
            this.overlays = ReadShaderPostprocessOverlayNewBlockArray(binaryReader);
            this.overlayReferences = ReadShaderPostprocessOverlayReferenceNewBlockArray(binaryReader);
            this.animatedParameters = ReadShaderPostprocessAnimatedParameterNewBlockArray(binaryReader);
            this.animatedParameterReferences = ReadShaderPostprocessAnimatedParameterReferenceNewBlockArray(binaryReader);
            this.bitmapProperties = ReadShaderPostprocessBitmapPropertyBlockArray(binaryReader);
            this.colorProperties = ReadShaderPostprocessColorPropertyBlockArray(binaryReader);
            this.valueProperties = ReadShaderPostprocessValuePropertyBlockArray(binaryReader);
            this.oldLevelsOfDetail = ReadShaderPostprocessLevelOfDetailBlockArray(binaryReader);
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
        internal  virtual ShaderPostprocessBitmapNewBlock[] ReadShaderPostprocessBitmapNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessBitmapNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessBitmapNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessBitmapNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual Pixel32Block[] ReadPixel32BlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(Pixel32Block));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new Pixel32Block[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new Pixel32Block(binaryReader);
                }
            }
            return array;
        }
        internal  virtual RealVector4dBlock[] ReadRealVector4dBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(RealVector4dBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new RealVector4dBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new RealVector4dBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessLevelOfDetailNewBlock[] ReadShaderPostprocessLevelOfDetailNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessLevelOfDetailNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessLevelOfDetailNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessLevelOfDetailNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual TagBlockIndexBlock[] ReadTagBlockIndexBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(TagBlockIndexBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new TagBlockIndexBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new TagBlockIndexBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessImplementationNewBlock[] ReadShaderPostprocessImplementationNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessImplementationNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessImplementationNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessImplementationNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessOverlayNewBlock[] ReadShaderPostprocessOverlayNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessOverlayNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessOverlayNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessOverlayNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessOverlayReferenceNewBlock[] ReadShaderPostprocessOverlayReferenceNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessOverlayReferenceNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessOverlayReferenceNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessOverlayReferenceNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessAnimatedParameterNewBlock[] ReadShaderPostprocessAnimatedParameterNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessAnimatedParameterNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessAnimatedParameterNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessAnimatedParameterNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessAnimatedParameterReferenceNewBlock[] ReadShaderPostprocessAnimatedParameterReferenceNewBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessAnimatedParameterReferenceNewBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessAnimatedParameterReferenceNewBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessAnimatedParameterReferenceNewBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessBitmapPropertyBlock[] ReadShaderPostprocessBitmapPropertyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessBitmapPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessBitmapPropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessBitmapPropertyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessColorPropertyBlock[] ReadShaderPostprocessColorPropertyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessColorPropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessColorPropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessColorPropertyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessValuePropertyBlock[] ReadShaderPostprocessValuePropertyBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessValuePropertyBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessValuePropertyBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessValuePropertyBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderPostprocessLevelOfDetailBlock[] ReadShaderPostprocessLevelOfDetailBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderPostprocessLevelOfDetailBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderPostprocessLevelOfDetailBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderPostprocessLevelOfDetailBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
