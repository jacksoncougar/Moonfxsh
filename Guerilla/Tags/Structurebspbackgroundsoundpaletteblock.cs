using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspBackgroundSoundPaletteBlock : StructureBspBackgroundSoundPaletteBlockBase
    {
        public  StructureBspBackgroundSoundPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 100)]
    public class StructureBspBackgroundSoundPaletteBlockBase
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
        internal  StructureBspBackgroundSoundPaletteBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.backgroundSound = binaryReader.ReadTagReference();
            this.insideClusterSound = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(20);
            this.cutoffDistance = binaryReader.ReadSingle();
            this.scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
            this.interiorScale = binaryReader.ReadSingle();
            this.portalScale = binaryReader.ReadSingle();
            this.exteriorScale = binaryReader.ReadSingle();
            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
            this.invalidName_0 = binaryReader.ReadBytes(8);
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
