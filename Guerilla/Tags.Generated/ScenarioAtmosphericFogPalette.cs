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
    public partial class ScenarioAtmosphericFogPalette : ScenarioAtmosphericFogPaletteBase
    {
        public ScenarioAtmosphericFogPalette() : base()
        {
        }
    };
    [LayoutAttribute(Size = 244, Alignment = 4)]
    public class ScenarioAtmosphericFogPaletteBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Moonfish.Tags.ColourR8G8B8 color;
        /// <summary>
        /// How far fog spreads into adjacent clusters: 0 defaults to 1.
        /// </summary>
        internal float spreadDistanceWorldUnits;
        internal byte[] invalidName_;
        /// <summary>
        /// Fog density clamps to this value.
        /// </summary>
        internal float maximumDensity01;
        /// <summary>
        /// Before this distance, there is no fog.
        /// </summary>
        internal float startDistanceWorldUnits;
        /// <summary>
        /// Fog becomes opaque (maximum density) at this distance from viewer.
        /// </summary>
        internal float opaqueDistanceWorldUnits;
        internal Moonfish.Tags.ColourR8G8B8 color0;
        internal byte[] invalidName_0;
        /// <summary>
        /// Fog density clamps to this value.
        /// </summary>
        internal float maximumDensity010;
        /// <summary>
        /// Before this distance, there is no fog.
        /// </summary>
        internal float startDistanceWorldUnits0;
        /// <summary>
        /// Fog becomes opaque (maximum density) at this distance from viewer.
        /// </summary>
        internal float opaqueDistanceWorldUnits0;
        internal byte[] invalidName_1;
        internal Moonfish.Tags.ColourR8G8B8 planarColor;
        internal float planarMaxDensity01;
        internal float planarOverrideAmount01;
        /// <summary>
        /// Don't ask.
        /// </summary>
        internal float planarMinDistanceBiasWorldUnits;
        internal byte[] invalidName_2;
        internal Moonfish.Tags.ColourR8G8B8 patchyColor;
        internal byte[] invalidName_3;
        internal OpenTK.Vector2 patchyDensity01;
        internal Moonfish.Model.Range patchyDistanceWorldUnits;
        internal byte[] invalidName_4;
        [TagReference("fpch")]
        internal Moonfish.Tags.TagReference patchyFog;
        internal ScenarioAtmosphericFogMixerBlock[] mixers;
        internal float amount01;
        internal float threshold01;
        internal float brightness01;
        internal float gammaPower;
        internal CameraImmersionFlags cameraImmersionFlags;
        internal byte[] invalidName_5;
        public override int SerializedSize { get { return 244; } }
        public override int Alignment { get { return 4; } }
        public ScenarioAtmosphericFogPaletteBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            color = binaryReader.ReadColorR8G8B8();
            spreadDistanceWorldUnits = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(4);
            maximumDensity01 = binaryReader.ReadSingle();
            startDistanceWorldUnits = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            color0 = binaryReader.ReadColorR8G8B8();
            invalidName_0 = binaryReader.ReadBytes(4);
            maximumDensity010 = binaryReader.ReadSingle();
            startDistanceWorldUnits0 = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits0 = binaryReader.ReadSingle();
            invalidName_1 = binaryReader.ReadBytes(4);
            planarColor = binaryReader.ReadColorR8G8B8();
            planarMaxDensity01 = binaryReader.ReadSingle();
            planarOverrideAmount01 = binaryReader.ReadSingle();
            planarMinDistanceBiasWorldUnits = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(44);
            patchyColor = binaryReader.ReadColorR8G8B8();
            invalidName_3 = binaryReader.ReadBytes(12);
            patchyDensity01 = binaryReader.ReadVector2();
            patchyDistanceWorldUnits = binaryReader.ReadRange();
            invalidName_4 = binaryReader.ReadBytes(32);
            patchyFog = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<ScenarioAtmosphericFogMixerBlock>(binaryReader));
            amount01 = binaryReader.ReadSingle();
            threshold01 = binaryReader.ReadSingle();
            brightness01 = binaryReader.ReadSingle();
            gammaPower = binaryReader.ReadSingle();
            cameraImmersionFlags = (CameraImmersionFlags)binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_1[0].ReadPointers(binaryReader, blamPointers);
            invalidName_1[1].ReadPointers(binaryReader, blamPointers);
            invalidName_1[2].ReadPointers(binaryReader, blamPointers);
            invalidName_1[3].ReadPointers(binaryReader, blamPointers);
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
            invalidName_4[0].ReadPointers(binaryReader, blamPointers);
            invalidName_4[1].ReadPointers(binaryReader, blamPointers);
            invalidName_4[2].ReadPointers(binaryReader, blamPointers);
            invalidName_4[3].ReadPointers(binaryReader, blamPointers);
            invalidName_4[4].ReadPointers(binaryReader, blamPointers);
            invalidName_4[5].ReadPointers(binaryReader, blamPointers);
            invalidName_4[6].ReadPointers(binaryReader, blamPointers);
            invalidName_4[7].ReadPointers(binaryReader, blamPointers);
            invalidName_4[8].ReadPointers(binaryReader, blamPointers);
            invalidName_4[9].ReadPointers(binaryReader, blamPointers);
            invalidName_4[10].ReadPointers(binaryReader, blamPointers);
            invalidName_4[11].ReadPointers(binaryReader, blamPointers);
            invalidName_4[12].ReadPointers(binaryReader, blamPointers);
            invalidName_4[13].ReadPointers(binaryReader, blamPointers);
            invalidName_4[14].ReadPointers(binaryReader, blamPointers);
            invalidName_4[15].ReadPointers(binaryReader, blamPointers);
            invalidName_4[16].ReadPointers(binaryReader, blamPointers);
            invalidName_4[17].ReadPointers(binaryReader, blamPointers);
            invalidName_4[18].ReadPointers(binaryReader, blamPointers);
            invalidName_4[19].ReadPointers(binaryReader, blamPointers);
            invalidName_4[20].ReadPointers(binaryReader, blamPointers);
            invalidName_4[21].ReadPointers(binaryReader, blamPointers);
            invalidName_4[22].ReadPointers(binaryReader, blamPointers);
            invalidName_4[23].ReadPointers(binaryReader, blamPointers);
            invalidName_4[24].ReadPointers(binaryReader, blamPointers);
            invalidName_4[25].ReadPointers(binaryReader, blamPointers);
            invalidName_4[26].ReadPointers(binaryReader, blamPointers);
            invalidName_4[27].ReadPointers(binaryReader, blamPointers);
            invalidName_4[28].ReadPointers(binaryReader, blamPointers);
            invalidName_4[29].ReadPointers(binaryReader, blamPointers);
            invalidName_4[30].ReadPointers(binaryReader, blamPointers);
            invalidName_4[31].ReadPointers(binaryReader, blamPointers);
            mixers = ReadBlockArrayData<ScenarioAtmosphericFogMixerBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_5[0].ReadPointers(binaryReader, blamPointers);
            invalidName_5[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(color);
                binaryWriter.Write(spreadDistanceWorldUnits);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(maximumDensity01);
                binaryWriter.Write(startDistanceWorldUnits);
                binaryWriter.Write(opaqueDistanceWorldUnits);
                binaryWriter.Write(color0);
                binaryWriter.Write(invalidName_0, 0, 4);
                binaryWriter.Write(maximumDensity010);
                binaryWriter.Write(startDistanceWorldUnits0);
                binaryWriter.Write(opaqueDistanceWorldUnits0);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(planarColor);
                binaryWriter.Write(planarMaxDensity01);
                binaryWriter.Write(planarOverrideAmount01);
                binaryWriter.Write(planarMinDistanceBiasWorldUnits);
                binaryWriter.Write(invalidName_2, 0, 44);
                binaryWriter.Write(patchyColor);
                binaryWriter.Write(invalidName_3, 0, 12);
                binaryWriter.Write(patchyDensity01);
                binaryWriter.Write(patchyDistanceWorldUnits);
                binaryWriter.Write(invalidName_4, 0, 32);
                binaryWriter.Write(patchyFog);
                nextAddress = Guerilla.WriteBlockArray<ScenarioAtmosphericFogMixerBlock>(binaryWriter, mixers, nextAddress);
                binaryWriter.Write(amount01);
                binaryWriter.Write(threshold01);
                binaryWriter.Write(brightness01);
                binaryWriter.Write(gammaPower);
                binaryWriter.Write((Int16)cameraImmersionFlags);
                binaryWriter.Write(invalidName_5, 0, 2);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum CameraImmersionFlags : short
        {
            DisableAtmosphericFog = 1,
            DisableSecondaryFog = 2,
            DisablePlanarFog = 4,
            InvertPlanarFogPriorities = 8,
            DisableWater = 16,
        };
    };
}
