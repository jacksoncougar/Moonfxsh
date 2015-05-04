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
    public partial class GlobalHudMultitextureOverlayEffectorDefinition : GlobalHudMultitextureOverlayEffectorDefinitionBase
    {
        public GlobalHudMultitextureOverlayEffectorDefinition() : base()
        {
        }
    };
    [LayoutAttribute(Size = 220, Alignment = 4)]
    public class GlobalHudMultitextureOverlayEffectorDefinitionBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal DestinationType destinationType;
        internal Destination destination;
        internal Source source;
        internal byte[] invalidName_0;
        internal Moonfish.Model.Range inBoundsSourceUnits;
        internal Moonfish.Model.Range outBoundsPixels;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ColourR8G8B8 tintColorLowerBound;
        internal Moonfish.Tags.ColourR8G8B8 tintColorUpperBound;
        internal PeriodicFunction periodicFunction;
        internal byte[] invalidName_2;
        internal float functionPeriodSeconds;
        internal float functionPhaseSeconds;
        internal byte[] invalidName_3;
        public override int SerializedSize { get { return 220; } }
        public override int Alignment { get { return 4; } }
        public GlobalHudMultitextureOverlayEffectorDefinitionBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(64);
            destinationType = (DestinationType)binaryReader.ReadInt16();
            destination = (Destination)binaryReader.ReadInt16();
            source = (Source)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            inBoundsSourceUnits = binaryReader.ReadRange();
            outBoundsPixels = binaryReader.ReadRange();
            invalidName_1 = binaryReader.ReadBytes(64);
            tintColorLowerBound = binaryReader.ReadColorR8G8B8();
            tintColorUpperBound = binaryReader.ReadColorR8G8B8();
            periodicFunction = (PeriodicFunction)binaryReader.ReadInt16();
            invalidName_2 = binaryReader.ReadBytes(2);
            functionPeriodSeconds = binaryReader.ReadSingle();
            functionPhaseSeconds = binaryReader.ReadSingle();
            invalidName_3 = binaryReader.ReadBytes(32);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_[4].ReadPointers(binaryReader, blamPointers);
            invalidName_[5].ReadPointers(binaryReader, blamPointers);
            invalidName_[6].ReadPointers(binaryReader, blamPointers);
            invalidName_[7].ReadPointers(binaryReader, blamPointers);
            invalidName_[8].ReadPointers(binaryReader, blamPointers);
            invalidName_[9].ReadPointers(binaryReader, blamPointers);
            invalidName_[10].ReadPointers(binaryReader, blamPointers);
            invalidName_[11].ReadPointers(binaryReader, blamPointers);
            invalidName_[12].ReadPointers(binaryReader, blamPointers);
            invalidName_[13].ReadPointers(binaryReader, blamPointers);
            invalidName_[14].ReadPointers(binaryReader, blamPointers);
            invalidName_[15].ReadPointers(binaryReader, blamPointers);
            invalidName_[16].ReadPointers(binaryReader, blamPointers);
            invalidName_[17].ReadPointers(binaryReader, blamPointers);
            invalidName_[18].ReadPointers(binaryReader, blamPointers);
            invalidName_[19].ReadPointers(binaryReader, blamPointers);
            invalidName_[20].ReadPointers(binaryReader, blamPointers);
            invalidName_[21].ReadPointers(binaryReader, blamPointers);
            invalidName_[22].ReadPointers(binaryReader, blamPointers);
            invalidName_[23].ReadPointers(binaryReader, blamPointers);
            invalidName_[24].ReadPointers(binaryReader, blamPointers);
            invalidName_[25].ReadPointers(binaryReader, blamPointers);
            invalidName_[26].ReadPointers(binaryReader, blamPointers);
            invalidName_[27].ReadPointers(binaryReader, blamPointers);
            invalidName_[28].ReadPointers(binaryReader, blamPointers);
            invalidName_[29].ReadPointers(binaryReader, blamPointers);
            invalidName_[30].ReadPointers(binaryReader, blamPointers);
            invalidName_[31].ReadPointers(binaryReader, blamPointers);
            invalidName_[32].ReadPointers(binaryReader, blamPointers);
            invalidName_[33].ReadPointers(binaryReader, blamPointers);
            invalidName_[34].ReadPointers(binaryReader, blamPointers);
            invalidName_[35].ReadPointers(binaryReader, blamPointers);
            invalidName_[36].ReadPointers(binaryReader, blamPointers);
            invalidName_[37].ReadPointers(binaryReader, blamPointers);
            invalidName_[38].ReadPointers(binaryReader, blamPointers);
            invalidName_[39].ReadPointers(binaryReader, blamPointers);
            invalidName_[40].ReadPointers(binaryReader, blamPointers);
            invalidName_[41].ReadPointers(binaryReader, blamPointers);
            invalidName_[42].ReadPointers(binaryReader, blamPointers);
            invalidName_[43].ReadPointers(binaryReader, blamPointers);
            invalidName_[44].ReadPointers(binaryReader, blamPointers);
            invalidName_[45].ReadPointers(binaryReader, blamPointers);
            invalidName_[46].ReadPointers(binaryReader, blamPointers);
            invalidName_[47].ReadPointers(binaryReader, blamPointers);
            invalidName_[48].ReadPointers(binaryReader, blamPointers);
            invalidName_[49].ReadPointers(binaryReader, blamPointers);
            invalidName_[50].ReadPointers(binaryReader, blamPointers);
            invalidName_[51].ReadPointers(binaryReader, blamPointers);
            invalidName_[52].ReadPointers(binaryReader, blamPointers);
            invalidName_[53].ReadPointers(binaryReader, blamPointers);
            invalidName_[54].ReadPointers(binaryReader, blamPointers);
            invalidName_[55].ReadPointers(binaryReader, blamPointers);
            invalidName_[56].ReadPointers(binaryReader, blamPointers);
            invalidName_[57].ReadPointers(binaryReader, blamPointers);
            invalidName_[58].ReadPointers(binaryReader, blamPointers);
            invalidName_[59].ReadPointers(binaryReader, blamPointers);
            invalidName_[60].ReadPointers(binaryReader, blamPointers);
            invalidName_[61].ReadPointers(binaryReader, blamPointers);
            invalidName_[62].ReadPointers(binaryReader, blamPointers);
            invalidName_[63].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[4].ReadPointers(binaryReader, blamPointers);
            invalidName_1[5].ReadPointers(binaryReader, blamPointers);
            invalidName_1[6].ReadPointers(binaryReader, blamPointers);
            invalidName_1[7].ReadPointers(binaryReader, blamPointers);
            invalidName_1[8].ReadPointers(binaryReader, blamPointers);
            invalidName_1[9].ReadPointers(binaryReader, blamPointers);
            invalidName_1[10].ReadPointers(binaryReader, blamPointers);
            invalidName_1[11].ReadPointers(binaryReader, blamPointers);
            invalidName_1[12].ReadPointers(binaryReader, blamPointers);
            invalidName_1[13].ReadPointers(binaryReader, blamPointers);
            invalidName_1[14].ReadPointers(binaryReader, blamPointers);
            invalidName_1[15].ReadPointers(binaryReader, blamPointers);
            invalidName_1[16].ReadPointers(binaryReader, blamPointers);
            invalidName_1[17].ReadPointers(binaryReader, blamPointers);
            invalidName_1[18].ReadPointers(binaryReader, blamPointers);
            invalidName_1[19].ReadPointers(binaryReader, blamPointers);
            invalidName_1[20].ReadPointers(binaryReader, blamPointers);
            invalidName_1[21].ReadPointers(binaryReader, blamPointers);
            invalidName_1[22].ReadPointers(binaryReader, blamPointers);
            invalidName_1[23].ReadPointers(binaryReader, blamPointers);
            invalidName_1[24].ReadPointers(binaryReader, blamPointers);
            invalidName_1[25].ReadPointers(binaryReader, blamPointers);
            invalidName_1[26].ReadPointers(binaryReader, blamPointers);
            invalidName_1[27].ReadPointers(binaryReader, blamPointers);
            invalidName_1[28].ReadPointers(binaryReader, blamPointers);
            invalidName_1[29].ReadPointers(binaryReader, blamPointers);
            invalidName_1[30].ReadPointers(binaryReader, blamPointers);
            invalidName_1[31].ReadPointers(binaryReader, blamPointers);
            invalidName_1[32].ReadPointers(binaryReader, blamPointers);
            invalidName_1[33].ReadPointers(binaryReader, blamPointers);
            invalidName_1[34].ReadPointers(binaryReader, blamPointers);
            invalidName_1[35].ReadPointers(binaryReader, blamPointers);
            invalidName_1[36].ReadPointers(binaryReader, blamPointers);
            invalidName_1[37].ReadPointers(binaryReader, blamPointers);
            invalidName_1[38].ReadPointers(binaryReader, blamPointers);
            invalidName_1[39].ReadPointers(binaryReader, blamPointers);
            invalidName_1[40].ReadPointers(binaryReader, blamPointers);
            invalidName_1[41].ReadPointers(binaryReader, blamPointers);
            invalidName_1[42].ReadPointers(binaryReader, blamPointers);
            invalidName_1[43].ReadPointers(binaryReader, blamPointers);
            invalidName_1[44].ReadPointers(binaryReader, blamPointers);
            invalidName_1[45].ReadPointers(binaryReader, blamPointers);
            invalidName_1[46].ReadPointers(binaryReader, blamPointers);
            invalidName_1[47].ReadPointers(binaryReader, blamPointers);
            invalidName_1[48].ReadPointers(binaryReader, blamPointers);
            invalidName_1[49].ReadPointers(binaryReader, blamPointers);
            invalidName_1[50].ReadPointers(binaryReader, blamPointers);
            invalidName_1[51].ReadPointers(binaryReader, blamPointers);
            invalidName_1[52].ReadPointers(binaryReader, blamPointers);
            invalidName_1[53].ReadPointers(binaryReader, blamPointers);
            invalidName_1[54].ReadPointers(binaryReader, blamPointers);
            invalidName_1[55].ReadPointers(binaryReader, blamPointers);
            invalidName_1[56].ReadPointers(binaryReader, blamPointers);
            invalidName_1[57].ReadPointers(binaryReader, blamPointers);
            invalidName_1[58].ReadPointers(binaryReader, blamPointers);
            invalidName_1[59].ReadPointers(binaryReader, blamPointers);
            invalidName_1[60].ReadPointers(binaryReader, blamPointers);
            invalidName_1[61].ReadPointers(binaryReader, blamPointers);
            invalidName_1[62].ReadPointers(binaryReader, blamPointers);
            invalidName_1[63].ReadPointers(binaryReader, blamPointers);
            invalidName_2[0].ReadPointers(binaryReader, blamPointers);
            invalidName_2[1].ReadPointers(binaryReader, blamPointers);
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
            invalidName_3[28].ReadPointers(binaryReader, blamPointers);
            invalidName_3[29].ReadPointers(binaryReader, blamPointers);
            invalidName_3[30].ReadPointers(binaryReader, blamPointers);
            invalidName_3[31].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 64);
                binaryWriter.Write((Int16)destinationType);
                binaryWriter.Write((Int16)destination);
                binaryWriter.Write((Int16)source);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(inBoundsSourceUnits);
                binaryWriter.Write(outBoundsPixels);
                binaryWriter.Write(invalidName_1, 0, 64);
                binaryWriter.Write(tintColorLowerBound);
                binaryWriter.Write(tintColorUpperBound);
                binaryWriter.Write((Int16)periodicFunction);
                binaryWriter.Write(invalidName_2, 0, 2);
                binaryWriter.Write(functionPeriodSeconds);
                binaryWriter.Write(functionPhaseSeconds);
                binaryWriter.Write(invalidName_3, 0, 32);
                return nextAddress;
            }
        }
        internal enum DestinationType : short
        {
            Tint01 = 0,
            HorizontalOffset = 1,
            VerticalOffset = 2,
            Fade01 = 3,
        };
        internal enum Destination : short
        {
            GeometryOffset = 0,
            PrimaryMap = 1,
            SecondaryMap = 2,
            TertiaryMap = 3,
        };
        internal enum Source : short
        {
            PlayerPitch = 0,
            PlayerPitchTangent = 1,
            PlayerYaw = 2,
            WeaponRoundsLoaded = 3,
            WeaponRoundsInventory = 4,
            WeaponHeat = 5,
            ExplicitUsesLowBound = 6,
            WeaponZoomLevel = 7,
        };
        internal enum PeriodicFunction : short
        {
            One = 0,
            Zero = 1,
            Cosine = 2,
            CosineVariablePeriod = 3,
            DiagonalWave = 4,
            DiagonalWaveVariablePeriod = 5,
            Slide = 6,
            SlideVariablePeriod = 7,
            Noise = 8,
            Jitter = 9,
            Wander = 10,
            Spark = 11,
        };
    };
}
