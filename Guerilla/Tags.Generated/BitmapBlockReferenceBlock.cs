// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class BitmapBlockReferenceBlock : BitmapBlockReferenceBlockBase
    {
        public  BitmapBlockReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  BitmapBlockReferenceBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 56, Alignment = 4)]
    public class BitmapBlockReferenceBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal AnimationIndex animationIndex;
        internal short introAnimationDelayMilliseconds;
        internal BitmapBlendMethod bitmapBlendMethod;
        internal short initialSpriteFrame;
        internal Moonfish.Tags.Point topLeft;
        internal float horizTextureWrapsSecond;
        internal float vertTextureWrapsSecond;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference bitmapTag;
        internal short renderDepthBias;
        internal byte[] invalidName_;
        internal float spriteAnimationSpeedFps;
        internal Moonfish.Tags.Point progressBottomLeft;
        internal Moonfish.Tags.StringIdent stringIdentifier;
        internal OpenTK.Vector2 progressScale;
        
        public override int SerializedSize{get { return 56; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  BitmapBlockReferenceBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            bitmapBlendMethod = (BitmapBlendMethod)binaryReader.ReadInt16();
            initialSpriteFrame = binaryReader.ReadInt16();
            topLeft = binaryReader.ReadPoint();
            horizTextureWrapsSecond = binaryReader.ReadSingle();
            vertTextureWrapsSecond = binaryReader.ReadSingle();
            bitmapTag = binaryReader.ReadTagReference();
            renderDepthBias = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            spriteAnimationSpeedFps = binaryReader.ReadSingle();
            progressBottomLeft = binaryReader.ReadPoint();
            stringIdentifier = binaryReader.ReadStringID();
            progressScale = binaryReader.ReadVector2();
        }
        public  BitmapBlockReferenceBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt32();
            animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            bitmapBlendMethod = (BitmapBlendMethod)binaryReader.ReadInt16();
            initialSpriteFrame = binaryReader.ReadInt16();
            topLeft = binaryReader.ReadPoint();
            horizTextureWrapsSecond = binaryReader.ReadSingle();
            vertTextureWrapsSecond = binaryReader.ReadSingle();
            bitmapTag = binaryReader.ReadTagReference();
            renderDepthBias = binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            spriteAnimationSpeedFps = binaryReader.ReadSingle();
            progressBottomLeft = binaryReader.ReadPoint();
            stringIdentifier = binaryReader.ReadStringID();
            progressScale = binaryReader.ReadVector2();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)flags);
                binaryWriter.Write((Int16)animationIndex);
                binaryWriter.Write(introAnimationDelayMilliseconds);
                binaryWriter.Write((Int16)bitmapBlendMethod);
                binaryWriter.Write(initialSpriteFrame);
                binaryWriter.Write(topLeft);
                binaryWriter.Write(horizTextureWrapsSecond);
                binaryWriter.Write(vertTextureWrapsSecond);
                binaryWriter.Write(bitmapTag);
                binaryWriter.Write(renderDepthBias);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(spriteAnimationSpeedFps);
                binaryWriter.Write(progressBottomLeft);
                binaryWriter.Write(stringIdentifier);
                binaryWriter.Write(progressScale);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : int
        {
            IgnoreForListSkinSizeCalculation = 1,
            SwapOnRelativeListPosition = 2,
            RenderAsProgressBar = 4,
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
        internal enum BitmapBlendMethod : short
        {
            Standard = 0,
            Multiply = 1,
            UNUSED = 2,
        };
    };
}
