// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ParticleModelsBlock : ParticleModelsBlockBase
    {
        public  ParticleModelsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class ParticleModelsBlockBase
    {
        internal Moonfish.Tags.StringID modelName;
        internal short indexStart;
        internal short indexCount;
        internal  ParticleModelsBlockBase(System.IO.BinaryReader binaryReader)
        {
            modelName = binaryReader.ReadStringID();
            indexStart = binaryReader.ReadInt16();
            indexCount = binaryReader.ReadInt16();
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(modelName);
                binaryWriter.Write(indexStart);
                binaryWriter.Write(indexCount);
            }
        }
    };
}
