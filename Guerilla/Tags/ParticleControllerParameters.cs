// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleControllerParameters : ParticleControllerParametersBase
    {
        public  ParticleControllerParameters(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ParticleControllerParametersBase  : IGuerilla
    {
        internal int parameterId;
        internal ParticlePropertyScalarStructNewBlock property;
        internal  ParticleControllerParametersBase(BinaryReader binaryReader)
        {
            parameterId = binaryReader.ReadInt32();
            property = new ParticlePropertyScalarStructNewBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterId);
                property.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
