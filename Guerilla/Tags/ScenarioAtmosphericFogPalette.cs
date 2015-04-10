using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ScenarioAtmosphericFogPalette : ScenarioAtmosphericFogPaletteBase
    {
        public  ScenarioAtmosphericFogPalette(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 244)]
    public class ScenarioAtmosphericFogPaletteBase
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
        internal  ScenarioAtmosphericFogPaletteBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.color = binaryReader.ReadColorR8G8B8();
            this.spreadDistanceWorldUnits = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.maximumDensity01 = binaryReader.ReadSingle();
            this.startDistanceWorldUnits = binaryReader.ReadSingle();
            this.opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            this.color0 = binaryReader.ReadColorR8G8B8();
            this.invalidName_0 = binaryReader.ReadBytes(4);
            this.maximumDensity010 = binaryReader.ReadSingle();
            this.startDistanceWorldUnits0 = binaryReader.ReadSingle();
            this.opaqueDistanceWorldUnits0 = binaryReader.ReadSingle();
            this.invalidName_1 = binaryReader.ReadBytes(4);
            this.planarColor = binaryReader.ReadColorR8G8B8();
            this.planarMaxDensity01 = binaryReader.ReadSingle();
            this.planarOverrideAmount01 = binaryReader.ReadSingle();
            this.planarMinDistanceBiasWorldUnits = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(44);
            this.patchyColor = binaryReader.ReadColorR8G8B8();
            this.invalidName_3 = binaryReader.ReadBytes(12);
            this.patchyDensity01 = binaryReader.ReadVector2();
            this.patchyDistanceWorldUnits = binaryReader.ReadRange();
            this.invalidName_4 = binaryReader.ReadBytes(32);
            this.patchyFog = binaryReader.ReadTagReference();
            this.mixers = ReadScenarioAtmosphericFogMixerBlockArray(binaryReader);
            this.amount01 = binaryReader.ReadSingle();
            this.threshold01 = binaryReader.ReadSingle();
            this.brightness01 = binaryReader.ReadSingle();
            this.gammaPower = binaryReader.ReadSingle();
            this.cameraImmersionFlags = (CameraImmersionFlags)binaryReader.ReadInt16();
            this.invalidName_5 = binaryReader.ReadBytes(2);
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
        internal  virtual ScenarioAtmosphericFogMixerBlock[] ReadScenarioAtmosphericFogMixerBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(ScenarioAtmosphericFogMixerBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new ScenarioAtmosphericFogMixerBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new ScenarioAtmosphericFogMixerBlock(binaryReader);
                }
            }
            return array;
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
