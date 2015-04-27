// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SecondaryLightStructBlock : SecondaryLightStructBlockBase
    {
        public  SecondaryLightStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  SecondaryLightStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class SecondaryLightStructBlockBase : GuerillaBlock
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
        
        public override int SerializedSize{get { return 60; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  SecondaryLightStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            minLightmapColor = binaryReader.ReadColorR8G8B8();
            maxLightmapColor = binaryReader.ReadColorR8G8B8();
            minDiffuseSample = binaryReader.ReadColorR8G8B8();
            maxDiffuseSample = binaryReader.ReadColorR8G8B8();
            zAxisRotation = binaryReader.ReadSingle();
            function = new MappingFunctionBlock(binaryReader);
        }
        public  SecondaryLightStructBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(minLightmapColor);
                binaryWriter.Write(maxLightmapColor);
                binaryWriter.Write(minDiffuseSample);
                binaryWriter.Write(maxDiffuseSample);
                binaryWriter.Write(zAxisRotation);
                function.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
