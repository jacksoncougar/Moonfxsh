// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Tags
{
    public partial struct TagClass
    {
        public static readonly TagClass Mulg = (TagClass) "mulg";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mulg")]
    public partial class MultiplayerGlobalsBlock : MultiplayerGlobalsBlockBase
    {
        public MultiplayerGlobalsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MultiplayerGlobalsBlockBase : GuerillaBlock
    {
        internal MultiplayerUniversalBlock[] universal;
        internal MultiplayerRuntimeBlock[] runtime;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MultiplayerGlobalsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerUniversalBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<MultiplayerRuntimeBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            universal = ReadBlockArrayData<MultiplayerUniversalBlock>(binaryReader, blamPointers.Dequeue());
            runtime = ReadBlockArrayData<MultiplayerRuntimeBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MultiplayerUniversalBlock>(binaryWriter, universal, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MultiplayerRuntimeBlock>(binaryWriter, runtime, nextAddress);
                return nextAddress;
            }
        }
    };
}