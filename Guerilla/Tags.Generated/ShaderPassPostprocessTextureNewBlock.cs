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
    public partial class ShaderPassPostprocessTextureNewBlock : ShaderPassPostprocessTextureNewBlockBase
    {
        public ShaderPassPostprocessTextureNewBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderPassPostprocessTextureNewBlockBase : GuerillaBlock
    {
        internal byte bitmapParameterIndex;
        internal byte bitmapExternIndex;
        internal byte textureStageIndex;
        internal byte flags;

        public override int SerializedSize
        {
            get { return 4; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPassPostprocessTextureNewBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            bitmapParameterIndex = binaryReader.ReadByte();
            bitmapExternIndex = binaryReader.ReadByte();
            textureStageIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
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
                binaryWriter.Write(bitmapParameterIndex);
                binaryWriter.Write(bitmapExternIndex);
                binaryWriter.Write(textureStageIndex);
                binaryWriter.Write(flags);
                return nextAddress;
            }
        }
    };
}