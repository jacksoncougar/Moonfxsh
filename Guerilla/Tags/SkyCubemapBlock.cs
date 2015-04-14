// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyCubemapBlock : SkyCubemapBlockBase
    {
        public  SkyCubemapBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class SkyCubemapBlockBase  : IGuerilla
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference cubeMapReference;
        /// <summary>
        /// 0 Defaults to 1.
        /// </summary>
        internal float powerScale;
        internal  SkyCubemapBlockBase(BinaryReader binaryReader)
        {
            cubeMapReference = binaryReader.ReadTagReference();
            powerScale = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(cubeMapReference);
                binaryWriter.Write(powerScale);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
