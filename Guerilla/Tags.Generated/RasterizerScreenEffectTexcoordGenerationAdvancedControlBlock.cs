// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock : RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase
    {
        public  RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 72, Alignment = 4)]
    public class RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase : GuerillaBlock
    {
        internal Stage0Flags stage0Flags;
        internal Stage1Flags stage1Flags;
        internal Stage2Flags stage2Flags;
        internal Stage3Flags stage3Flags;
        internal OpenTK.Vector4 stage0Offset;
        internal OpenTK.Vector4 stage1Offset;
        internal OpenTK.Vector4 stage2Offset;
        internal OpenTK.Vector4 stage3Offset;
        
        public override int SerializedSize{get { return 72; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stage0Flags = (Stage0Flags)binaryReader.ReadInt16();
            stage1Flags = (Stage1Flags)binaryReader.ReadInt16();
            stage2Flags = (Stage2Flags)binaryReader.ReadInt16();
            stage3Flags = (Stage3Flags)binaryReader.ReadInt16();
            stage0Offset = binaryReader.ReadVector4();
            stage1Offset = binaryReader.ReadVector4();
            stage2Offset = binaryReader.ReadVector4();
            stage3Offset = binaryReader.ReadVector4();
        }
        public  RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)stage0Flags);
                binaryWriter.Write((Int16)stage1Flags);
                binaryWriter.Write((Int16)stage2Flags);
                binaryWriter.Write((Int16)stage3Flags);
                binaryWriter.Write(stage0Offset);
                binaryWriter.Write(stage1Offset);
                binaryWriter.Write(stage2Offset);
                binaryWriter.Write(stage3Offset);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum Stage0Flags : short
        {
            XyScaledByZFar = 1,
        };
        [FlagsAttribute]
        internal enum Stage1Flags : short
        {
            XyScaledByZFar = 1,
        };
        [FlagsAttribute]
        internal enum Stage2Flags : short
        {
            XyScaledByZFar = 1,
        };
        [FlagsAttribute]
        internal enum Stage3Flags : short
        {
            XyScaledByZFar = 1,
        };
    };
}
