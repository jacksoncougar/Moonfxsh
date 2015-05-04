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
    public partial class ShaderPostprocessColorBlock : ShaderPostprocessColorBlockBase
    {
        public ShaderPostprocessColorBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 13, Alignment = 4)]
    public class ShaderPostprocessColorBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal Moonfish.Tags.ColourR8G8B8 color;

        public override int SerializedSize
        {
            get { return 13; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessColorBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterIndex = binaryReader.ReadByte();
            color = binaryReader.ReadColorR8G8B8();
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
                binaryWriter.Write(color);
                return nextAddress;
            }
        }
    };
}