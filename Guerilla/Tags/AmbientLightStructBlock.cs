using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AmbientLightStructBlock : AmbientLightStructBlockBase
    {
        public  AmbientLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class AmbientLightStructBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 minLightmapSample;
        internal Moonfish.Tags.ColorR8G8B8 maxLightmapSample;
        internal MappingFunctionBlock function;
        internal  AmbientLightStructBlockBase(BinaryReader binaryReader)
        {
            this.minLightmapSample = binaryReader.ReadColorR8G8B8();
            this.maxLightmapSample = binaryReader.ReadColorR8G8B8();
            this.function = new MappingFunctionBlock(binaryReader);
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
