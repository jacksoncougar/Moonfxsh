// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class HudWidgetEffectBlock : HudWidgetEffectBlockBase
    {
        public  HudWidgetEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  HudWidgetEffectBlock(): base()
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
        
        public override int SerializedSize{get { return 104; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  HudWidgetEffectBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            hudWidgetEffectFunctionStruct = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct0 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct1 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct2 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct3 = new HudWidgetEffectFunctionStructBlock(binaryReader);
        }
        public  HudWidgetEffectBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            hudWidgetEffectFunctionStruct = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct0 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct1 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct2 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct3 = new HudWidgetEffectFunctionStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
