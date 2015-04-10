// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LightVolumeVolumeBlock : LightVolumeVolumeBlockBase
    {
        public  LightVolumeVolumeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 152)]
    public class LightVolumeVolumeBlockBase
    {
        internal Flags flags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal int spriteCount4256;
        internal ScalarFunctionStructBlock offsetFunction;
        internal ScalarFunctionStructBlock radiusFunction;
        internal ScalarFunctionStructBlock brightnessFunction;
        internal ColorFunctionStructBlock colorFunction;
        internal ScalarFunctionStructBlock facingFunction;
        internal LightVolumeAspectBlock[] aspect;
        internal float radiusFracMin00039062510;
        internal float dEPRECATEDXStepExponent050875;
        internal int dEPRECATEDXBufferLength32512;
        internal int xBufferSpacing1256;
        internal int xBufferMinIterations1256;
        internal int xBufferMaxIterations1256;
        internal float xDeltaMaxError000101;
        internal byte[] invalidName_;
        internal LightVolumeRuntimeOffsetBlock[] invalidName_0;
        internal byte[] invalidName_1;
        internal  LightVolumeVolumeBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
            spriteCount4256 = binaryReader.ReadInt32();
            offsetFunction = new ScalarFunctionStructBlock(binaryReader);
            radiusFunction = new ScalarFunctionStructBlock(binaryReader);
            brightnessFunction = new ScalarFunctionStructBlock(binaryReader);
            colorFunction = new ColorFunctionStructBlock(binaryReader);
            facingFunction = new ScalarFunctionStructBlock(binaryReader);
            ReadLightVolumeAspectBlockArray(binaryReader);
            radiusFracMin00039062510 = binaryReader.ReadSingle();
            dEPRECATEDXStepExponent050875 = binaryReader.ReadSingle();
            dEPRECATEDXBufferLength32512 = binaryReader.ReadInt32();
            xBufferSpacing1256 = binaryReader.ReadInt32();
            xBufferMinIterations1256 = binaryReader.ReadInt32();
            xBufferMaxIterations1256 = binaryReader.ReadInt32();
            xDeltaMaxError000101 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            ReadLightVolumeRuntimeOffsetBlockArray(binaryReader);
            invalidName_1 = binaryReader.ReadBytes(48);
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
        internal  virtual LightVolumeAspectBlock[] ReadLightVolumeAspectBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightVolumeAspectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightVolumeAspectBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightVolumeAspectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightVolumeRuntimeOffsetBlock[] ReadLightVolumeRuntimeOffsetBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightVolumeRuntimeOffsetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightVolumeRuntimeOffsetBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightVolumeRuntimeOffsetBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightVolumeAspectBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteLightVolumeRuntimeOffsetBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(spriteCount4256);
                offsetFunction.Write(binaryWriter);
                radiusFunction.Write(binaryWriter);
                brightnessFunction.Write(binaryWriter);
                colorFunction.Write(binaryWriter);
                facingFunction.Write(binaryWriter);
                WriteLightVolumeAspectBlockArray(binaryWriter);
                binaryWriter.Write(radiusFracMin00039062510);
                binaryWriter.Write(dEPRECATEDXStepExponent050875);
                binaryWriter.Write(dEPRECATEDXBufferLength32512);
                binaryWriter.Write(xBufferSpacing1256);
                binaryWriter.Write(xBufferMinIterations1256);
                binaryWriter.Write(xBufferMaxIterations1256);
                binaryWriter.Write(xDeltaMaxError000101);
                binaryWriter.Write(invalidName_, 0, 4);
                WriteLightVolumeRuntimeOffsetBlockArray(binaryWriter);
                binaryWriter.Write(invalidName_1, 0, 48);
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        
        {
            ForceLinearRadiusFunction = 1,
            ForceLinearOffset = 2,
            ForceDifferentialEvaluation = 4,
            Fuzzy = 8,
            NotScaledByEventDuration = 16,
            ScaledByMarker = 32,
        };
    };
}
