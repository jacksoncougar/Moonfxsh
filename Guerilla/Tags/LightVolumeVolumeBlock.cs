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
        public  LightVolumeVolumeBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  LightVolumeVolumeBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.bitmap = binaryReader.ReadTagReference();
            this.spriteCount4256 = binaryReader.ReadInt32();
            this.offsetFunction = new ScalarFunctionStructBlock(binaryReader);
            this.radiusFunction = new ScalarFunctionStructBlock(binaryReader);
            this.brightnessFunction = new ScalarFunctionStructBlock(binaryReader);
            this.colorFunction = new ColorFunctionStructBlock(binaryReader);
            this.facingFunction = new ScalarFunctionStructBlock(binaryReader);
            this.aspect = ReadLightVolumeAspectBlockArray(binaryReader);
            this.radiusFracMin00039062510 = binaryReader.ReadSingle();
            this.dEPRECATEDXStepExponent050875 = binaryReader.ReadSingle();
            this.dEPRECATEDXBufferLength32512 = binaryReader.ReadInt32();
            this.xBufferSpacing1256 = binaryReader.ReadInt32();
            this.xBufferMinIterations1256 = binaryReader.ReadInt32();
            this.xBufferMaxIterations1256 = binaryReader.ReadInt32();
            this.xDeltaMaxError000101 = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.invalidName_0 = ReadLightVolumeRuntimeOffsetBlockArray(binaryReader);
            this.invalidName_1 = binaryReader.ReadBytes(48);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
        }
        internal  virtual LightVolumeAspectBlock[] ReadLightVolumeAspectBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightVolumeAspectBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightVolumeAspectBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightVolumeAspectBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual LightVolumeRuntimeOffsetBlock[] ReadLightVolumeRuntimeOffsetBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LightVolumeRuntimeOffsetBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LightVolumeRuntimeOffsetBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LightVolumeRuntimeOffsetBlock(binaryReader);
                }
            }
            return array;
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
