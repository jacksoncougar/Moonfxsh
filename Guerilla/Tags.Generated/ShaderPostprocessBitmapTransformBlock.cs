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
    public partial class ShaderPostprocessBitmapTransformBlock : ShaderPostprocessBitmapTransformBlockBase
    {
        public ShaderPostprocessBitmapTransformBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 6, Alignment = 4)]
    public class ShaderPostprocessBitmapTransformBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte bitmapTransformIndex;
        internal float value;

        public override int SerializedSize
        {
            get { return 6; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessBitmapTransformBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterIndex = binaryReader.ReadByte();
            bitmapTransformIndex = binaryReader.ReadByte();
            value = binaryReader.ReadSingle();
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
                binaryWriter.Write(bitmapTransformIndex);
                binaryWriter.Write(value);
                return nextAddress;
            }
        }
    };
}