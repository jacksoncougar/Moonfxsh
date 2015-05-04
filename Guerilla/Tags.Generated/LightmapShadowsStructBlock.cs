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
    public partial class LightmapShadowsStructBlock : LightmapShadowsStructBlockBase
    {
        public LightmapShadowsStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class LightmapShadowsStructBlockBase : GuerillaBlock
    {
        internal MappingFunctionBlock function1;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public LightmapShadowsStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            function1 = new MappingFunctionBlock();
            blamPointers.Concat(function1.ReadFields(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            function1.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                function1.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
