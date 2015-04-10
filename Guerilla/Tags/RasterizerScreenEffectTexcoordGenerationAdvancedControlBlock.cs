using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock : RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase
    {
        public  RasterizerScreenEffectTexcoordGenerationAdvancedControlBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 72)]
    public class RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase
    {
        internal Stage0Flags stage0Flags;
        internal Stage1Flags stage1Flags;
        internal Stage2Flags stage2Flags;
        internal Stage3Flags stage3Flags;
        internal OpenTK.Vector4 stage0Offset;
        internal OpenTK.Vector4 stage1Offset;
        internal OpenTK.Vector4 stage2Offset;
        internal OpenTK.Vector4 stage3Offset;
        internal  RasterizerScreenEffectTexcoordGenerationAdvancedControlBlockBase(BinaryReader binaryReader)
        {
            this.stage0Flags = (Stage0Flags)binaryReader.ReadInt16();
            this.stage1Flags = (Stage1Flags)binaryReader.ReadInt16();
            this.stage2Flags = (Stage2Flags)binaryReader.ReadInt16();
            this.stage3Flags = (Stage3Flags)binaryReader.ReadInt16();
            this.stage0Offset = binaryReader.ReadVector4();
            this.stage1Offset = binaryReader.ReadVector4();
            this.stage2Offset = binaryReader.ReadVector4();
            this.stage3Offset = binaryReader.ReadVector4();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.count];
            if(blamPointer.count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.count);
                }
            }
            return data;
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
