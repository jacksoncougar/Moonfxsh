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
        public static readonly TagClass Skin = (TagClass)"skin";
    };
};

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("skin")]
    public partial class UserInterfaceListSkinDefinitionBlock : UserInterfaceListSkinDefinitionBlockBase
    {
        public UserInterfaceListSkinDefinitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class UserInterfaceListSkinDefinitionBlockBase : GuerillaBlock
    {
        internal ListFlags listFlags;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference arrowsBitmap;
        internal Moonfish.Tags.Point upArrowsOffsetFromBotLeftOf1StItem;
        internal Moonfish.Tags.Point downArrowsOffsetFromBotLeftOf1StItem;
        internal SingleAnimationReferenceBlock[] itemAnimations;
        internal TextBlockReferenceBlock[] textBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        internal HudBlockReferenceBlock[] hudBlocks;
        internal PlayerBlockReferenceBlock[] playerBlocks;
        public override int SerializedSize { get { return 60; } }
        public override int Alignment { get { return 4; } }
        public UserInterfaceListSkinDefinitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            listFlags = (ListFlags)binaryReader.ReadInt32();
            arrowsBitmap = binaryReader.ReadTagReference();
            upArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            downArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            blamPointers.Enqueue(ReadBlockArrayPointer<SingleAnimationReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<TextBlockReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<BitmapBlockReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<HudBlockReferenceBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlayerBlockReferenceBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            itemAnimations = ReadBlockArrayData<SingleAnimationReferenceBlock>(binaryReader, blamPointers.Dequeue());
            textBlocks = ReadBlockArrayData<TextBlockReferenceBlock>(binaryReader, blamPointers.Dequeue());
            bitmapBlocks = ReadBlockArrayData<BitmapBlockReferenceBlock>(binaryReader, blamPointers.Dequeue());
            hudBlocks = ReadBlockArrayData<HudBlockReferenceBlock>(binaryReader, blamPointers.Dequeue());
            playerBlocks = ReadBlockArrayData<PlayerBlockReferenceBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)listFlags);
                binaryWriter.Write(arrowsBitmap);
                binaryWriter.Write(upArrowsOffsetFromBotLeftOf1StItem);
                binaryWriter.Write(downArrowsOffsetFromBotLeftOf1StItem);
                nextAddress = Guerilla.WriteBlockArray<SingleAnimationReferenceBlock>(binaryWriter, itemAnimations, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TextBlockReferenceBlock>(binaryWriter, textBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BitmapBlockReferenceBlock>(binaryWriter, bitmapBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudBlockReferenceBlock>(binaryWriter, hudBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerBlockReferenceBlock>(binaryWriter, playerBlocks, nextAddress);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum ListFlags : int
        {
            Unused = 1,
        };
    };
}
