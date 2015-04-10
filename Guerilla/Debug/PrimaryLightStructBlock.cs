// ReSharper disable All
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
        public  PrimaryLightStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  PrimaryLightStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            minLightmapColor = binaryReader.ReadColorR8G8B8();
            maxLightmapColor = binaryReader.ReadColorR8G8B8();
            exclusionAngleFromUp = binaryReader.ReadSingle();
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
                binaryWriter.Write(minLightmapColor);
                binaryWriter.Write(maxLightmapColor);
                binaryWriter.Write(exclusionAngleFromUp);
                function.Write(binaryWriter);
            }
        }
    };
}
