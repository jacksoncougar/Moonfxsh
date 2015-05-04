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
    public partial class GScenarioEditorFolderBlock : GScenarioEditorFolderBlockBase
    {
        public GScenarioEditorFolderBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 260, Alignment = 4)]
    public class GScenarioEditorFolderBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.LongBlockIndex1 parentFolder;
        internal Moonfish.Tags.String256 name;

        public override int SerializedSize
        {
            get { return 260; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GScenarioEditorFolderBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parentFolder = binaryReader.ReadLongBlockIndex1();
            name = binaryReader.ReadString256();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parentFolder);
                binaryWriter.Write(name);
                return nextAddress;
            }
        }
    };
}