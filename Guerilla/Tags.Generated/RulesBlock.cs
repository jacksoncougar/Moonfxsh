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
    public partial class RulesBlock : RulesBlockBase
    {
        public RulesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 84, Alignment = 4)]
    public class RulesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.String32 name;
        internal Moonfish.Tags.ColourR8G8B8 tintColor;
        internal byte[] invalidName_;
        internal StatesBlock[] states;
        public override int SerializedSize { get { return 84; } }
        public override int Alignment { get { return 4; } }
        public RulesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadString32();
            tintColor = binaryReader.ReadColorR8G8B8();
            invalidName_ = binaryReader.ReadBytes(32);
            blamPointers.Enqueue(ReadBlockArrayPointer<StatesBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            states = ReadBlockArrayData<StatesBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(tintColor);
                binaryWriter.Write(invalidName_, 0, 32);
                nextAddress = Guerilla.WriteBlockArray<StatesBlock>(binaryWriter, states, nextAddress);
                return nextAddress;
            }
        }
    };
}
