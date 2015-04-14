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
        public  MaterialPhysicsPropertiesStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class MaterialPhysicsPropertiesStructBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal float friction;
        internal float restitution;
        internal float densityKgM3;
        internal  MaterialPhysicsPropertiesStructBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(4);
            friction = binaryReader.ReadSingle();
            restitution = binaryReader.ReadSingle();
            densityKgM3 = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(friction);
                binaryWriter.Write(restitution);
                binaryWriter.Write(densityKgM3);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
