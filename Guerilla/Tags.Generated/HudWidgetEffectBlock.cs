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
    public partial class HudWidgetEffectBlock : HudWidgetEffectBlockBase
    {
        public HudWidgetEffectBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 104, Alignment = 4)]
    public class HudWidgetEffectBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct0;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct1;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct2;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct3;
        public override int SerializedSize { get { return 104; } }
        public override int Alignment { get { return 4; } }
        public HudWidgetEffectBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            hudWidgetEffectFunctionStruct = new HudWidgetEffectFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(hudWidgetEffectFunctionStruct.ReadFields(binaryReader)));
            hudWidgetEffectFunctionStruct0 = new HudWidgetEffectFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(hudWidgetEffectFunctionStruct0.ReadFields(binaryReader)));
            hudWidgetEffectFunctionStruct1 = new HudWidgetEffectFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(hudWidgetEffectFunctionStruct1.ReadFields(binaryReader)));
            hudWidgetEffectFunctionStruct2 = new HudWidgetEffectFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(hudWidgetEffectFunctionStruct2.ReadFields(binaryReader)));
            hudWidgetEffectFunctionStruct3 = new HudWidgetEffectFunctionStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(hudWidgetEffectFunctionStruct3.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            hudWidgetEffectFunctionStruct.ReadPointers(binaryReader, blamPointers);
            hudWidgetEffectFunctionStruct0.ReadPointers(binaryReader, blamPointers);
            hudWidgetEffectFunctionStruct1.ReadPointers(binaryReader, blamPointers);
            hudWidgetEffectFunctionStruct2.ReadPointers(binaryReader, blamPointers);
            hudWidgetEffectFunctionStruct3.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                hudWidgetEffectFunctionStruct.Write(binaryWriter);
                hudWidgetEffectFunctionStruct0.Write(binaryWriter);
                hudWidgetEffectFunctionStruct1.Write(binaryWriter);
                hudWidgetEffectFunctionStruct2.Write(binaryWriter);
                hudWidgetEffectFunctionStruct3.Write(binaryWriter);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            ApplyScale = 1,
            ApplyTheta = 2,
            ApplyOffset = 4,
        };
    };
}
