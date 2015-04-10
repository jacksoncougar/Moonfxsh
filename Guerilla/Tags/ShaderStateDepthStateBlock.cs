using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderStateDepthStateBlock : ShaderStateDepthStateBlockBase
    {
        public  ShaderStateDepthStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ShaderStateDepthStateBlockBase
    {
        internal Mode mode;
        internal DepthCompareFunction depthCompareFunction;
        internal Flags flags;
        internal byte[] invalidName_;
        internal float depthBiasSlopeScale;
        internal float depthBias;
        internal  ShaderStateDepthStateBlockBase(BinaryReader binaryReader)
        {
            this.mode = (Mode)binaryReader.ReadInt16();
            this.depthCompareFunction = (DepthCompareFunction)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.depthBiasSlopeScale = binaryReader.ReadSingle();
            this.depthBias = binaryReader.ReadSingle();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
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
