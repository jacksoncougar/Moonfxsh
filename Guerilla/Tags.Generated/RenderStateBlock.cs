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
    public partial class RenderStateBlock : RenderStateBlockBase
    {
        public RenderStateBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 5, Alignment = 4)]
    public class RenderStateBlockBase : GuerillaBlock
    {
        internal byte stateIndex;
        internal int stateValue;

        public override int SerializedSize
        {
            get { return 5; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderStateBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            stateIndex = binaryReader.ReadByte();
            stateValue = binaryReader.ReadInt32();
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
                binaryWriter.Write(stateIndex);
                binaryWriter.Write(stateValue);
                return nextAddress;
            }
        }
    };
}