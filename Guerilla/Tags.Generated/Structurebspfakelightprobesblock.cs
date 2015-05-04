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
    public partial class StructureBspFakeLightprobesBlock : StructureBspFakeLightprobesBlockBase
    {
        public StructureBspFakeLightprobesBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class StructureBspFakeLightprobesBlockBase : GuerillaBlock
    {
        internal ScenarioObjectIdStructBlock objectIdentifier;
        internal RenderLightingStructBlock renderLighting;
        public override int SerializedSize { get { return 92; } }
        public override int Alignment { get { return 4; } }
        public StructureBspFakeLightprobesBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            objectIdentifier = new ScenarioObjectIdStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(objectIdentifier.ReadFields(binaryReader)));
            renderLighting = new RenderLightingStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(renderLighting.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            objectIdentifier.ReadPointers(binaryReader, blamPointers);
            renderLighting.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                objectIdentifier.Write(binaryWriter);
                renderLighting.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
