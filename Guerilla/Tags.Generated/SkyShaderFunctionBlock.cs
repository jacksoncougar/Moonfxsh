// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class SkyShaderFunctionBlock : SkyShaderFunctionBlockBase
    {
        public  SkyShaderFunctionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 36, Alignment = 4)]
    public class SkyShaderFunctionBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        /// <summary>
        /// Global function that controls this shader value.
        /// </summary>
        internal Moonfish.Tags.String32 globalFunctionName;
        
        public override int SerializedSize{get { return 36; }}
        
        internal  SkyShaderFunctionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            globalFunctionName = binaryReader.ReadString32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(globalFunctionName);
                return nextAddress;
            }
        }
    };
}
