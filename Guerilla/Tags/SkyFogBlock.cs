// ReSharper disable All
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
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SkyFogBlockBase  : IGuerilla
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        /// <summary>
        /// Fog density is clamped to this value.
        /// </summary>
        internal float density01;
        internal  SkyFogBlockBase(BinaryReader binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            density01 = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                binaryWriter.Write(density01);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
