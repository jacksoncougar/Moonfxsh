// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class LightVolumeVolumeBlock : LightVolumeVolumeBlockBase
    {
        public LightVolumeVolumeBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 152, Alignment = 4)]
    public class LightVolumeVolumeBlockBase : GuerillaBlock
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
        public override int SerializedSize { get { return 152; } }
        public override int Alignment { get { return 4; } }
        public LightVolumeVolumeBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt32();
            bitmap = binaryReader.ReadTagReference();
            spriteCount4256 = binaryReader.ReadInt32();
            offsetFunction = new ScalarFunctionStructBlock();
            blamPointers.Concat(offsetFunction.ReadFields(binaryReader));
            radiusFunction = new ScalarFunctionStructBlock();
            blamPointers.Concat(radiusFunction.ReadFields(binaryReader));
            brightnessFunction = new ScalarFunctionStructBlock();
            blamPointers.Concat(brightnessFunction.ReadFields(binaryReader));
            colorFunction = new ColorFunctionStructBlock();
            blamPointers.Concat(colorFunction.ReadFields(binaryReader));
            facingFunction = new ScalarFunctionStructBlock();
            blamPointers.Concat(facingFunction.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LightVolumeAspectBlock>(binaryReader));
            radiusFracMin00039062510 = binaryReader.ReadSingle();
            dEPRECATEDXStepExponent050875 = binaryReader.ReadSingle();
            dEPRECATEDXBufferLength32512 = binaryReader.ReadInt32();
            xBufferSpacing1256 = binaryReader.ReadInt32();
            xBufferMinIterations1256 = binaryReader.ReadInt32();
            xBufferMaxIterations1256 = binaryReader.ReadInt32();
            xDeltaMaxError000101 = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer<LightVolumeRuntimeOffsetBlock>(binaryReader));
            invalidName_1 = binaryReader.ReadBytes(48);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            offsetFunction.ReadPointers(binaryReader, blamPointers);
            radiusFunction.ReadPointers(binaryReader, blamPointers);
            brightnessFunction.ReadPointers(binaryReader, blamPointers);
            colorFunction.ReadPointers(binaryReader, blamPointers);
            facingFunction.ReadPointers(binaryReader, blamPointers);
            aspect = ReadBlockArrayData<LightVolumeAspectBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_0 = ReadBlockArrayData<LightVolumeRuntimeOffsetBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
                nextAddress = Guerilla.WriteBlockArray<LightVolumeAspectBlock>(binaryWriter, aspect, nextAddress);
                binaryWriter.Write(radiusFracMin00039062510);
                binaryWriter.Write(dEPRECATEDXStepExponent050875);
                binaryWriter.Write(dEPRECATEDXBufferLength32512);
                binaryWriter.Write(xBufferSpacing1256);
                binaryWriter.Write(xBufferMinIterations1256);
                binaryWriter.Write(xBufferMaxIterations1256);
                binaryWriter.Write(xDeltaMaxError000101);
                binaryWriter.Write(invalidName_, 0, 4);
                nextAddress = Guerilla.WriteBlockArray<LightVolumeRuntimeOffsetBlock>(binaryWriter, invalidName_0, nextAddress);
                binaryWriter.Write(invalidName_1, 0, 48);
                return nextAddress;
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
