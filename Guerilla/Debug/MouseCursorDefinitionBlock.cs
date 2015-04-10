// ReSharper disable All
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
        public  MouseCursorDefinitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12)]
    public class MouseCursorDefinitionBlockBase
    {
        internal MouseCursorBitmapReferenceBlock[] mouseCursorBitmaps;
        internal float animationSpeedFps;
        internal  MouseCursorDefinitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            ReadMouseCursorBitmapReferenceBlockArray(binaryReader);
            animationSpeedFps = binaryReader.ReadSingle();
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
        internal  virtual MouseCursorBitmapReferenceBlock[] ReadMouseCursorBitmapReferenceBlockArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteMouseCursorBitmapReferenceBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                WriteMouseCursorBitmapReferenceBlockArray(binaryWriter);
                binaryWriter.Write(animationSpeedFps);
            }
        }
    };
}
