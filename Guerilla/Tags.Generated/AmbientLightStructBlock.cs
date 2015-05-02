// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AmbientLightStructBlock : AmbientLightStructBlockBase
    {
        public  AmbientLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AmbientLightStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class AmbientLightStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 minLightmapSample;
        internal Moonfish.Tags.ColourR8G8B8 maxLightmapSample;
        internal MappingFunctionBlock function;
        
        public override int SerializedSize{get { return 32; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AmbientLightStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            minLightmapSample = binaryReader.ReadColorR8G8B8();
            maxLightmapSample = binaryReader.ReadColorR8G8B8();
            function = new MappingFunctionBlock(binaryReader);
        }
        public  AmbientLightStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            minLightmapSample = binaryReader.ReadColorR8G8B8();
            maxLightmapSample = binaryReader.ReadColorR8G8B8();
            function = new MappingFunctionBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minLightmapSample);
                binaryWriter.Write(maxLightmapSample);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
