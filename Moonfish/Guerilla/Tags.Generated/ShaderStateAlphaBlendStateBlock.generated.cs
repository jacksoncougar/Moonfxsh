//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using JetBrains.Annotations;
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    [JetBrains.Annotations.UsedImplicitlyAttribute(ImplicitUseTargetFlags.WithMembers)]
    [TagBlockOriginalNameAttribute("shader_state_alpha_blend_state_block")]
    public partial class ShaderStateAlphaBlendStateBlock : GuerillaBlock, IWriteDeferrable
    {
        public BlendFunctionEnum BlendFunction;
        public BlendSrcFactorEnum BlendSrcFactor;
        public BlendDstFactorEnum BlendDstFactor;
        private byte[] fieldpad = new byte[2];
        public Moonfish.Tags.ColourA1R1G1B1 BlendColor;
        public LogicopFlags ShaderStateAlphaBlendStateLogicopFlags;
        private byte[] fieldpad0 = new byte[2];
        public override int SerializedSize
        {
            get
            {
                return 16;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(Moonfish.Guerilla.BlamBinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.BlendFunction = ((BlendFunctionEnum)(binaryReader.ReadInt16()));
            this.BlendSrcFactor = ((BlendSrcFactorEnum)(binaryReader.ReadInt16()));
            this.BlendDstFactor = ((BlendDstFactorEnum)(binaryReader.ReadInt16()));
            this.fieldpad = binaryReader.ReadBytes(2);
            this.BlendColor = binaryReader.ReadColourA1R1G1B1();
            this.ShaderStateAlphaBlendStateLogicopFlags = ((LogicopFlags)(binaryReader.ReadInt16()));
            this.fieldpad0 = binaryReader.ReadBytes(2);
            return pointerQueue;
        }
        public override void ReadInstances(Moonfish.Guerilla.BlamBinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void DeferReferences(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.DeferReferences(queueableBinaryWriter);
        }
        public override void Write(Moonfish.Guerilla.LinearBinaryWriter queueableBinaryWriter)
        {
            base.Write(queueableBinaryWriter);
            queueableBinaryWriter.Write(((short)(this.BlendFunction)));
            queueableBinaryWriter.Write(((short)(this.BlendSrcFactor)));
            queueableBinaryWriter.Write(((short)(this.BlendDstFactor)));
            queueableBinaryWriter.Write(this.fieldpad);
            queueableBinaryWriter.Write(this.BlendColor);
            queueableBinaryWriter.Write(((short)(this.ShaderStateAlphaBlendStateLogicopFlags)));
            queueableBinaryWriter.Write(this.fieldpad0);
        }
        public enum BlendFunctionEnum : short
        {
            Add = 0,
            Subtract = 1,
            ReverseSubtract = 2,
            Min = 3,
            Max = 4,
            AddSigned = 5,
            ReverseSubtractSigned = 6,
            Logicop = 7,
        }
        public enum BlendSrcFactorEnum : short
        {
            Zero = 0,
            One = 1,
            Srccolor = 2,
            SrccolorInverse = 3,
            Srcalpha = 4,
            SrcalphaInverse = 5,
            Dstcolor = 6,
            DstcolorInverse = 7,
            Dstalpha = 8,
            DstalphaInverse = 9,
            SrcalphaSaturate = 10,
            ConstantColor = 11,
            ConstantColorInverse = 12,
            ConstantAlpha = 13,
            ConstantAlphaInverse = 14,
        }
        public enum BlendDstFactorEnum : short
        {
            Zero = 0,
            One = 1,
            Srccolor = 2,
            SrccolorInverse = 3,
            Srcalpha = 4,
            SrcalphaInverse = 5,
            Dstcolor = 6,
            DstcolorInverse = 7,
            Dstalpha = 8,
            DstalphaInverse = 9,
            SrcalphaSaturate = 10,
            ConstantColor = 11,
            ConstantColorInverse = 12,
            ConstantAlpha = 13,
            ConstantAlphaInverse = 14,
        }
        [System.FlagsAttribute()]
        public enum LogicopFlags : short
        {
            None = 0,
            Src0Dst0 = 1,
            Src0Dst1 = 2,
            Src1Dst0 = 4,
            Src1Dst1 = 8,
        }
    }
}
