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
    public partial class ScenarioPlanarFogPalette : ScenarioPlanarFogPaletteBase
    {
        public ScenarioPlanarFogPalette() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ScenarioPlanarFogPaletteBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        [TagReference("fog ")]
        internal Moonfish.Tags.TagReference planarFog;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ScenarioPlanarFogPaletteBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            planarFog = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(planarFog);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                return nextAddress;
            }
        }
    };
}
