// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class VertexShaderConstantBlock : VertexShaderConstantBlockBase
    {
        public VertexShaderConstantBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class VertexShaderConstantBlockBase : GuerillaBlock
    {
        internal byte registerIndex;
        internal byte parameterIndex;
        internal byte destinationMask;
        internal byte scaleByTextureStage;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public VertexShaderConstantBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            registerIndex = binaryReader.ReadByte();
            parameterIndex = binaryReader.ReadByte();
            destinationMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(registerIndex);
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(destinationMask);
                binaryWriter.Write(scaleByTextureStage);
                return nextAddress;
            }
        }
    };
}