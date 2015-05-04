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
    public partial class StructureBspSoundEnvironmentPaletteBlock : StructureBspSoundEnvironmentPaletteBlockBase
    {
        public StructureBspSoundEnvironmentPaletteBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class StructureBspSoundEnvironmentPaletteBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        [TagReference("snde")]
        internal Moonfish.Tags.TagReference soundEnvironment;
        internal float cutoffDistance;
        internal float interpolationSpeed1Sec;
        internal byte[] invalidName_;
        public override int SerializedSize { get { return 72; } }
        public override int Alignment { get { return 4; } }
        public StructureBspSoundEnvironmentPaletteBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            soundEnvironment = binaryReader.ReadTagReference();
            cutoffDistance = binaryReader.ReadSingle();
            interpolationSpeed1Sec = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
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
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(soundEnvironment);
                binaryWriter.Write(cutoffDistance);
                binaryWriter.Write(interpolationSpeed1Sec);
                binaryWriter.Write(invalidName_, 0, 24);
                return nextAddress;
            }
        }
    };
}
