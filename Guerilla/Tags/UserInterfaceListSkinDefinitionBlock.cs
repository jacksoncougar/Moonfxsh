// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

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
    public  partial class UserInterfaceListSkinDefinitionBlock : UserInterfaceListSkinDefinitionBlockBase
    {
        public  UserInterfaceListSkinDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class UserInterfaceListSkinDefinitionBlockBase  : IGuerilla
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
        internal  UserInterfaceListSkinDefinitionBlockBase(BinaryReader binaryReader)
        {
            listFlags = (ListFlags)binaryReader.ReadInt32();
            arrowsBitmap = binaryReader.ReadTagReference();
            upArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            downArrowsOffsetFromBotLeftOf1StItem = binaryReader.ReadPoint();
            itemAnimations = Guerilla.ReadBlockArray<SingleAnimationReferenceBlock>(binaryReader);
            textBlocks = Guerilla.ReadBlockArray<TextBlockReferenceBlock>(binaryReader);
            bitmapBlocks = Guerilla.ReadBlockArray<BitmapBlockReferenceBlock>(binaryReader);
            hudBlocks = Guerilla.ReadBlockArray<HudBlockReferenceBlock>(binaryReader);
            playerBlocks = Guerilla.ReadBlockArray<PlayerBlockReferenceBlock>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
