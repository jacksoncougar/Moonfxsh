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
    public partial class CsPointSetBlock : CsPointSetBlockBase
    {
        public CsPointSetBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class CsPointSetBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal CsPointBlock[] points;
        internal Moonfish.Tags.ShortBlockIndex1 bspIndex;
        internal short manualReferenceFrame;
        internal Flags flags;

        public override int SerializedSize
        {
            get { return 48; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CsPointSetBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            blamPointers.Enqueue(ReadBlockArrayPointer<CsPointBlock>(binaryReader));
            bspIndex = binaryReader.ReadShortBlockIndex1();
            manualReferenceFrame = binaryReader.ReadInt16();
            flags = (Flags) binaryReader.ReadInt32();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            points = ReadBlockArrayData<CsPointBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<CsPointBlock>(binaryWriter, points, nextAddress);
                binaryWriter.Write(bspIndex);
                binaryWriter.Write(manualReferenceFrame);
                binaryWriter.Write((Int32) flags);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
            ManualReferenceFrame = 1,
            TurretDeployment = 2,
        };
    };
}