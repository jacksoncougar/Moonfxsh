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
    public partial class SyntaxDatumBlock : SyntaxDatumBlockBase
    {
        public SyntaxDatumBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class SyntaxDatumBlockBase : GuerillaBlock
    {
        internal short datumHeader;
        internal short scriptIndexFunctionIndexConstantTypeUnion;
        internal short type;
        internal short flags;
        internal int nextNodeIndex;
        internal int data;
        internal int sourceOffset;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public SyntaxDatumBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            datumHeader = binaryReader.ReadInt16();
            scriptIndexFunctionIndexConstantTypeUnion = binaryReader.ReadInt16();
            type = binaryReader.ReadInt16();
            flags = binaryReader.ReadInt16();
            nextNodeIndex = binaryReader.ReadInt32();
            data = binaryReader.ReadInt32();
            sourceOffset = binaryReader.ReadInt32();
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
                binaryWriter.Write(datumHeader);
                binaryWriter.Write(scriptIndexFunctionIndexConstantTypeUnion);
                binaryWriter.Write(type);
                binaryWriter.Write(flags);
                binaryWriter.Write(nextNodeIndex);
                binaryWriter.Write(data);
                binaryWriter.Write(sourceOffset);
                return nextAddress;
            }
        }
    };
}