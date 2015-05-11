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
    public partial class ShaderPassPostprocessConstantNewBlock : ShaderPassPostprocessConstantNewBlockBase
    {
        public ShaderPassPostprocessConstantNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 7, Alignment = 4)]
    public class ShaderPassPostprocessConstantNewBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent parameterName;
        internal byte componentMask;
        internal byte scaleByTextureStage;
        internal byte functionIndex;

        public override int SerializedSize
        {
            get { return 7; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPassPostprocessConstantNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterName = binaryReader.ReadStringID();
            componentMask = binaryReader.ReadByte();
            scaleByTextureStage = binaryReader.ReadByte();
            functionIndex = binaryReader.ReadByte();
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
                binaryWriter.Write(parameterName);
                binaryWriter.Write(componentMask);
                binaryWriter.Write(scaleByTextureStage);
                binaryWriter.Write(functionIndex);
                return nextAddress;
            }
        }
    };
}