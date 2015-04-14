using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GlobalHudScreenEffectDefinition : GlobalHudScreenEffectDefinitionBase
    {
        public  GlobalHudScreenEffectDefinition(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 320)]
    public class GlobalHudScreenEffectDefinitionBase
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
        internal  GlobalHudScreenEffectDefinitionBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(16);
            this.maskFullscreen = binaryReader.ReadTagReference();
            this.maskSplitscreen = binaryReader.ReadTagReference();
            this.invalidName_2 = binaryReader.ReadBytes(8);
            this.invalidName_3 = binaryReader.ReadBytes(20);
            this.invalidName_4 = binaryReader.ReadBytes(24);
            this.invalidName_5 = binaryReader.ReadBytes(8);
            this.invalidName_6 = binaryReader.ReadBytes(24);
            this.invalidName_7 = binaryReader.ReadBytes(20);
            this.invalidName_8 = binaryReader.ReadBytes(24);
            this.screenEffectFlags = (ScreenEffectFlags)binaryReader.ReadInt32();
            this.invalidName_9 = binaryReader.ReadBytes(32);
            this.screenEffect = binaryReader.ReadTagReference();
            this.invalidName_10 = binaryReader.ReadBytes(32);
            this.screenEffectFlags0 = (ScreenEffectFlags)binaryReader.ReadInt32();
            this.invalidName_11 = binaryReader.ReadBytes(32);
            this.screenEffect0 = binaryReader.ReadTagReference();
            this.invalidName_12 = binaryReader.ReadBytes(32);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
