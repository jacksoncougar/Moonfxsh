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
    public partial class MoonfishXboxAnimationUnknownBlock : MoonfishXboxAnimationUnknownBlockBase
    {
        public MoonfishXboxAnimationUnknownBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class MoonfishXboxAnimationUnknownBlockBase : GuerillaBlock
    {
        internal int unknown1;
        internal int unknown2;
        internal int unknown3;
        internal int unknown4;
        internal int unknown5;
        internal int unknown6;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public MoonfishXboxAnimationUnknownBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            unknown1 = binaryReader.ReadInt32();
            unknown2 = binaryReader.ReadInt32();
            unknown3 = binaryReader.ReadInt32();
            unknown4 = binaryReader.ReadInt32();
            unknown5 = binaryReader.ReadInt32();
            unknown6 = binaryReader.ReadInt32();
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
                binaryWriter.Write(unknown1);
                binaryWriter.Write(unknown2);
                binaryWriter.Write(unknown3);
                binaryWriter.Write(unknown4);
                binaryWriter.Write(unknown5);
                binaryWriter.Write(unknown6);
                return nextAddress;
            }
        }
    };
}