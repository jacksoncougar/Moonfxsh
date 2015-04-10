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
    [LayoutAttribute(Size = 20)]
    public class ParticleControllerParametersBase
    {
        internal int parameterId;
        internal ParticlePropertyScalarStructNewBlock property;
        internal  ParticleControllerParametersBase(BinaryReader binaryReader)
        {
            this.parameterId = binaryReader.ReadInt32();
            this.property = new ParticlePropertyScalarStructNewBlock(binaryReader);
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
    };
}
