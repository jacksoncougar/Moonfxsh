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
        public  LiquidCoreBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  LiquidCoreBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(12);
            this.bitmapIndex = binaryReader.ReadInt16();
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.thickness = new ScalarFunctionStructBlock(binaryReader);
            this.color = new ColorFunctionStructBlock(binaryReader);
            this.brightnessTime = new ScalarFunctionStructBlock(binaryReader);
            this.brightnessFacing = new ScalarFunctionStructBlock(binaryReader);
            this.alongAxisScale = new ScalarFunctionStructBlock(binaryReader);
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
    };
}
