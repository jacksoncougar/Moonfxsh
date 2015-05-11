// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalSubpartsBlock : GlobalSubpartsBlockBase
    {
        public GlobalSubpartsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GlobalSubpartsBlockBase : GuerillaBlock
    {
        internal short indicesStartIndex;
        internal short indicesLength;
        internal short visibilityBoundsIndex;
        internal short partIndex;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalSubpartsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            indicesStartIndex = binaryReader.ReadInt16();
            indicesLength = binaryReader.ReadInt16();
            visibilityBoundsIndex = binaryReader.ReadInt16();
            partIndex = binaryReader.ReadInt16();
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
                binaryWriter.Write(indicesStartIndex);
                binaryWriter.Write(indicesLength);
                binaryWriter.Write(visibilityBoundsIndex);
                binaryWriter.Write(partIndex);
                return nextAddress;
            }
        }
    };
}