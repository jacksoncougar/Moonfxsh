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
    public partial class BehaviorNamesBlock : BehaviorNamesBlockBase
    {
        public BehaviorNamesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class BehaviorNamesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 behaviorName;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public BehaviorNamesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            behaviorName = binaryReader.ReadString32();
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
                binaryWriter.Write(behaviorName);
                return nextAddress;
            }
        }
    };
}
