using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [TagClassAttribute("mcsr")]
    public  partial class MouseCursorDefinitionBlock : MouseCursorDefinitionBlockBase
    {
        public  MouseCursorDefinitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class MouseCursorDefinitionBlockBase
    {
        internal MouseCursorBitmapReferenceBlock[] mouseCursorBitmaps;
        internal float animationSpeedFps;
        internal  MouseCursorDefinitionBlockBase(BinaryReader binaryReader)
        {
            this.mouseCursorBitmaps = ReadMouseCursorBitmapReferenceBlockArray(binaryReader);
            this.animationSpeedFps = binaryReader.ReadSingle();
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
        internal  virtual MouseCursorBitmapReferenceBlock[] ReadMouseCursorBitmapReferenceBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(MouseCursorBitmapReferenceBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new MouseCursorBitmapReferenceBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new MouseCursorBitmapReferenceBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
