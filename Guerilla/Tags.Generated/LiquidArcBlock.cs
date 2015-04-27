// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class LiquidArcBlock : LiquidArcBlockBase
    {
        public  LiquidArcBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  LiquidArcBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 236, Alignment = 4)]
    public class LiquidArcBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal SpriteCount spriteCount;
        internal float naturalLengthWorldUnits;
        internal short instances;
        internal byte[] invalidName_;
        internal float instanceSpreadAngleDegrees;
        internal float instanceRotationPeriodSeconds;
        internal byte[] invalidName_0;
        [TagReference("foot")]
        internal Moonfish.Tags.TagReference materialEffects;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        internal byte[] invalidName_1;
        internal ScalarFunctionStructBlock horizontalRange;
        internal ScalarFunctionStructBlock verticalRange;
        internal float verticalNegativeScale01;
        internal ScalarFunctionStructBlock roughness;
        internal byte[] invalidName_2;
        internal float octave1FrequencyCyclesSecond;
        internal float octave2FrequencyCyclesSecond;
        internal float octave3FrequencyCyclesSecond;
        internal float octave4FrequencyCyclesSecond;
        internal float octave5FrequencyCyclesSecond;
        internal float octave6FrequencyCyclesSecond;
        internal float octave7FrequencyCyclesSecond;
        internal float octave8FrequencyCyclesSecond;
        internal float octave9FrequencyCyclesSecond;
        internal byte[] invalidName_3;
        internal OctaveFlags octaveFlags;
        internal byte[] invalidName_4;
        internal LiquidCoreBlock[] cores;
        internal ScalarFunctionStructBlock rangeScale;
        internal ScalarFunctionStructBlock brightnessScale;
        
        public override int SerializedSize{get { return 236; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  LiquidArcBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            spriteCount = (SpriteCount)binaryReader.ReadInt16();
            naturalLengthWorldUnits = binaryReader.ReadSingle();
            instances = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            instanceSpreadAngleDegrees = binaryReader.ReadSingle();
            instanceRotationPeriodSeconds = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
            materialEffects = binaryReader.ReadTagReference();
            bitmap = binaryReader.ReadTagReference();
            invalidName_1 = binaryReader.ReadBytes(8);
            horizontalRange = new ScalarFunctionStructBlock(binaryReader);
            verticalRange = new ScalarFunctionStructBlock(binaryReader);
            verticalNegativeScale01 = binaryReader.ReadSingle();
            roughness = new ScalarFunctionStructBlock(binaryReader);
            invalidName_2 = binaryReader.ReadBytes(64);
            octave1FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave2FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave3FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave4FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave5FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave6FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave7FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave8FrequencyCyclesSecond = binaryReader.ReadSingle();
            octave9FrequencyCyclesSecond = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(28);
            octaveFlags = (OctaveFlags)binaryReader.ReadInt16();
            invalidName_4 = binaryReader.ReadBytes(2);
            cores = Guerilla.ReadBlockArray<LiquidCoreBlock>(binaryReader);
            rangeScale = new ScalarFunctionStructBlock(binaryReader);
            brightnessScale = new ScalarFunctionStructBlock(binaryReader);
        }
        public  LiquidArcBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write((Int16)spriteCount);
                binaryWriter.Write(naturalLengthWorldUnits);
                binaryWriter.Write(instances);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(instanceSpreadAngleDegrees);
                binaryWriter.Write(instanceRotationPeriodSeconds);
                binaryWriter.Write(invalidName_0, 0, 8);
                binaryWriter.Write(materialEffects);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(invalidName_1, 0, 8);
                horizontalRange.Write(binaryWriter);
                verticalRange.Write(binaryWriter);
                binaryWriter.Write(verticalNegativeScale01);
                roughness.Write(binaryWriter);
                binaryWriter.Write(invalidName_2, 0, 64);
                binaryWriter.Write(octave1FrequencyCyclesSecond);
                binaryWriter.Write(octave2FrequencyCyclesSecond);
                binaryWriter.Write(octave3FrequencyCyclesSecond);
                binaryWriter.Write(octave4FrequencyCyclesSecond);
                binaryWriter.Write(octave5FrequencyCyclesSecond);
                binaryWriter.Write(octave6FrequencyCyclesSecond);
                binaryWriter.Write(octave7FrequencyCyclesSecond);
                binaryWriter.Write(octave8FrequencyCyclesSecond);
                binaryWriter.Write(octave9FrequencyCyclesSecond);
                binaryWriter.Write(invalidName_3, 0, 28);
                binaryWriter.Write((Int16)octaveFlags);
                binaryWriter.Write(invalidName_4, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<LiquidCoreBlock>(binaryWriter, cores, nextAddress);
                rangeScale.Write(binaryWriter);
                brightnessScale.Write(binaryWriter);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            BasisMarkerRelative = 1,
            SpreadByExternalInput = 2,
            CollideWithStuff = 4,
            NoPerspectiveMidpoints = 8,
        };
        internal enum SpriteCount : short
        {
            InvalidName4Sprites = 0,
            InvalidName8Sprites = 1,
            InvalidName16Sprites = 2,
            InvalidName32Sprites = 3,
            InvalidName64Sprites = 4,
            InvalidName128Sprites = 5,
            InvalidName256Sprites = 6,
        };
        [FlagsAttribute]
        internal enum OctaveFlags : short
        {
            Octave1 = 1,
            Octave2 = 2,
            Octave3 = 4,
            Octave4 = 8,
            Octave5 = 16,
            Octave6 = 32,
            Octave7 = 64,
            Octave8 = 128,
            Octave9 = 256,
        };
    };
}
