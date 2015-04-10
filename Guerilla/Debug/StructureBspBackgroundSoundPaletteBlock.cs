// ReSharper disable All
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
        public  StructureBspBackgroundSoundPaletteBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspBackgroundSoundPaletteBlockBase(System.IO.BinaryReader binaryReader)
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
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
