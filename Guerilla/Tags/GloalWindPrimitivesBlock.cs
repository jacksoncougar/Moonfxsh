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
        public  GloalWindPrimitivesBlock(BinaryReader binaryReader): base(binaryReader)
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
        internal  GloalWindPrimitivesBlockBase(BinaryReader binaryReader)
        {
            this.position = binaryReader.ReadVector3();
            this.radius = binaryReader.ReadSingle();
            this.strength = binaryReader.ReadSingle();
            this.windPrimitiveType = (WindPrimitiveType)binaryReader.ReadInt16();
            this.invalidName_ = binaryReader.ReadBytes(2);
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
        internal enum WindPrimitiveType : short
        
        {
            Vortex = 0,
            Gust = 1,
            Implosion = 2,
            Explosion = 3,
        };
    };
}
