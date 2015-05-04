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
    public partial class AiSceneRoleBlock : AiSceneRoleBlockBase
    {
        public AiSceneRoleBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class AiSceneRoleBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal Group group;
        internal byte[] invalidName_;
        internal AiSceneRoleVariantsBlock[] roleVariants;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public AiSceneRoleBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            group = (Group)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<AiSceneRoleVariantsBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            roleVariants = ReadBlockArrayData<AiSceneRoleVariantsBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write((Int16)group);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<AiSceneRoleVariantsBlock>(binaryWriter, roleVariants, nextAddress);
                return nextAddress;
            }
        }
        internal enum Group : short
        {
            Group1 = 0,
            Group2 = 1,
            Group3 = 2,
        };
    };
}
