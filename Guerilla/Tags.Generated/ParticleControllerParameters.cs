// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleControllerParameters : ParticleControllerParametersBase
    {
        public  ParticleControllerParameters(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ParticleControllerParameters(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ParticleControllerParametersBase : GuerillaBlock
    {
        internal int parameterId;
        internal ParticlePropertyScalarStructNewBlock property;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ParticleControllerParametersBase(BinaryReader binaryReader): base(binaryReader)
        {
            parameterId = binaryReader.ReadInt32();
            property = new ParticlePropertyScalarStructNewBlock(binaryReader);
        }
        public  ParticleControllerParametersBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
