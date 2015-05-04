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
    public partial class RenderModelNodeMapBlock : RenderModelNodeMapBlockBase
    {
        public RenderModelNodeMapBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class RenderModelNodeMapBlockBase : GuerillaBlock
    {
        internal byte nodeIndex;
        public override int SerializedSize { get { return 1; } }
        public override int Alignment { get { return 4; } }
        public RenderModelNodeMapBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            nodeIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(nodeIndex);
                return nextAddress;
            }
        }
    };
}
