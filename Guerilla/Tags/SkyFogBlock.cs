using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SkyFogBlock : SkyFogBlockBase
    {
        public  SkyFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class SkyFogBlockBase
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        /// <summary>
        /// Fog density is clamped to this value.
        /// </summary>
        internal float density01;
        internal  SkyFogBlockBase(BinaryReader binaryReader)
        {
            this.color = binaryReader.ReadColorR8G8B8();
            this.density01 = binaryReader.ReadSingle();
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
