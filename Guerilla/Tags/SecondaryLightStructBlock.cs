using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SecondaryLightStructBlock : SecondaryLightStructBlockBase
    {
        public  SecondaryLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 60)]
    public class SecondaryLightStructBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 minLightmapColor;
        internal Moonfish.Tags.ColorR8G8B8 maxLightmapColor;
        internal Moonfish.Tags.ColorR8G8B8 minDiffuseSample;
        internal Moonfish.Tags.ColorR8G8B8 maxDiffuseSample;
        /// <summary>
        /// degrees
        /// </summary>
        internal float zAxisRotation;
        internal MappingFunctionBlock function;
        internal  SecondaryLightStructBlockBase(BinaryReader binaryReader)
        {
            this.minLightmapColor = binaryReader.ReadColorR8G8B8();
            this.maxLightmapColor = binaryReader.ReadColorR8G8B8();
            this.minDiffuseSample = binaryReader.ReadColorR8G8B8();
            this.maxDiffuseSample = binaryReader.ReadColorR8G8B8();
            this.zAxisRotation = binaryReader.ReadSingle();
            this.function = new MappingFunctionBlock(binaryReader);
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
