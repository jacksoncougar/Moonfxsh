// ReSharper disable All
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
        public  NewHudDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  NewHudDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            dONOTUSE = binaryReader.ReadTagReference();
            ReadHudBitmapWidgetsArray(binaryReader);
            ReadHudTextWidgetsArray(binaryReader);
            dashlightData = new NewHudDashlightDataStructBlock(binaryReader);
            ReadHudScreenEffectWidgetsArray(binaryReader);
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
        internal  virtual HudBitmapWidgets[] ReadHudBitmapWidgetsArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudBitmapWidgets));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudBitmapWidgets[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudBitmapWidgets(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudTextWidgets[] ReadHudTextWidgetsArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudTextWidgets));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudTextWidgets[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudTextWidgets(binaryReader);
                }
            }
            return array;
        }
        internal  virtual HudScreenEffectWidgets[] ReadHudScreenEffectWidgetsArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(HudScreenEffectWidgets));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new HudScreenEffectWidgets[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new HudScreenEffectWidgets(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudBitmapWidgetsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudTextWidgetsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteHudScreenEffectWidgetsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(dONOTUSE);
                WriteHudBitmapWidgetsArray(binaryWriter);
                WriteHudTextWidgetsArray(binaryWriter);
                dashlightData.Write(binaryWriter);
                WriteHudScreenEffectWidgetsArray(binaryWriter);
            }
        }
    };
}
