using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class BitmapBlockReferenceBlock : BitmapBlockReferenceBlockBase
    {
        public  BitmapBlockReferenceBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class BitmapBlockReferenceBlockBase
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
        internal Moonfish.Tags.StringID stringIdentifier;
        internal OpenTK.Vector2 progressScale;
        internal  BitmapBlockReferenceBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.animationIndex = (AnimationIndex)binaryReader.ReadInt16();
            this.introAnimationDelayMilliseconds = binaryReader.ReadInt16();
            this.bitmapBlendMethod = (BitmapBlendMethod)binaryReader.ReadInt16();
            this.initialSpriteFrame = binaryReader.ReadInt16();
            this.topLeft = binaryReader.ReadPoint();
            this.horizTextureWrapsSecond = binaryReader.ReadSingle();
            this.vertTextureWrapsSecond = binaryReader.ReadSingle();
            this.bitmapTag = binaryReader.ReadTagReference();
            this.renderDepthBias = binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.spriteAnimationSpeedFps = binaryReader.ReadSingle();
            this.progressBottomLeft = binaryReader.ReadPoint();
            this.stringIdentifier = binaryReader.ReadStringID();
            this.progressScale = binaryReader.ReadVector2();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
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
