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
    public partial class LiquidArcBlock : LiquidArcBlockBase
    {
        public LiquidArcBlock() : base()
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
        public override int SerializedSize { get { return 236; } }
        public override int Alignment { get { return 4; } }
        public LiquidArcBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            horizontalRange = new ScalarFunctionStructBlock();
            blamPointers.Concat(horizontalRange.ReadFields(binaryReader));
            verticalRange = new ScalarFunctionStructBlock();
            blamPointers.Concat(verticalRange.ReadFields(binaryReader));
            verticalNegativeScale01 = binaryReader.ReadSingle();
            roughness = new ScalarFunctionStructBlock();
            blamPointers.Concat(roughness.ReadFields(binaryReader));
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
            blamPointers.Enqueue(ReadBlockArrayPointer<LiquidCoreBlock>(binaryReader));
            rangeScale = new ScalarFunctionStructBlock();
            blamPointers.Concat(rangeScale.ReadFields(binaryReader));
            brightnessScale = new ScalarFunctionStructBlock();
            blamPointers.Concat(brightnessScale.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            horizontalRange.ReadPointers(binaryReader, blamPointers);
            verticalRange.ReadPointers(binaryReader, blamPointers);
            roughness.ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
            invalidName_2[2].ReadPointers(binaryReader, blamPointers);
            invalidName_2[3].ReadPointers(binaryReader, blamPointers);
            invalidName_2[4].ReadPointers(binaryReader, blamPointers);
            invalidName_2[5].ReadPointers(binaryReader, blamPointers);
            invalidName_2[6].ReadPointers(binaryReader, blamPointers);
            invalidName_2[7].ReadPointers(binaryReader, blamPointers);
            invalidName_2[8].ReadPointers(binaryReader, blamPointers);
            invalidName_2[9].ReadPointers(binaryReader, blamPointers);
            invalidName_2[10].ReadPointers(binaryReader, blamPointers);
            invalidName_2[11].ReadPointers(binaryReader, blamPointers);
            invalidName_2[12].ReadPointers(binaryReader, blamPointers);
            invalidName_2[13].ReadPointers(binaryReader, blamPointers);
            invalidName_2[14].ReadPointers(binaryReader, blamPointers);
            invalidName_2[15].ReadPointers(binaryReader, blamPointers);
            invalidName_2[16].ReadPointers(binaryReader, blamPointers);
            invalidName_2[17].ReadPointers(binaryReader, blamPointers);
            invalidName_2[18].ReadPointers(binaryReader, blamPointers);
            invalidName_2[19].ReadPointers(binaryReader, blamPointers);
            invalidName_2[20].ReadPointers(binaryReader, blamPointers);
            invalidName_2[21].ReadPointers(binaryReader, blamPointers);
            invalidName_2[22].ReadPointers(binaryReader, blamPointers);
            invalidName_2[23].ReadPointers(binaryReader, blamPointers);
            invalidName_2[24].ReadPointers(binaryReader, blamPointers);
            invalidName_2[25].ReadPointers(binaryReader, blamPointers);
            invalidName_2[26].ReadPointers(binaryReader, blamPointers);
            invalidName_2[27].ReadPointers(binaryReader, blamPointers);
            invalidName_2[28].ReadPointers(binaryReader, blamPointers);
            invalidName_2[29].ReadPointers(binaryReader, blamPointers);
            invalidName_2[30].ReadPointers(binaryReader, blamPointers);
            invalidName_2[31].ReadPointers(binaryReader, blamPointers);
            invalidName_2[32].ReadPointers(binaryReader, blamPointers);
            invalidName_2[33].ReadPointers(binaryReader, blamPointers);
            invalidName_2[34].ReadPointers(binaryReader, blamPointers);
            invalidName_2[35].ReadPointers(binaryReader, blamPointers);
            invalidName_2[36].ReadPointers(binaryReader, blamPointers);
            invalidName_2[37].ReadPointers(binaryReader, blamPointers);
            invalidName_2[38].ReadPointers(binaryReader, blamPointers);
            invalidName_2[39].ReadPointers(binaryReader, blamPointers);
            invalidName_2[40].ReadPointers(binaryReader, blamPointers);
            invalidName_2[41].ReadPointers(binaryReader, blamPointers);
            invalidName_2[42].ReadPointers(binaryReader, blamPointers);
            invalidName_2[43].ReadPointers(binaryReader, blamPointers);
            invalidName_2[44].ReadPointers(binaryReader, blamPointers);
            invalidName_2[45].ReadPointers(binaryReader, blamPointers);
            invalidName_2[46].ReadPointers(binaryReader, blamPointers);
            invalidName_2[47].ReadPointers(binaryReader, blamPointers);
            invalidName_2[48].ReadPointers(binaryReader, blamPointers);
            invalidName_2[49].ReadPointers(binaryReader, blamPointers);
            invalidName_2[50].ReadPointers(binaryReader, blamPointers);
            invalidName_2[51].ReadPointers(binaryReader, blamPointers);
            invalidName_2[52].ReadPointers(binaryReader, blamPointers);
            invalidName_2[53].ReadPointers(binaryReader, blamPointers);
            invalidName_2[54].ReadPointers(binaryReader, blamPointers);
            invalidName_2[55].ReadPointers(binaryReader, blamPointers);
            invalidName_2[56].ReadPointers(binaryReader, blamPointers);
            invalidName_2[57].ReadPointers(binaryReader, blamPointers);
            invalidName_2[58].ReadPointers(binaryReader, blamPointers);
            invalidName_2[59].ReadPointers(binaryReader, blamPointers);
            invalidName_2[60].ReadPointers(binaryReader, blamPointers);
            invalidName_2[61].ReadPointers(binaryReader, blamPointers);
            invalidName_2[62].ReadPointers(binaryReader, blamPointers);
            invalidName_2[63].ReadPointers(binaryReader, blamPointers);
            invalidName_3[0].ReadPointers(binaryReader, blamPointers);
            invalidName_3[1].ReadPointers(binaryReader, blamPointers);
            invalidName_3[2].ReadPointers(binaryReader, blamPointers);
            invalidName_3[3].ReadPointers(binaryReader, blamPointers);
            invalidName_3[4].ReadPointers(binaryReader, blamPointers);
            invalidName_3[5].ReadPointers(binaryReader, blamPointers);
            invalidName_3[6].ReadPointers(binaryReader, blamPointers);
            invalidName_3[7].ReadPointers(binaryReader, blamPointers);
            invalidName_3[8].ReadPointers(binaryReader, blamPointers);
            invalidName_3[9].ReadPointers(binaryReader, blamPointers);
            invalidName_3[10].ReadPointers(binaryReader, blamPointers);
            invalidName_3[11].ReadPointers(binaryReader, blamPointers);
            invalidName_3[12].ReadPointers(binaryReader, blamPointers);
            invalidName_3[13].ReadPointers(binaryReader, blamPointers);
            invalidName_3[14].ReadPointers(binaryReader, blamPointers);
            invalidName_3[15].ReadPointers(binaryReader, blamPointers);
            invalidName_3[16].ReadPointers(binaryReader, blamPointers);
            invalidName_3[17].ReadPointers(binaryReader, blamPointers);
            invalidName_3[18].ReadPointers(binaryReader, blamPointers);
            invalidName_3[19].ReadPointers(binaryReader, blamPointers);
            invalidName_3[20].ReadPointers(binaryReader, blamPointers);
            invalidName_3[21].ReadPointers(binaryReader, blamPointers);
            invalidName_3[22].ReadPointers(binaryReader, blamPointers);
            invalidName_3[23].ReadPointers(binaryReader, blamPointers);
            invalidName_3[24].ReadPointers(binaryReader, blamPointers);
            invalidName_3[25].ReadPointers(binaryReader, blamPointers);
            invalidName_3[26].ReadPointers(binaryReader, blamPointers);
            invalidName_3[27].ReadPointers(binaryReader, blamPointers);
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            cores = ReadBlockArrayData<LiquidCoreBlock>(binaryReader, blamPointers.Dequeue());
            rangeScale.ReadPointers(binaryReader, blamPointers);
            brightnessScale.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
