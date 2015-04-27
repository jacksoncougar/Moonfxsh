// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ScenarioAtmosphericFogPalette : ScenarioAtmosphericFogPaletteBase
    {
        public  ScenarioAtmosphericFogPalette(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ScenarioAtmosphericFogPalette(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 244, Alignment = 4)]
    public class ScenarioAtmosphericFogPaletteBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ColorR8G8B8 color;
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
        internal Moonfish.Tags.ColorR8G8B8 color0;
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
        internal Moonfish.Tags.ColorR8G8B8 planarColor;
        internal float planarMaxDensity01;
        internal float planarOverrideAmount01;
        /// <summary>
        /// Don't ask.
        /// </summary>
        internal float planarMinDistanceBiasWorldUnits;
        internal byte[] invalidName_2;
        internal Moonfish.Tags.ColorR8G8B8 patchyColor;
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
        
        public override int SerializedSize{get { return 244; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ScenarioAtmosphericFogPaletteBase(BinaryReader binaryReader): base(binaryReader)
        {
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
            mixers = Guerilla.ReadBlockArray<ScenarioAtmosphericFogMixerBlock>(binaryReader);
            amount01 = binaryReader.ReadSingle();
            threshold01 = binaryReader.ReadSingle();
            brightness01 = binaryReader.ReadSingle();
            gammaPower = binaryReader.ReadSingle();
            cameraImmersionFlags = (CameraImmersionFlags)binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(2);
        }
        public  ScenarioAtmosphericFogPaletteBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
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
            mixers = Guerilla.ReadBlockArray<ScenarioAtmosphericFogMixerBlock>(binaryReader);
            amount01 = binaryReader.ReadSingle();
            threshold01 = binaryReader.ReadSingle();
            brightness01 = binaryReader.ReadSingle();
            gammaPower = binaryReader.ReadSingle();
            cameraImmersionFlags = (CameraImmersionFlags)binaryReader.ReadInt16();
            invalidName_5 = binaryReader.ReadBytes(2);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
