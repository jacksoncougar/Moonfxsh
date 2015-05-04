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
    public partial class ShaderStateDepthStateBlock : ShaderStateDepthStateBlockBase
    {
        public ShaderStateDepthStateBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ShaderStateDepthStateBlockBase : GuerillaBlock
    {
        internal Mode mode;
        internal DepthCompareFunction depthCompareFunction;
        internal Flags flags;
        internal byte[] invalidName_;
        internal float depthBiasSlopeScale;
        internal float depthBias;
        public override int SerializedSize { get { return 16; } }
        public override int Alignment { get { return 4; } }
        public ShaderStateDepthStateBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            mode = (Mode)binaryReader.ReadInt16();
            depthCompareFunction = (DepthCompareFunction)binaryReader.ReadInt16();
            flags = (Flags)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            depthBiasSlopeScale = binaryReader.ReadSingle();
            depthBias = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            invalidName_[0].ReadPointers(binaryReader, blamPointers);
            invalidName_[1].ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)mode);
                binaryWriter.Write((Int16)depthCompareFunction);
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(depthBiasSlopeScale);
                binaryWriter.Write(depthBias);
                return nextAddress;
            }
        }
        internal enum Mode : short
        {
            UseZ = 0,
            UseW = 1,
        };
        internal enum DepthCompareFunction : short
        {
            Never = 0,
            Less = 1,
            Equal = 2,
            LessOrEqual = 3,
            Greater = 4,
            NotEqual = 5,
            GreaterOrEqual = 6,
            Always = 7,
        };
        [FlagsAttribute]
        internal enum Flags : short
        {
            DepthWrite = 1,
            OffsetPoints = 2,
            OffsetLines = 4,
            OffsetTriangles = 8,
            ClipControlDontCullPrimitive = 16,
            ClipControlClamp = 32,
            ClipControlIgnoreWSign = 64,
        };
    };
}
