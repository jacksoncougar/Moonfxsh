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
    public partial class RenderStateParameterBlock : RenderStateParameterBlockBase
    {
        public RenderStateParameterBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 3, Alignment = 4)]
    public class RenderStateParameterBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte parameterType;
        internal byte stateIndex;

        public override int SerializedSize
        {
            get { return 3; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderStateParameterBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterIndex = binaryReader.ReadByte();
            parameterType = binaryReader.ReadByte();
            stateIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(parameterIndex);
                binaryWriter.Write(parameterType);
                binaryWriter.Write(stateIndex);
                return nextAddress;
            }
        }
    };
}