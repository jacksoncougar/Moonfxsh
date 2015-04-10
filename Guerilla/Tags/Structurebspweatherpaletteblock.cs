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
        public  StructureBspWeatherPaletteBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspWeatherPaletteBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadString32();
            this.weatherSystem = binaryReader.ReadTagReference();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.invalidName_1 = binaryReader.ReadBytes(32);
            this.wind = binaryReader.ReadTagReference();
            this.windDirection = binaryReader.ReadVector3();
            this.windMagnitude = binaryReader.ReadSingle();
            this.invalidName_2 = binaryReader.ReadBytes(4);
            this.windScaleFunction = binaryReader.ReadString32();
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
    };
}
