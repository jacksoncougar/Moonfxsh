// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Fog = (TagClass)"fog ";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("fog ")]
    public partial class PlanarFogBlock : PlanarFogBlockBase
    {
        public  PlanarFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PlanarFogBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class PlanarFogBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 96; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PlanarFogBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            priority = binaryReader.ReadInt16();
            globalMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            maximumDensity01 = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            opaqueDepthWorldUnits = binaryReader.ReadSingle();
            atmosphericPlanarDepthWorldUnits = binaryReader.ReadRange();
            eyeOffsetScale11 = binaryReader.ReadSingle();
            color = binaryReader.ReadColorR8G8B8();
            patchyFog = Guerilla.ReadBlockArray<PlanarFogPatchyFogBlock>(binaryReader);
            backgroundSound = binaryReader.ReadTagReference();
            soundEnvironment = binaryReader.ReadTagReference();
            environmentDampingFactor = binaryReader.ReadSingle();
            backgroundSoundGain = binaryReader.ReadSingle();
            enterSound = binaryReader.ReadTagReference();
            exitSound = binaryReader.ReadTagReference();
        }
        public  PlanarFogBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            priority = binaryReader.ReadInt16();
            globalMaterialName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            maximumDensity01 = binaryReader.ReadSingle();
            opaqueDistanceWorldUnits = binaryReader.ReadSingle();
            opaqueDepthWorldUnits = binaryReader.ReadSingle();
            atmosphericPlanarDepthWorldUnits = binaryReader.ReadRange();
            eyeOffsetScale11 = binaryReader.ReadSingle();
            color = binaryReader.ReadColorR8G8B8();
            patchyFog = Guerilla.ReadBlockArray<PlanarFogPatchyFogBlock>(binaryReader);
            backgroundSound = binaryReader.ReadTagReference();
            soundEnvironment = binaryReader.ReadTagReference();
            environmentDampingFactor = binaryReader.ReadSingle();
            backgroundSoundGain = binaryReader.ReadSingle();
            enterSound = binaryReader.ReadTagReference();
            exitSound = binaryReader.ReadTagReference();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(priority);
                binaryWriter.Write(globalMaterialName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(maximumDensity01);
                binaryWriter.Write(opaqueDistanceWorldUnits);
                binaryWriter.Write(opaqueDepthWorldUnits);
                binaryWriter.Write(atmosphericPlanarDepthWorldUnits);
                binaryWriter.Write(eyeOffsetScale11);
                binaryWriter.Write(color);
                nextAddress = Guerilla.WriteBlockArray<PlanarFogPatchyFogBlock>(binaryWriter, patchyFog, nextAddress);
                binaryWriter.Write(backgroundSound);
                binaryWriter.Write(soundEnvironment);
                binaryWriter.Write(environmentDampingFactor);
                binaryWriter.Write(backgroundSoundGain);
                binaryWriter.Write(enterSound);
                binaryWriter.Write(exitSound);
                return nextAddress;
            }
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
