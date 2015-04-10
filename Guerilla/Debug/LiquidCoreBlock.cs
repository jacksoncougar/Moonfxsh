// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class LiquidCoreBlock : LiquidCoreBlockBase
    {
        public  LiquidCoreBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 56)]
    public class LiquidCoreBlockBase
    {
        internal byte[] invalidName_;
        internal short bitmapIndex;
        internal byte[] invalidName_0;
        internal ScalarFunctionStructBlock thickness;
        internal ColorFunctionStructBlock color;
        internal ScalarFunctionStructBlock brightnessTime;
        internal ScalarFunctionStructBlock brightnessFacing;
        internal ScalarFunctionStructBlock alongAxisScale;
        internal  LiquidCoreBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(12);
            bitmapIndex = binaryReader.ReadInt16();
            invalidName_0 = binaryReader.ReadBytes(2);
            thickness = new ScalarFunctionStructBlock(binaryReader);
            color = new ColorFunctionStructBlock(binaryReader);
            brightnessTime = new ScalarFunctionStructBlock(binaryReader);
            brightnessFacing = new ScalarFunctionStructBlock(binaryReader);
            alongAxisScale = new ScalarFunctionStructBlock(binaryReader);
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
                binaryWriter.Write(invalidName_, 0, 12);
                binaryWriter.Write(bitmapIndex);
                binaryWriter.Write(invalidName_0, 0, 2);
                thickness.Write(binaryWriter);
                color.Write(binaryWriter);
                brightnessTime.Write(binaryWriter);
                brightnessFacing.Write(binaryWriter);
                alongAxisScale.Write(binaryWriter);
            }
        }
    };
}
