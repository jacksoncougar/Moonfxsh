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
    public partial class OldUnusedObjectIdentifiersBlock : OldUnusedObjectIdentifiersBlockBase
    {
        public OldUnusedObjectIdentifiersBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class OldUnusedObjectIdentifiersBlockBase : GuerillaBlock
    {
        internal ScenarioObjectIdStructBlock objectID;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public OldUnusedObjectIdentifiersBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            objectID = new ScenarioObjectIdStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(objectID.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            objectID.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                objectID.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}