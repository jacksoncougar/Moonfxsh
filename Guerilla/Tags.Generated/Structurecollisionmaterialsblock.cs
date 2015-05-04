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
    public partial class StructureCollisionMaterialsBlock : StructureCollisionMaterialsBlockBase
    {
        public StructureCollisionMaterialsBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class StructureCollisionMaterialsBlockBase : GuerillaBlock
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference oldShader;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 conveyorSurfaceIndex;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference newShader;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public StructureCollisionMaterialsBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            oldShader = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(2);
            conveyorSurfaceIndex = binaryReader.ReadShortBlockIndex1();
            newShader = binaryReader.ReadTagReference();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(oldShader);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(conveyorSurfaceIndex);
                binaryWriter.Write(newShader);
                return nextAddress;
            }
        }
    };
}
