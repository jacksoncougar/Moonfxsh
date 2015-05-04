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
    public partial class StructureBspBackgroundSoundPaletteBlock : StructureBspBackgroundSoundPaletteBlockBase
    {
        public StructureBspBackgroundSoundPaletteBlock() : base()
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
        public override int SerializedSize { get { return 100; } }
        public override int Alignment { get { return 4; } }
        public StructureBspBackgroundSoundPaletteBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
