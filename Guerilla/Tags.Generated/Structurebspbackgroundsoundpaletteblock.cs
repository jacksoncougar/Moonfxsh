// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspBackgroundSoundPaletteBlock : StructureBspBackgroundSoundPaletteBlockBase
    {
        public  StructureBspBackgroundSoundPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspBackgroundSoundPaletteBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 100, Alignment = 4)]
    public class StructureBspBackgroundSoundPaletteBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference backgroundSound;
        /// <summary>
        /// Play only when player is inside cluster.
        /// </summary>
        [TagReference("lsnd")]
        internal Moonfish.Tags.TagReference insideClusterSound;
        internal byte[] invalidName_;
        internal float cutoffDistance;
        internal ScaleFlags scaleFlags;
        internal float interiorScale;
        internal float portalScale;
        internal float exteriorScale;
        internal float interpolationSpeed1Sec;
        internal byte[] invalidName_0;
        
        public override int SerializedSize{get { return 100; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspBackgroundSoundPaletteBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            backgroundSound = binaryReader.ReadTagReference();
            insideClusterSound = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(20);
            cutoffDistance = binaryReader.ReadSingle();
            scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
            interiorScale = binaryReader.ReadSingle();
            portalScale = binaryReader.ReadSingle();
            exteriorScale = binaryReader.ReadSingle();
            interpolationSpeed1Sec = binaryReader.ReadSingle();
            invalidName_0 = binaryReader.ReadBytes(8);
        }
        public  StructureBspBackgroundSoundPaletteBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(backgroundSound);
                binaryWriter.Write(insideClusterSound);
                binaryWriter.Write(invalidName_, 0, 20);
                binaryWriter.Write(cutoffDistance);
                binaryWriter.Write((Int32)scaleFlags);
                binaryWriter.Write(interiorScale);
                binaryWriter.Write(portalScale);
                binaryWriter.Write(exteriorScale);
                binaryWriter.Write(interpolationSpeed1Sec);
                binaryWriter.Write(invalidName_0, 0, 8);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ScaleFlags : int
        {
            OverrideDefaultScale = 1,
            UseAdjacentClusterAsPortalScale = 2,
            UseAdjacentClusterAsExteriorScale = 4,
            ScaleWithWeatherIntensity = 8,
        };
    };
}
