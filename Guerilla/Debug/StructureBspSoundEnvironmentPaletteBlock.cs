// ReSharper disable All
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
        public  StructureBspSoundEnvironmentPaletteBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspSoundEnvironmentPaletteBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            soundEnvironment = binaryReader.ReadTagReference();
            cutoffDistance = binaryReader.ReadSingle();
            interpolationSpeed1Sec = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
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
                binaryWriter.Write(soundEnvironment);
                binaryWriter.Write(cutoffDistance);
                binaryWriter.Write(interpolationSpeed1Sec);
                binaryWriter.Write(invalidName_, 0, 24);
            }
        }
    };
}
