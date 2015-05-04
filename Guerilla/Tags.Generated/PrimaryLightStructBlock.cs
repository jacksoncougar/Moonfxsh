// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PrimaryLightStructBlock : PrimaryLightStructBlockBase
    {
        public  PrimaryLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PrimaryLightStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class PrimaryLightStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 MinLightmapColour;
        internal Moonfish.Tags.ColourR8G8B8 MaxLightmapColour;
        /// <summary>
        /// degrees from up the direct light cannot be
        /// </summary>
        internal float exclusionAngleFromUp;
        internal MappingFunctionBlock function;
        
        public override int SerializedSize{get { return 36; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PrimaryLightStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            MinLightmapColour = binaryReader.ReadColorR8G8B8();
            MaxLightmapColour = binaryReader.ReadColorR8G8B8();
            exclusionAngleFromUp = binaryReader.ReadSingle();
            function = new MappingFunctionBlock(binaryReader);
        }
        public  PrimaryLightStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            MinLightmapColour = binaryReader.ReadColorR8G8B8();
            MaxLightmapColour = binaryReader.ReadColorR8G8B8();
            exclusionAngleFromUp = binaryReader.ReadSingle();
            function = new MappingFunctionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(MinLightmapColour);
                binaryWriter.Write(MaxLightmapColour);
                binaryWriter.Write(exclusionAngleFromUp);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
