// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspWeatherPaletteBlock : StructureBspWeatherPaletteBlockBase
    {
        public  StructureBspWeatherPaletteBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 136)]
    public class StructureBspWeatherPaletteBlockBase
    {
        internal Moonfish.Tags.String32 name;
        [TagReference("weat")]
        internal Moonfish.Tags.TagReference weatherSystem;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        [TagReference("wind")]
        internal Moonfish.Tags.TagReference wind;
        internal OpenTK.Vector3 windDirection;
        internal float windMagnitude;
        internal byte[] invalidName_2;
        internal Moonfish.Tags.String32 windScaleFunction;
        internal  StructureBspWeatherPaletteBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadString32();
            weatherSystem = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            invalidName_1 = binaryReader.ReadBytes(32);
            wind = binaryReader.ReadTagReference();
            windDirection = binaryReader.ReadVector3();
            windMagnitude = binaryReader.ReadSingle();
            invalidName_2 = binaryReader.ReadBytes(4);
            windScaleFunction = binaryReader.ReadString32();
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
                binaryWriter.Write(name);
                binaryWriter.Write(weatherSystem);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                binaryWriter.Write(invalidName_1, 0, 32);
                binaryWriter.Write(wind);
                binaryWriter.Write(windDirection);
                binaryWriter.Write(windMagnitude);
                binaryWriter.Write(invalidName_2, 0, 4);
                binaryWriter.Write(windScaleFunction);
            }
        }
    };
}
