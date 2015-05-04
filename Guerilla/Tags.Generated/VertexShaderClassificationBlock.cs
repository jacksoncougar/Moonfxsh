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
    public partial class VertexShaderClassificationBlock : VertexShaderClassificationBlockBase
    {
        public VertexShaderClassificationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 28, Alignment = 4)]
    public class VertexShaderClassificationBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal short[] compiledShader;
        internal byte[] code;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 28; } }
        public override int Alignment { get { return 4; } }
        public VertexShaderClassificationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 2));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            invalidName_0 = binaryReader.ReadBytes(8);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
            invalidName_[2].ReadPointers(binaryReader, blamPointers);
            invalidName_[3].ReadPointers(binaryReader, blamPointers);
            compiledShader = ReadDataShortArray(binaryReader, blamPointers.Dequeue());
            code = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            invalidName_0[0].ReadPointers(binaryReader, blamPointers);
            invalidName_0[1].ReadPointers(binaryReader, blamPointers);
            invalidName_0[2].ReadPointers(binaryReader, blamPointers);
            invalidName_0[3].ReadPointers(binaryReader, blamPointers);
            invalidName_0[4].ReadPointers(binaryReader, blamPointers);
            invalidName_0[5].ReadPointers(binaryReader, blamPointers);
            invalidName_0[6].ReadPointers(binaryReader, blamPointers);
            invalidName_0[7].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                nextAddress = Guerilla.WriteData(binaryWriter, compiledShader, nextAddress);
                nextAddress = Guerilla.WriteData(binaryWriter, code, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 8);
                return nextAddress;
            }
        }
    };
}
