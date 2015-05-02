// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ButtonWidgetReferenceBlock : ButtonWidgetReferenceBlockBase
    {
        public  ButtonWidgetReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ButtonWidgetReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class ButtonWidgetReferenceBlockBase : GuerillaBlock
    {
        internal TextFlags textFlags;
        internal AnimationIndex animationIndex;
        internal short introAnimationDelayMilliseconds;
        internal byte[] invalidName_;
        internal CustomFont customFont;
        internal OpenTK.Vector4 textColor;
        internal OpenTK.Vector2 bounds;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmap;
        /// <summary>
        /// from top-left
        /// </summary>
        internal Moonfish.Tags.Point bitmapOffset;
        internal Moonfish.Tags.StringIdent StringIdent;
        internal short renderDepthBias;
        internal short mouseRegionTopOffset;
        internal ButtonFlags buttonFlags;
        
        public override int SerializedSize{get { return 60; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ButtonWidgetReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            textFlags = (TextFlags)binaryReader.ReadInt32();
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            customFont = (CustomFont)binaryReader.ReadInt16();
            textColor = binaryReader.ReadVector4();
            bounds = binaryReader.ReadVector2();
            bitmap = binaryReader.ReadTagReference();
            bitmapOffset = binaryReader.ReadPoint();
            StringIdent = binaryReader.ReadStringID();
            renderDepthBias = binaryReader.ReadInt16();
            mouseRegionTopOffset = binaryReader.ReadInt16();
            buttonFlags = (ButtonFlags)binaryReader.ReadInt32();
        }
        public  ButtonWidgetReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            textFlags = (TextFlags)binaryReader.ReadInt32();
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            customFont = (CustomFont)binaryReader.ReadInt16();
            textColor = binaryReader.ReadVector4();
            bounds = binaryReader.ReadVector2();
            bitmap = binaryReader.ReadTagReference();
            bitmapOffset = binaryReader.ReadPoint();
            StringIdent = binaryReader.ReadStringID();
            renderDepthBias = binaryReader.ReadInt16();
            mouseRegionTopOffset = binaryReader.ReadInt16();
            buttonFlags = (ButtonFlags)binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)textFlags);
                binaryWriter.Write((Int16)animationIndex);
                binaryWriter.Write(introAnimationDelayMilliseconds);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)customFont);
                binaryWriter.Write(textColor);
                binaryWriter.Write(bounds);
                binaryWriter.Write(bitmap);
                binaryWriter.Write(bitmapOffset);
                binaryWriter.Write(StringIdent);
                binaryWriter.Write(renderDepthBias);
                binaryWriter.Write(mouseRegionTopOffset);
                binaryWriter.Write((Int32)buttonFlags);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum TextFlags : int
        {
            LeftJustifyText = 1,
            RightJustifyText = 2,
            PulsatingText = 4,
            CalloutText = 8,
            Small31CharBuffer = 16,
        };
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
        internal enum CustomFont : short
        {
            Terminal = 0,
            BodyText = 1,
            Title = 2,
            SuperLargeFont = 3,
            LargeBodyText = 4,
            SplitScreenHudMessage = 5,
            FullScreenHudMessage = 6,
            EnglishBodyText = 7,
            HUDNumberText = 8,
            SubtitleFont = 9,
            MainMenuFont = 10,
            TextChatFont = 11,
        };
        [FlagsAttribute]
        internal enum ButtonFlags : int
        {
            DOESNTTabVertically = 1,
            DOESNTTabHorizontally = 2,
        };
    };
}
