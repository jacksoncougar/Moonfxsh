// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AmbientLightStructBlock : AmbientLightStructBlockBase
    {
        public AmbientLightStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class AmbientLightStructBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ColourR8G8B8 minLightmapSample;
        internal Moonfish.Tags.ColourR8G8B8 maxLightmapSample;
        internal MappingFunctionBlock function;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public AmbientLightStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            minLightmapSample = binaryReader.ReadColorR8G8B8();
            maxLightmapSample = binaryReader.ReadColorR8G8B8();
            function = new MappingFunctionBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(function.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
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
