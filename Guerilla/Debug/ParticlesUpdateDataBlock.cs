// ReSharper disable All
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
        public  ParticlesUpdateDataBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ParticlesUpdateDataBlockBase(System.IO.BinaryReader binaryReader)
        {
            velocityX = binaryReader.ReadSingle();
            velocityY = binaryReader.ReadSingle();
            velocityZ = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(12);
            mass = binaryReader.ReadSingle();
            creationTimeStamp = binaryReader.ReadSingle();
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
                binaryWriter.Write(velocityX);
                binaryWriter.Write(velocityY);
                binaryWriter.Write(velocityZ);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(mass);
                binaryWriter.Write(creationTimeStamp);
            }
        }
    };
}
