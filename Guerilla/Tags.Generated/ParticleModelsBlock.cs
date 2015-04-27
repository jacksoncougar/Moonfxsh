// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ParticleModelsBlock : ParticleModelsBlockBase
    {
        public  ParticleModelsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ParticleModelsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class ParticleModelsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID modelName;
        internal short indexStart;
        internal short indexCount;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ParticleModelsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            modelName = binaryReader.ReadStringID();
            indexStart = binaryReader.ReadInt16();
            indexCount = binaryReader.ReadInt16();
        }
        public  ParticleModelsBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(modelName);
                binaryWriter.Write(indexStart);
                binaryWriter.Write(indexCount);
                return nextAddress;
            }
        }
    };
}
