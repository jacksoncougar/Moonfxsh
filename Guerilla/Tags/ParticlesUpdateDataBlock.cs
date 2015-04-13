using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticlesUpdateDataBlock : ParticlesUpdateDataBlockBase
    {
        public  ParticlesUpdateDataBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class ParticlesUpdateDataBlockBase
    {
        internal float velocityX;
        internal float velocityY;
        internal float velocityZ;
        internal byte[] invalidName_;
        internal float mass;
        internal float creationTimeStamp;
        internal  ParticlesUpdateDataBlockBase(BinaryReader binaryReader)
        {
            this.velocityX = binaryReader.ReadSingle();
            this.velocityY = binaryReader.ReadSingle();
            this.velocityZ = binaryReader.ReadSingle();
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.mass = binaryReader.ReadSingle();
            this.creationTimeStamp = binaryReader.ReadSingle();
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
    };
}
