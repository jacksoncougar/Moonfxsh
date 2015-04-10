// ReSharper disable All
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
        public  ShaderPostprocessDefinitionNewBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ShaderPostprocessDefinitionNewBlockBase(System.IO.BinaryReader binaryReader)
        {
            shaderTemplateIndex = binaryReader.ReadInt32();
            ReadShaderPostprocessBitmapNewBlockArray(binaryReader);
            ReadPixel32BlockArray(binaryReader);
            ReadRealVector4dBlockArray(binaryReader);
            ReadShaderPostprocessLevelOfDetailNewBlockArray(binaryReader);
            ReadTagBlockIndexBlockArray(binaryReader);
            ReadTagBlockIndexBlockArray(binaryReader);
            ReadShaderPostprocessImplementationNewBlockArray(binaryReader);
            ReadShaderPostprocessOverlayNewBlockArray(binaryReader);
            ReadShaderPostprocessOverlayReferenceNewBlockArray(binaryReader);
            ReadShaderPostprocessAnimatedParameterNewBlockArray(binaryReader);
            ReadShaderPostprocessAnimatedParameterReferenceNewBlockArray(binaryReader);
            ReadShaderPostprocessBitmapPropertyBlockArray(binaryReader);
            ReadShaderPostprocessColorPropertyBlockArray(binaryReader);
            ReadShaderPostprocessValuePropertyBlockArray(binaryReader);
            ReadShaderPostprocessLevelOfDetailBlockArray(binaryReader);
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
        internal  virtual ShaderPostprocessBitmapNewBlock[] ReadShaderPostprocessBitmapNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual Pixel32Block[] ReadPixel32BlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual RealVector4dBlock[] ReadRealVector4dBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessLevelOfDetailNewBlock[] ReadShaderPostprocessLevelOfDetailNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual TagBlockIndexBlock[] ReadTagBlockIndexBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessImplementationNewBlock[] ReadShaderPostprocessImplementationNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessOverlayNewBlock[] ReadShaderPostprocessOverlayNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessOverlayReferenceNewBlock[] ReadShaderPostprocessOverlayReferenceNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessAnimatedParameterNewBlock[] ReadShaderPostprocessAnimatedParameterNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessAnimatedParameterReferenceNewBlock[] ReadShaderPostprocessAnimatedParameterReferenceNewBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessBitmapPropertyBlock[] ReadShaderPostprocessBitmapPropertyBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessColorPropertyBlock[] ReadShaderPostprocessColorPropertyBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessValuePropertyBlock[] ReadShaderPostprocessValuePropertyBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual ShaderPostprocessLevelOfDetailBlock[] ReadShaderPostprocessLevelOfDetailBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessBitmapNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WritePixel32BlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteRealVector4dBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessLevelOfDetailNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteTagBlockIndexBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessImplementationNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessOverlayNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessOverlayReferenceNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessAnimatedParameterNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessAnimatedParameterReferenceNewBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessBitmapPropertyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessColorPropertyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessValuePropertyBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderPostprocessLevelOfDetailBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(shaderTemplateIndex);
                WriteShaderPostprocessBitmapNewBlockArray(binaryWriter);
                WritePixel32BlockArray(binaryWriter);
                WriteRealVector4dBlockArray(binaryWriter);
                WriteShaderPostprocessLevelOfDetailNewBlockArray(binaryWriter);
                WriteTagBlockIndexBlockArray(binaryWriter);
                WriteTagBlockIndexBlockArray(binaryWriter);
                WriteShaderPostprocessImplementationNewBlockArray(binaryWriter);
                WriteShaderPostprocessOverlayNewBlockArray(binaryWriter);
                WriteShaderPostprocessOverlayReferenceNewBlockArray(binaryWriter);
                WriteShaderPostprocessAnimatedParameterNewBlockArray(binaryWriter);
                WriteShaderPostprocessAnimatedParameterReferenceNewBlockArray(binaryWriter);
                WriteShaderPostprocessBitmapPropertyBlockArray(binaryWriter);
                WriteShaderPostprocessColorPropertyBlockArray(binaryWriter);
                WriteShaderPostprocessValuePropertyBlockArray(binaryWriter);
                WriteShaderPostprocessLevelOfDetailBlockArray(binaryWriter);
            }
        }
    };
}
