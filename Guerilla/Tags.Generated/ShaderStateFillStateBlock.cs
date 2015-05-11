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
    public partial class ShaderStateFillStateBlock : ShaderStateFillStateBlockBase
    {
        public ShaderStateFillStateBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderStateFillStateBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal FillMode fillMode;
        internal BackFillMode backFillMode;
        internal byte[] invalidName_;
        internal float lineWidth;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderStateFillStateBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            flags = (Flags) binaryReader.ReadInt16();
            fillMode = (FillMode) binaryReader.ReadInt16();
            backFillMode = (BackFillMode) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            lineWidth = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write((Int16) fillMode);
                binaryWriter.Write((Int16) backFillMode);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(lineWidth);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            FlatShading = 1,
            EdgeAntialiasing = 2,
        };

        internal enum FillMode : short
        {
            Solid = 0,
            Wireframe = 1,
            Points = 2,
        };

        internal enum BackFillMode : short
        {
            Solid = 0,
            Wireframe = 1,
            Points = 2,
        };
    };
}