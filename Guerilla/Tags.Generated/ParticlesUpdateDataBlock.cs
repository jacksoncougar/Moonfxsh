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
    public partial class ParticlesUpdateDataBlock : ParticlesUpdateDataBlockBase
    {
        public ParticlesUpdateDataBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class ParticlesUpdateDataBlockBase : GuerillaBlock
    {
        internal float velocityX;
        internal float velocityY;
        internal float velocityZ;
        internal byte[] invalidName_;
        internal float mass;
        internal float creationTimeStamp;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public ParticlesUpdateDataBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            velocityX = binaryReader.ReadSingle();
            velocityY = binaryReader.ReadSingle();
            velocityZ = binaryReader.ReadSingle();
            invalidName_ = binaryReader.ReadBytes(12);
            mass = binaryReader.ReadSingle();
            creationTimeStamp = binaryReader.ReadSingle();
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
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(velocityX);
                binaryWriter.Write(velocityY);
                binaryWriter.Write(velocityZ);
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(mass);
                binaryWriter.Write(creationTimeStamp);
                return nextAddress;
            }
        }
    };
}
