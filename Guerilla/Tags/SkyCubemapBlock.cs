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
    [LayoutAttribute(Size = 12)]
    public class SkyCubemapBlockBase
    {
        [TagReference("bitm")]
        internal Moonfish.Tags.TagReference cubeMapReference;
        /// <summary>
        /// 0 Defaults to 1.
        /// </summary>
        internal float powerScale;
        internal  SkyCubemapBlockBase(BinaryReader binaryReader)
        {
            this.cubeMapReference = binaryReader.ReadTagReference();
            this.powerScale = binaryReader.ReadSingle();
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
