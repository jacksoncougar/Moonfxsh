// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class WindowPaneReferenceBlock : WindowPaneReferenceBlockBase
    {
        public  WindowPaneReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  WindowPaneReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 76, Alignment = 4)]
    public class WindowPaneReferenceBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal AnimationIndex animationIndex;
        internal ButtonWidgetReferenceBlock[] buttons;
        internal ListReferenceBlock[] listBlock;
        internal TableViewListReferenceBlock[] tableView;
        internal TextBlockReferenceBlock[] textBlocks;
        internal BitmapBlockReferenceBlock[] bitmapBlocks;
        internal UiModelSceneReferenceBlock[] modelSceneBlocks;
        internal STextValuePairBlocksBlockUNUSED[] textValueBlocks;
        internal HudBlockReferenceBlock[] hudBlocks;
        internal PlayerBlockReferenceBlock[] playerBlocks;
        
        public override int SerializedSize{get { return 76; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  WindowPaneReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            buttons = Guerilla.ReadBlockArray<ButtonWidgetReferenceBlock>(binaryReader);
            listBlock = Guerilla.ReadBlockArray<ListReferenceBlock>(binaryReader);
            tableView = Guerilla.ReadBlockArray<TableViewListReferenceBlock>(binaryReader);
            textBlocks = Guerilla.ReadBlockArray<TextBlockReferenceBlock>(binaryReader);
            bitmapBlocks = Guerilla.ReadBlockArray<BitmapBlockReferenceBlock>(binaryReader);
            modelSceneBlocks = Guerilla.ReadBlockArray<UiModelSceneReferenceBlock>(binaryReader);
            textValueBlocks = Guerilla.ReadBlockArray<STextValuePairBlocksBlockUNUSED>(binaryReader);
            hudBlocks = Guerilla.ReadBlockArray<HudBlockReferenceBlock>(binaryReader);
            playerBlocks = Guerilla.ReadBlockArray<PlayerBlockReferenceBlock>(binaryReader);
        }
        public  WindowPaneReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            buttons = Guerilla.ReadBlockArray<ButtonWidgetReferenceBlock>(binaryReader);
            listBlock = Guerilla.ReadBlockArray<ListReferenceBlock>(binaryReader);
            tableView = Guerilla.ReadBlockArray<TableViewListReferenceBlock>(binaryReader);
            textBlocks = Guerilla.ReadBlockArray<TextBlockReferenceBlock>(binaryReader);
            bitmapBlocks = Guerilla.ReadBlockArray<BitmapBlockReferenceBlock>(binaryReader);
            modelSceneBlocks = Guerilla.ReadBlockArray<UiModelSceneReferenceBlock>(binaryReader);
            textValueBlocks = Guerilla.ReadBlockArray<STextValuePairBlocksBlockUNUSED>(binaryReader);
            hudBlocks = Guerilla.ReadBlockArray<HudBlockReferenceBlock>(binaryReader);
            playerBlocks = Guerilla.ReadBlockArray<PlayerBlockReferenceBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)animationIndex);
                nextAddress = Guerilla.WriteBlockArray<ButtonWidgetReferenceBlock>(binaryWriter, buttons, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<ListReferenceBlock>(binaryWriter, listBlock, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TableViewListReferenceBlock>(binaryWriter, tableView, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<TextBlockReferenceBlock>(binaryWriter, textBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<BitmapBlockReferenceBlock>(binaryWriter, bitmapBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<UiModelSceneReferenceBlock>(binaryWriter, modelSceneBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<STextValuePairBlocksBlockUNUSED>(binaryWriter, textValueBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<HudBlockReferenceBlock>(binaryWriter, hudBlocks, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlayerBlockReferenceBlock>(binaryWriter, playerBlocks, nextAddress);
                return nextAddress;
            }
        }
        internal enum AnimationIndex : short
        {
            NONE = 0,
            InvalidName00 = 1,
            InvalidName01 = 2,
            InvalidName02 = 3,
            InvalidName03 = 4,
            InvalidName04 = 5,
            InvalidName05 = 6,
            InvalidName06 = 7,
            InvalidName07 = 8,
            InvalidName08 = 9,
            InvalidName09 = 10,
            InvalidName10 = 11,
            InvalidName11 = 12,
            InvalidName12 = 13,
            InvalidName13 = 14,
            InvalidName14 = 15,
            InvalidName15 = 16,
            InvalidName16 = 17,
            InvalidName17 = 18,
            InvalidName18 = 19,
            InvalidName19 = 20,
            InvalidName20 = 21,
            InvalidName21 = 22,
            InvalidName22 = 23,
            InvalidName23 = 24,
            InvalidName24 = 25,
            InvalidName25 = 26,
            InvalidName26 = 27,
            InvalidName27 = 28,
            InvalidName28 = 29,
            InvalidName29 = 30,
            InvalidName30 = 31,
            InvalidName31 = 32,
            InvalidName32 = 33,
            InvalidName33 = 34,
            InvalidName34 = 35,
            InvalidName35 = 36,
            InvalidName36 = 37,
            InvalidName37 = 38,
            InvalidName38 = 39,
            InvalidName39 = 40,
            InvalidName40 = 41,
            InvalidName41 = 42,
            InvalidName42 = 43,
            InvalidName43 = 44,
            InvalidName44 = 45,
            InvalidName45 = 46,
            InvalidName46 = 47,
            InvalidName47 = 48,
            InvalidName48 = 49,
            InvalidName49 = 50,
            InvalidName50 = 51,
            InvalidName51 = 52,
            InvalidName52 = 53,
            InvalidName53 = 54,
            InvalidName54 = 55,
            InvalidName55 = 56,
            InvalidName56 = 57,
            InvalidName57 = 58,
            InvalidName58 = 59,
            InvalidName59 = 60,
            InvalidName60 = 61,
            InvalidName61 = 62,
            InvalidName62 = 63,
            InvalidName63 = 64,
        };
    };
}
