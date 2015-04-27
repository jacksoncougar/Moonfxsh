// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SkyFogBlock : SkyFogBlockBase
    {
        public  SkyFogBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SkyFogBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class SkyFogBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColorR8G8B8 color;
        /// <summary>
        /// Fog density is clamped to this value.
        /// </summary>
        internal float density01;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SkyFogBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            color = binaryReader.ReadColorR8G8B8();
            density01 = binaryReader.ReadSingle();
        }
        public  SkyFogBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(color);
                binaryWriter.Write(density01);
                return nextAddress;
            }
        }
    };
}
