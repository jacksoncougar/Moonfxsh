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
    public partial class GlobalGeometryMaterialBlock : GlobalGeometryMaterialBlockBase
    {
        public GlobalGeometryMaterialBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class GlobalGeometryMaterialBlockBase : GuerillaBlock
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference oldShader;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference shader;
        internal GlobalGeometryMaterialPropertyBlock[] properties;
        internal byte[] invalidName_;
        internal byte breakableSurfaceIndex;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 32; } }
        public override int Alignment { get { return 4; } }
        public GlobalGeometryMaterialBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            oldShader = binaryReader.ReadTagReference();
            shader = binaryReader.ReadTagReference();
            blamPointers.Enqueue(ReadBlockArrayPointer<GlobalGeometryMaterialPropertyBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            breakableSurfaceIndex = binaryReader.ReadByte();
            invalidName_0 = binaryReader.ReadBytes(3);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            properties = ReadBlockArrayData<GlobalGeometryMaterialPropertyBlock>(binaryReader, blamPointers.Dequeue());
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(oldShader);
                binaryWriter.Write(shader);
                nextAddress = Guerilla.WriteBlockArray<GlobalGeometryMaterialPropertyBlock>(binaryWriter, properties, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(breakableSurfaceIndex);
                binaryWriter.Write(invalidName_0, 0, 3);
                return nextAddress;
            }
        }
    };
}
