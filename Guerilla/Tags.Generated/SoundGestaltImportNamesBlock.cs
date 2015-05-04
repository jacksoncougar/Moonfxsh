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
    public partial class SoundGestaltImportNamesBlock : SoundGestaltImportNamesBlockBase
    {
        public SoundGestaltImportNamesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SoundGestaltImportNamesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent importName;
        public override int SerializedSize { get { return 4; } }
        public override int Alignment { get { return 4; } }
        public SoundGestaltImportNamesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            importName = binaryReader.ReadStringID();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(importName);
                return nextAddress;
            }
        }
    };
}
