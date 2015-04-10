// ReSharper disable All
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
        public  HudWidgetEffectBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  HudWidgetEffectBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            hudWidgetEffectFunctionStruct = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct0 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct1 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct2 = new HudWidgetEffectFunctionStructBlock(binaryReader);
            hudWidgetEffectFunctionStruct3 = new HudWidgetEffectFunctionStructBlock(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
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
