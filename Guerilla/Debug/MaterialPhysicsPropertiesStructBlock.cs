// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class MaterialPhysicsPropertiesStructBlock : MaterialPhysicsPropertiesStructBlockBase
    {
        public  MaterialPhysicsPropertiesStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class MaterialPhysicsPropertiesStructBlockBase
    {
        internal byte[] invalidName_;
        internal float friction;
        internal float restitution;
        internal float densityKgM3;
        internal  MaterialPhysicsPropertiesStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            friction = binaryReader.ReadSingle();
            restitution = binaryReader.ReadSingle();
            densityKgM3 = binaryReader.ReadSingle();
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
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(friction);
                binaryWriter.Write(restitution);
                binaryWriter.Write(densityKgM3);
            }
        }
    };
}
