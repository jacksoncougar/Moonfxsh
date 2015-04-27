// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalHudScreenEffectDefinition : GlobalHudScreenEffectDefinitionBase
    {
        public  GlobalHudScreenEffectDefinition(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalHudScreenEffectDefinition(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 320, Alignment = 4)]
    public class GlobalHudScreenEffectDefinitionBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal Flags flags;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference maskFullscreen;
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference maskSplitscreen;
        internal byte[] invalidName_2;
        internal byte[] invalidName_3;
        internal byte[] invalidName_4;
        internal byte[] invalidName_5;
        internal byte[] invalidName_6;
        internal byte[] invalidName_7;
        internal byte[] invalidName_8;
        internal ScreenEffectFlags screenEffectFlags;
        internal byte[] invalidName_9;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference screenEffect;
        internal byte[] invalidName_10;
        internal ScreenEffectFlags screenEffectFlags0;
        internal byte[] invalidName_11;
        [TagReference("egor")]
        internal Moonfish.Tags.TagReference screenEffect0;
        internal byte[] invalidName_12;
        
        public override int SerializedSize{get { return 320; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalHudScreenEffectDefinitionBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(16);
            maskFullscreen = binaryReader.ReadTagReference();
            maskSplitscreen = binaryReader.ReadTagReference();
            invalidName_2 = binaryReader.ReadBytes(8);
            invalidName_3 = binaryReader.ReadBytes(20);
            invalidName_4 = binaryReader.ReadBytes(24);
            invalidName_5 = binaryReader.ReadBytes(8);
            invalidName_6 = binaryReader.ReadBytes(24);
            invalidName_7 = binaryReader.ReadBytes(20);
            invalidName_8 = binaryReader.ReadBytes(24);
            screenEffectFlags = (ScreenEffectFlags)binaryReader.ReadInt32();
            invalidName_9 = binaryReader.ReadBytes(32);
            screenEffect = binaryReader.ReadTagReference();
            invalidName_10 = binaryReader.ReadBytes(32);
            screenEffectFlags0 = (ScreenEffectFlags)binaryReader.ReadInt32();
            invalidName_11 = binaryReader.ReadBytes(32);
            screenEffect0 = binaryReader.ReadTagReference();
            invalidName_12 = binaryReader.ReadBytes(32);
        }
        public  GlobalHudScreenEffectDefinitionBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 16);
                binaryWriter.Write(maskFullscreen);
                binaryWriter.Write(maskSplitscreen);
                binaryWriter.Write(invalidName_2, 0, 8);
                binaryWriter.Write(invalidName_3, 0, 20);
                binaryWriter.Write(invalidName_4, 0, 24);
                binaryWriter.Write(invalidName_5, 0, 8);
                binaryWriter.Write(invalidName_6, 0, 24);
                binaryWriter.Write(invalidName_7, 0, 20);
                binaryWriter.Write(invalidName_8, 0, 24);
                binaryWriter.Write((Int32)screenEffectFlags);
                binaryWriter.Write(invalidName_9, 0, 32);
                binaryWriter.Write(screenEffect);
                binaryWriter.Write(invalidName_10, 0, 32);
                binaryWriter.Write((Int32)screenEffectFlags0);
                binaryWriter.Write(invalidName_11, 0, 32);
                binaryWriter.Write(screenEffect0);
                binaryWriter.Write(invalidName_12, 0, 32);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        {
            OnlyWhenZoomed = 1,
            MirrorHorizontally = 2,
            MirrorVertically = 4,
            UseNewHotness = 8,
        };
        [FlagsAttribute]
        internal enum ScreenEffectFlags : int
        {
            OnlyWhenZoomed = 1,
        };
        [FlagsAttribute]
        internal enum ScreenEffectFlags0 : int
        {
            OnlyWhenZoomed = 1,
        };
    };
}
