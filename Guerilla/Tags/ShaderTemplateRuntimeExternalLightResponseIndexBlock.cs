// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ShaderTemplateRuntimeExternalLightResponseIndexBlock : ShaderTemplateRuntimeExternalLightResponseIndexBlockBase
    {
        public  ShaderTemplateRuntimeExternalLightResponseIndexBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class ShaderTemplateRuntimeExternalLightResponseIndexBlockBase  : IGuerilla
    {
        internal int eMPTYSTRING;
        internal  ShaderTemplateRuntimeExternalLightResponseIndexBlockBase(BinaryReader binaryReader)
        {
            eMPTYSTRING = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(eMPTYSTRING);
                return nextAddress;
            }
        }
    };
}
