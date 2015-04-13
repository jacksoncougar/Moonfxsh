using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("fog ")]
    public  partial class PlanarFogBlock : PlanarFogBlockBase
    {
        public  PlanarFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class PlanarFogBlockBase
    {
        internal Flags flags;
        internal short priority;
        internal Moonfish.Tags.StringID globalMaterialName;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        /// <summary>
        /// planar fog density is clamped to this value
        /// </summary>
        internal float maximumDensity01;
        /// <summary>
        /// the fog becomes opaque (maximum density) at this distance from the viewer
        /// </summary>
        internal float opaqueDistanceWorldUnits;
        /// <summary>
        /// the fog becomes opaque at this distance below fog plane
        /// </summary>
        internal float opaqueDepthWorldUnits;
        /// <summary>
        /// distances above fog plane where atmospheric fog supercedes planar fog and visa-versa
        /// </summary>
        internal Moonfish.Model.Range atmosphericPlanarDepthWorldUnits;
        /// <summary>
        /// negative numbers are bad, mmmkay?
        /// </summary>
        internal float eyeOffsetScale11;
        internal Moonfish.Tags.ColorR8G8B8 color;
        internal PlanarFogPatchyFogBlock[] patchyFog;
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference backgroundSound;
        [TagReference("snde")]
        internal Moonfish.Tags.TagReference soundEnvironment;
        /// <summary>
        /// scales the surrounding background sound by this much
        /// </summary>
        internal float environmentDampingFactor;
        /// <summary>
        /// scale for fog background sound
        /// </summary>
        internal float backgroundSoundGain;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference enterSound;
        [TagReference("snd!")]
        internal Moonfish.Tags.TagReference exitSound;
        internal  PlanarFogBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.priority = binaryReader.ReadInt16();
            this.globalMaterialName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.maximumDensity01 = binaryReader.ReadSingle();
            this.opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            this.opaqueDepthWorldUnits = binaryReader.ReadSingle();
            this.atmosphericPlanarDepthWorldUnits = binaryReader.ReadRange();
            this.eyeOffsetScale11 = binaryReader.ReadSingle();
            this.color = binaryReader.ReadColorR8G8B8();
            this.patchyFog = ReadPlanarFogPatchyFogBlockArray(binaryReader);
            this.backgroundSound = binaryReader.ReadTagReference();
            this.soundEnvironment = binaryReader.ReadTagReference();
            this.environmentDampingFactor = binaryReader.ReadSingle();
            this.backgroundSoundGain = binaryReader.ReadSingle();
            this.enterSound = binaryReader.ReadTagReference();
            this.exitSound = binaryReader.ReadTagReference();
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
        internal  virtual PlanarFogPatchyFogBlock[] ReadPlanarFogPatchyFogBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(PlanarFogPatchyFogBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new PlanarFogPatchyFogBlock[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new PlanarFogPatchyFogBlock(binaryReader);
                }
            }
            return array;
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            RenderOnlySubmergedGeometry = 1,
            ExtendInfinitelyWhileVisible = 2,
            DontFloodfill = 4,
            AggressiveFloodfill = 8,
            DoNotRender = 16,
            DoNotRenderUnlessSubmerged = 32,
        };
    };
}
