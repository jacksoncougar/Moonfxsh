using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class PrimaryLightStructBlock : PrimaryLightStructBlockBase
    {
        public  PrimaryLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36)]
    public class PrimaryLightStructBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 minLightmapColor;
        internal Moonfish.Tags.ColorR8G8B8 maxLightmapColor;
        /// <summary>
        /// degrees from up the direct light cannot be
        /// </summary>
        internal float exclusionAngleFromUp;
        internal MappingFunctionBlock function;
        internal  PrimaryLightStructBlockBase(BinaryReader binaryReader)
        {
            this.minLightmapColor = binaryReader.ReadColorR8G8B8();
            this.maxLightmapColor = binaryReader.ReadColorR8G8B8();
            this.exclusionAngleFromUp = binaryReader.ReadSingle();
            this.function = new MappingFunctionBlock(binaryReader);
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
    };
}
