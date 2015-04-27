// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspSoundEnvironmentPaletteBlock : StructureBspSoundEnvironmentPaletteBlockBase
    {
        public  StructureBspSoundEnvironmentPaletteBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspSoundEnvironmentPaletteBlock(): base()
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
        
        public override int SerializedSize{get { return 72; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspSoundEnvironmentPaletteBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadString32();
            soundEnvironment = binaryReader.ReadTagReference();
            cutoffDistance = binaryReader.ReadSingle();
            interpolationSpeed1Sec = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(24);
        }
        public  StructureBspSoundEnvironmentPaletteBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
