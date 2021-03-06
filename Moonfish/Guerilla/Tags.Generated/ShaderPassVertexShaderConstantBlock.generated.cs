//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Moonfish.Guerilla.Tags
{
    using Moonfish.Tags;
    using Moonfish.Model;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    
    public partial class ShaderPassVertexShaderConstantBlock : GuerillaBlock, IWriteQueueable
    {
        public Moonfish.Tags.StringIdent SourceParameter;
        public ScaleByTextureStageEnum ScaleByTextureStage;
        public RegisterBankEnum RegisterBank;
        public short RegisterIndex;
        public ComponentMaskEnum ComponentMask;
        public override int SerializedSize
        {
            get
            {
                return 12;
            }
        }
        public override int Alignment
        {
            get
            {
                return 4;
            }
        }
        public override System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> ReadFields(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue = new System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer>(base.ReadFields(binaryReader));
            this.SourceParameter = binaryReader.ReadStringID();
            this.ScaleByTextureStage = ((ScaleByTextureStageEnum)(binaryReader.ReadInt16()));
            this.RegisterBank = ((RegisterBankEnum)(binaryReader.ReadInt16()));
            this.RegisterIndex = binaryReader.ReadInt16();
            this.ComponentMask = ((ComponentMaskEnum)(binaryReader.ReadInt16()));
            return pointerQueue;
        }
        public override void ReadInstances(System.IO.BinaryReader binaryReader, System.Collections.Generic.Queue<Moonfish.Tags.BlamPointer> pointerQueue)
        {
            base.ReadInstances(binaryReader, pointerQueue);
        }
        public override void QueueWrites(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.QueueWrites(queueableBinaryWriter);
        }
        public override void Write_(Moonfish.Guerilla.QueueableBinaryWriter queueableBinaryWriter)
        {
            base.Write_(queueableBinaryWriter);
            queueableBinaryWriter.Write(this.SourceParameter);
            queueableBinaryWriter.Write(((short)(this.ScaleByTextureStage)));
            queueableBinaryWriter.Write(((short)(this.RegisterBank)));
            queueableBinaryWriter.Write(this.RegisterIndex);
            queueableBinaryWriter.Write(((short)(this.ComponentMask)));
        }
        public enum ScaleByTextureStageEnum : short
        {
            None = 0,
            Stage0 = 1,
            Stage1 = 2,
            Stage2 = 3,
            Stage3 = 4,
        }
        public enum RegisterBankEnum : short
        {
            Vn015 = 0,
            Cn012 = 1,
        }
        public enum ComponentMaskEnum : short
        {
            Xvalue = 0,
            Yvalue = 1,
            Zvalue = 2,
            Wvalue = 3,
            Xyzrgbcolor = 4,
            XuniformScale = 5,
            YuniformScale = 6,
            ZuniformScale = 7,
            WuniformScale = 8,
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
        }
    }
}
