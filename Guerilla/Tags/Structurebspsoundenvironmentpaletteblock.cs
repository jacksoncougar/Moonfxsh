using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspSoundEnvironmentPaletteBlock : StructureBspSoundEnvironmentPaletteBlockBase
    {
        public  StructureBspSoundEnvironmentPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class StructureBspSoundEnvironmentPaletteBlockBase
    {
        internal Moonfish.Tags.String32 name;
        [TagReference("snde")]
        internal Moonfish.Tags.TagReference soundEnvironment;
        internal float cutoffDistance;
        internal float interpolationSpeed1Sec;
        internal byte[] invalidName_;
        internal  StructureBspSoundEnvironmentPaletteBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.soundEnvironment = binaryReader.ReadTagReference();
            this.cutoffDistance = binaryReader.ReadSingle();
            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(24);
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
    };
}
