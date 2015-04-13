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
        public  PrimaryLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class PrimaryLightStructBlockBase  : IGuerilla
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
            minLightmapColor = binaryReader.ReadColorR8G8B8();
            maxLightmapColor = binaryReader.ReadColorR8G8B8();
            exclusionAngleFromUp = binaryReader.ReadSingle();
            function = new MappingFunctionBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minLightmapColor);
                binaryWriter.Write(maxLightmapColor);
                binaryWriter.Write(exclusionAngleFromUp);
                function.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
