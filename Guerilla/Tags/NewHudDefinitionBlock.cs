using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("nhdt")]
    public  partial class NewHudDefinitionBlock : NewHudDefinitionBlockBase
    {
        public  NewHudDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 40)]
    public class NewHudDefinitionBlockBase
    {
        [TagReference("nhdt")]
        internal Moonfish.Tags.TagReference dONOTUSE;
        internal HudBitmapWidgets[] bitmapWidgets;
        internal HudTextWidgets[] textWidgets;
        internal NewHudDashlightDataStructBlock dashlightData;
        internal HudScreenEffectWidgets[] screenEffectWidgets;
        internal  NewHudDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.dONOTUSE = binaryReader.ReadTagReference();
            this.bitmapWidgets = ReadHudBitmapWidgetsArray(binaryReader);
            this.textWidgets = ReadHudTextWidgetsArray(binaryReader);
            this.dashlightData = new NewHudDashlightDataStructBlock(binaryReader);
            this.screenEffectWidgets = ReadHudScreenEffectWidgetsArray(binaryReader);
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
        internal  virtual HudBitmapWidgets[] ReadHudBitmapWidgetsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudBitmapWidgets));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudBitmapWidgets[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudBitmapWidgets(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudTextWidgets[] ReadHudTextWidgetsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudTextWidgets));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudTextWidgets[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudTextWidgets(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudScreenEffectWidgets[] ReadHudScreenEffectWidgetsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudScreenEffectWidgets));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudScreenEffectWidgets[blamPointer.elementCount];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.elementCount; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudScreenEffectWidgets(binaryReader);
                }
            }
            return array;
        }
    };
}
