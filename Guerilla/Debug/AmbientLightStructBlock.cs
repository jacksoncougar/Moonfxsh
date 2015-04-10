// ReSharper disable All
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
        public  AmbientLightStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class AmbientLightStructBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 minLightmapSample;
        internal Moonfish.Tags.ColorR8G8B8 maxLightmapSample;
        internal MappingFunctionBlock function;
        internal  AmbientLightStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            minLightmapSample = binaryReader.ReadColorR8G8B8();
            maxLightmapSample = binaryReader.ReadColorR8G8B8();
            function = new MappingFunctionBlock(binaryReader);
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
                binaryWriter.Write(minLightmapSample);
                binaryWriter.Write(maxLightmapSample);
                function.Write(binaryWriter);
            }
        }
    };
}
