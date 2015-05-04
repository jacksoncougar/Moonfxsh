// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleController : ParticleControllerBase
    {
        public ParticleController() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class ParticleControllerBase : GuerillaBlock
    {
        internal Type type;
        internal byte[] invalidName_;
        internal ParticleControllerParameters[] parameters;
        internal byte[] invalidName_0;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public ParticleControllerBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<ParticleControllerParameters>(binaryReader));
            invalidName_0 = binaryReader.ReadBytes(8);
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            parameters = ReadBlockArrayData<ParticleControllerParameters>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)type);
                binaryWriter.Write(invalidName_, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<ParticleControllerParameters>(binaryWriter, parameters, nextAddress);
                binaryWriter.Write(invalidName_0, 0, 8);
                return nextAddress;
            }
        }
        internal enum Type : short
        {
            Physics = 0,
            Collider = 1,
            Swarm = 2,
            Wind = 3,
        };
    };
}
