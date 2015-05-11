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
    public partial class ShaderPassVertexShaderConstantBlock : ShaderPassVertexShaderConstantBlockBase
    {
        public ShaderPassVertexShaderConstantBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class ShaderPassVertexShaderConstantBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent sourceParameter;
        internal ScaleByTextureStage scaleByTextureStage;
        internal RegisterBank registerBank;
        internal short registerIndex;
        internal ComponentMask componentMask;

        public override int SerializedSize
        {
            get { return 12; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ShaderPassVertexShaderConstantBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            sourceParameter = binaryReader.ReadStringID();
            scaleByTextureStage = (ScaleByTextureStage) binaryReader.ReadInt16();
            registerBank = (RegisterBank) binaryReader.ReadInt16();
            registerIndex = binaryReader.ReadInt16();
            componentMask = (ComponentMask) binaryReader.ReadInt16();
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
                binaryWriter.Write(sourceParameter);
                binaryWriter.Write((Int16) scaleByTextureStage);
                binaryWriter.Write((Int16) registerBank);
                binaryWriter.Write(registerIndex);
                binaryWriter.Write((Int16) componentMask);
                return nextAddress;
            }
        }

        internal enum ScaleByTextureStage : short
        {
            None = 0,
            Stage0 = 1,
            Stage1 = 2,
            Stage2 = 3,
            Stage3 = 4,
        };

        internal enum RegisterBank : short
        {
            Vn015 = 0,
            Cn012 = 1,
        };

        internal enum ComponentMask : short
        {
            XValue = 0,
            YValue = 1,
            ZValue = 2,
            WValue = 3,
            XyzRgbColor = 4,
            XUniformScale = 5,
            YUniformScale = 6,
            ZUniformScale = 7,
            WUniformScale = 8,
            Xy2DScale = 9,
            Zw2DScale = 10,
            Xy2DTranslation = 11,
            Zw2DTranslation = 12,
            Xyzw2DSimpleXform = 13,
            XywRow12DAffineXform = 14,
            XywRow22DAffineXform = 15,
            Xyz3DScale = 16,
            Xyz3DTranslation = 17,
            XyzwRow13DAffineXform = 18,
            XyzwRow23DAffineXform = 19,
            XyzwRow33DAffineXform = 20,
        };
    };
}