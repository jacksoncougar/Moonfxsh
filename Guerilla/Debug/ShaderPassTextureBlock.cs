// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderPassTextureBlock : ShaderPassTextureBlockBase
    {
        public  ShaderPassTextureBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class ShaderPassTextureBlockBase
    {
        internal Moonfish.Tags.StringID sourceParameter;
        internal SourceExtern sourceExtern;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal Mode mode;
        internal byte[] invalidName_1;
        internal DotMapping dotMapping;
        internal short inputStage03;
        internal byte[] invalidName_2;
        internal ShaderTextureStateAddressStateBlock[] addressState;
        internal ShaderTextureStateFilterStateBlock[] filterState;
        internal ShaderTextureStateKillStateBlock[] killState;
        internal ShaderTextureStateMiscStateBlock[] miscState;
        internal ShaderTextureStateConstantBlock[] constants;
        internal  ShaderPassTextureBlockBase(System.IO.BinaryReader binaryReader)
        {
            sourceParameter = binaryReader.ReadStringID();
            sourceExtern = (SourceExtern)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            mode = (Mode)binaryReader.ReadInt16();
            invalidName_1 = binaryReader.ReadBytes(2);
            dotMapping = (DotMapping)binaryReader.ReadInt16();
            inputStage03 = binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            ReadShaderTextureStateAddressStateBlockArray(binaryReader);
            ReadShaderTextureStateFilterStateBlockArray(binaryReader);
            ReadShaderTextureStateKillStateBlockArray(binaryReader);
            ReadShaderTextureStateMiscStateBlockArray(binaryReader);
            ReadShaderTextureStateConstantBlockArray(binaryReader);
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
        internal  virtual ShaderTextureStateAddressStateBlock[] ReadShaderTextureStateAddressStateBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTextureStateAddressStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTextureStateAddressStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTextureStateAddressStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTextureStateFilterStateBlock[] ReadShaderTextureStateFilterStateBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTextureStateFilterStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTextureStateFilterStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTextureStateFilterStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTextureStateKillStateBlock[] ReadShaderTextureStateKillStateBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTextureStateKillStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTextureStateKillStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTextureStateKillStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTextureStateMiscStateBlock[] ReadShaderTextureStateMiscStateBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTextureStateMiscStateBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTextureStateMiscStateBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTextureStateMiscStateBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual ShaderTextureStateConstantBlock[] ReadShaderTextureStateConstantBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ShaderTextureStateConstantBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ShaderTextureStateConstantBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ShaderTextureStateConstantBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTextureStateAddressStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTextureStateFilterStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTextureStateKillStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTextureStateMiscStateBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteShaderTextureStateConstantBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sourceParameter);
                binaryWriter.Write((Int16)sourceExtern);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write((Int16)mode);
                binaryWriter.Write(invalidName_1, 0, 2);
                binaryWriter.Write((Int16)dotMapping);
                binaryWriter.Write(inputStage03);
                binaryWriter.Write(invalidName_2, 0, 2);
                WriteShaderTextureStateAddressStateBlockArray(binaryWriter);
                WriteShaderTextureStateFilterStateBlockArray(binaryWriter);
                WriteShaderTextureStateKillStateBlockArray(binaryWriter);
                WriteShaderTextureStateMiscStateBlockArray(binaryWriter);
                WriteShaderTextureStateConstantBlockArray(binaryWriter);
            }
        }
        internal enum SourceExtern : short
        
        {
            None = 0,
            GLOBALVectorNormalization = 1,
            UNUSED = 2,
            GLOBALTargetTexaccum = 3,
            UNUSED0 = 4,
            GLOBALTargetFrameBuffer = 5,
            GLOBATargetZ = 6,
            UNUSED1 = 7,
            GLOBALTargetShadow = 8,
            LIGHTFalloff = 9,
            LIGHTGel = 10,
            LIGHTMAP = 11,
            UNUSED2 = 12,
            GLOBALShadowBuffer = 13,
            GLOBALGradientSeparate = 14,
            GLOBALGradientProduct = 15,
            HUDBitmap = 16,
            GLOBALActiveCamo = 17,
            GLOBALTextureCamera = 18,
            GLOBALWaterReflection = 19,
            GLOBALWaterRefraction = 20,
            GLOBALAux1 = 21,
            GLOBALAux2 = 22,
            GLOBALParticleDistortion = 23,
            GLOBALConvolution1 = 24,
            GLOBALConvolution2 = 25,
            SHADERActiveCamoBump = 26,
            FIRSTPERSONScope = 27,
        };
        internal enum Mode : short
        
        {
            InvalidName2D = 0,
            InvalidName3D = 1,
            CubeMap = 2,
            Passthrough = 3,
            Texkill = 4,
            InvalidName2DDependentAR = 5,
            InvalidName2DDependentGB = 6,
            InvalidName2DBumpenv = 7,
            InvalidName2DBumpenvLuminance = 8,
            InvalidName3DBRDF = 9,
            DotProduct = 10,
            DotProduct2D = 11,
            DotProduct3D = 12,
            DotProductCubeMap = 13,
            DotProductZW = 14,
            DotReflectDiffuse = 15,
            DotReflectSpecular = 16,
            DotReflectSpecularConst = 17,
            None = 18,
        };
        internal enum DotMapping : short
        
        {
            InvalidName0To1 = 0,
            SignedD3D = 1,
            SignedGL = 2,
            SignedNV = 3,
            HILO0To1 = 4,
            HILOSignedHemisphereD3D = 5,
            HILOSignedHemisphereGL = 6,
            HILOSignedHemisphereNV = 7,
        };
    };
}
