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
        public static readonly TagClass Nhdt = (TagClass)"nhdt";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("nhdt")]
    public partial class NewHudDefinitionBlock : NewHudDefinitionBlockBase
    {
        public NewHudDefinitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class NewHudDefinitionBlockBase : GuerillaBlock
    {
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference dONOTUSE;
        internal HudBitmapWidgets[] bitmapWidgets;
        internal HudTextWidgets[] textWidgets;
        internal NewHudDashlightDataStructBlock dashlightData;
        internal HudScreenEffectWidgets[] screenEffectWidgets;
        public override int SerializedSize { get { return 40; } }
        public override int Alignment { get { return 4; } }
        public NewHudDefinitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            dONOTUSE = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<HudBitmapWidgets>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudTextWidgets>(binaryReader));
            dashlightData = new NewHudDashlightDataStructBlock();
            blamPointers.Concat(dashlightData.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudScreenEffectWidgets>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bitmapWidgets = ReadBlockArrayData<HudBitmapWidgets>(binaryReader, blamPointers.Dequeue());
            textWidgets = ReadBlockArrayData<HudTextWidgets>(binaryReader, blamPointers.Dequeue());
            dashlightData.ReadPointers(binaryReader, blamPointers);
            screenEffectWidgets = ReadBlockArrayData<HudScreenEffectWidgets>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dONOTUSE);
                nextAddress = Guerilla.WriteBlockArray<HudBitmapWidgets>(binaryWriter, bitmapWidgets, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudTextWidgets>(binaryWriter, textWidgets, nextAddress);
                dashlightData.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<HudScreenEffectWidgets>(binaryWriter, screenEffectWidgets, nextAddress);
                return nextAddress;
            }
        }
    };
}
