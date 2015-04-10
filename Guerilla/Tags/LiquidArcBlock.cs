using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LiquidArcBlock : LiquidArcBlockBase
    {
        public  LiquidArcBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 236)]
    public class LiquidArcBlockBase
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
        internal  LiquidArcBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.spriteCount = (SpriteCount)binaryReader.ReadInt16();
            this.naturalLengthWorldUnits = binaryReader.ReadSingle();
            this.instances = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.instanceSpreadAngleDegrees = binaryReader.ReadSingle();
            this.instanceRotationPeriodSeconds = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(8);
            this.materialEffects = binaryReader.ReadTagReference();
            this.bitmap = binaryReader.ReadTagReference();
            this.invalidName_1 = binaryReader.ReadBytes(8);
            this.horizontalRange = new ScalarFunctionStructBlock(binaryReader);
            this.verticalRange = new ScalarFunctionStructBlock(binaryReader);
            this.verticalNegativeScale01 = binaryReader.ReadSingle();
            this.roughness = new ScalarFunctionStructBlock(binaryReader);
            this.invalidName_2 = binaryReader.ReadBytes(64);
            this.octave1FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave2FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave3FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave4FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave5FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave6FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave7FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave8FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.octave9FrequencyCyclesSecond = binaryReader.ReadSingle();
            this.invalidName_3 = binaryReader.ReadBytes(28);
            this.octaveFlags = (OctaveFlags)binaryReader.ReadInt16();
            this.invalidName_4 = binaryReader.ReadBytes(2);
            this.cores = ReadLiquidCoreBlockArray(binaryReader);
            this.rangeScale = new ScalarFunctionStructBlock(binaryReader);
            this.brightnessScale = new ScalarFunctionStructBlock(binaryReader);
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
        internal  virtual LiquidCoreBlock[] ReadLiquidCoreBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(LiquidCoreBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new LiquidCoreBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new LiquidCoreBlock(binaryReader);
                }
            }
            return array;
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
