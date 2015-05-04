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
    public partial class ShaderStateConstantBlock : ShaderStateConstantBlockBase
    {
        public ShaderStateConstantBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ShaderStateConstantBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent sourceParameter;
        internal byte[] invalidName_;
        internal Constant constant;
        public override int SerializedSize { get { return 8; } }
        public override int Alignment { get { return 4; } }
        public ShaderStateConstantBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sourceParameter = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            constant = (Constant)binaryReader.ReadInt16();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(sourceParameter);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write((Int16)constant);
                return nextAddress;
            }
        }
        internal enum Constant : short
        {
            ConstantBlendColor = 0,
            ConstantBlendAlphaValue = 1,
            AlphaTestRefValue = 2,
            DepthBiasSlopeScaleValue = 3,
            DepthBiasValue = 4,
            LineWidthValue = 5,
            FogColor = 6,
        };
    };
}
