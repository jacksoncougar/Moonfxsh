// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class GloalWindPrimitivesBlock : GloalWindPrimitivesBlockBase
    {
        public  GloalWindPrimitivesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 24)]
    public class GloalWindPrimitivesBlockBase
    {
        internal OpenTK.Vector3 position;
        internal float radius;
        internal float strength;
        internal WindPrimitiveType windPrimitiveType;
        internal byte[] invalidName_;
        internal  GloalWindPrimitivesBlockBase(System.IO.BinaryReader binaryReader)
        {
            position = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
            strength = binaryReader.ReadSingle();
            windPrimitiveType = (WindPrimitiveType)binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(2);
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
                binaryWriter.Write(position);
                binaryWriter.Write(radius);
                binaryWriter.Write(strength);
                binaryWriter.Write((Int16)windPrimitiveType);
                binaryWriter.Write(invalidName_, 0, 2);
            }
        }
        internal enum WindPrimitiveType : short
        
        {
            Vortex = 0,
            Gust = 1,
            Implosion = 2,
            Explosion = 3,
        };
    };
}
