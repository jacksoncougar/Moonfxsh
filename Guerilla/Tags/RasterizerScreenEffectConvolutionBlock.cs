using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RasterizerScreenEffectConvolutionBlock : RasterizerScreenEffectConvolutionBlockBase
    {
        public  RasterizerScreenEffectConvolutionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class RasterizerScreenEffectConvolutionBlockBase
    {
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal float convolutionAmount0Inf;
        internal float filterScale;
        internal float filterBoxFactor01NotUsedForZoom;
        internal float zoomFalloffRadius;
        internal float zoomCutoffRadius;
        internal float resolutionScale01;
        internal  RasterizerScreenEffectConvolutionBlockBase(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(64);
            this.convolutionAmount0Inf = binaryReader.ReadSingle();
            this.filterScale = binaryReader.ReadSingle();
            this.filterBoxFactor01NotUsedForZoom = binaryReader.ReadSingle();
            this.zoomFalloffRadius = binaryReader.ReadSingle();
            this.zoomCutoffRadius = binaryReader.ReadSingle();
            this.resolutionScale01 = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            OnlyWhenPrimaryIsActive = 1,
            OnlyWhenSecondaryIsActive = 2,
            PredatorZoom = 4,
        };
    };
}
