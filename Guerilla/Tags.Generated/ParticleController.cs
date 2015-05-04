// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleController : ParticleControllerBase
    {
        public  ParticleController(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ParticleController(): base()
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
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ParticleControllerBase(BinaryReader binaryReader): base(binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            parameters = Guerilla.ReadBlockArray<ParticleControllerParameters>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
        }
        public  ParticleControllerBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            type = (Type)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
            parameters = Guerilla.ReadBlockArray<ParticleControllerParameters>(binaryReader);
            invalidName_0 = binaryReader.ReadBytes(8);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
