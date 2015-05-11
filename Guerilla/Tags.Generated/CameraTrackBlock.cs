// ReSharper disable All

using Moonfish.Model;

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
        public static readonly TagClass Trak = (TagClass) "trak";
    };
} ;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("trak")]
    public partial class CameraTrackBlock : CameraTrackBlockBase
    {
        public CameraTrackBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class CameraTrackBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal CameraTrackControlPointBlock[] controlPoints;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public CameraTrackBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt32();
            blamPointers.Enqueue(ReadBlockArrayPointer<CameraTrackControlPointBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            controlPoints = ReadBlockArrayData<CameraTrackControlPointBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) flags);
                nextAddress = Guerilla.WriteBlockArray<CameraTrackControlPointBlock>(binaryWriter, controlPoints,
                    nextAddress);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : int
        {
        };
    };
}