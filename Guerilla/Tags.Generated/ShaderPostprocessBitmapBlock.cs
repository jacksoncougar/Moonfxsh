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
    public partial class ShaderPostprocessBitmapBlock : ShaderPostprocessBitmapBlockBase
    {
        public ShaderPostprocessBitmapBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 10, Alignment = 4)]
    public class ShaderPostprocessBitmapBlockBase : GuerillaBlock
    {
        internal byte parameterIndex;
        internal byte flags;
        internal int bitmapGroupIndex;
        internal float logBitmapDimension;

        public override int SerializedSize
        {
            get { return 10; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPostprocessBitmapBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterIndex = binaryReader.ReadByte();
            flags = binaryReader.ReadByte();
            bitmapGroupIndex = binaryReader.ReadInt32();
            logBitmapDimension = binaryReader.ReadSingle();
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
                binaryWriter.Write(flags);
                binaryWriter.Write(bitmapGroupIndex);
                binaryWriter.Write(logBitmapDimension);
                return nextAddress;
            }
        }
    };
}