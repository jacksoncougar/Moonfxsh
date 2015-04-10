using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class HudWidgetEffectBlock : HudWidgetEffectBlockBase
    {
        public  HudWidgetEffectBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 104)]
    public class HudWidgetEffectBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct0;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct1;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct2;
        internal HudWidgetEffectFunctionStructBlock hudWidgetEffectFunctionStruct3;
        internal  HudWidgetEffectBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.hudWidgetEffectFunctionStruct = new HudWidgetEffectFunctionStructBlock(binaryReader);
            this.hudWidgetEffectFunctionStruct0 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            this.hudWidgetEffectFunctionStruct1 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            this.hudWidgetEffectFunctionStruct2 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            this.hudWidgetEffectFunctionStruct3 = new HudWidgetEffectFunctionStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
