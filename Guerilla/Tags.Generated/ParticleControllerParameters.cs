// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleControllerParameters : ParticleControllerParametersBase
    {
        public ParticleControllerParameters() : base()
        {
        }
    };

    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ParticleControllerParametersBase : GuerillaBlock
    {
        internal int parameterId;
        internal ParticlePropertyScalarStructNewBlock property;

        public override int SerializedSize
        {
            get { return 20; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ParticleControllerParametersBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            parameterId = binaryReader.ReadInt32();
            property = new ParticlePropertyScalarStructNewBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(property.ReadFields(binaryReader)));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            property.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(parameterId);
                property.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}