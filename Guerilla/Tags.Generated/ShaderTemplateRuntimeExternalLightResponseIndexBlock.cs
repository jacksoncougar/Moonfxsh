// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ShaderTemplateRuntimeExternalLightResponseIndexBlock : ShaderTemplateRuntimeExternalLightResponseIndexBlockBase
    {
        public  ShaderTemplateRuntimeExternalLightResponseIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ShaderTemplateRuntimeExternalLightResponseIndexBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderTemplateRuntimeExternalLightResponseIndexBlockBase : GuerillaBlock
    {
        internal int eMPTYSTRING;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ShaderTemplateRuntimeExternalLightResponseIndexBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            eMPTYSTRING = binaryReader.ReadInt32();
        }
        public  ShaderTemplateRuntimeExternalLightResponseIndexBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            eMPTYSTRING = binaryReader.ReadInt32();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(eMPTYSTRING);
                return nextAddress;
            }
        }
    };
}
