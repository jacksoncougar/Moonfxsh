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
    public partial class MaterialPhysicsPropertiesStructBlock : MaterialPhysicsPropertiesStructBlockBase
    {
        public MaterialPhysicsPropertiesStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MaterialPhysicsPropertiesStructBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal float friction;
        internal float restitution;
        internal float densityKgM3;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public MaterialPhysicsPropertiesStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            friction = binaryReader.ReadSingle();
            restitution = binaryReader.ReadSingle();
            densityKgM3 = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(friction);
                binaryWriter.Write(restitution);
                binaryWriter.Write(densityKgM3);
                return nextAddress;
            }
        }
    };
}
