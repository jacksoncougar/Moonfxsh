using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class EffectAccelerationsBlock : EffectAccelerationsBlockBase
    {
        public  EffectAccelerationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class EffectAccelerationsBlockBase
    {
        internal CreateIn createIn;
        internal CreateIn createIn0;
        internal Moonfish.Tags.ShortBlockIndex1 location;
        internal byte[] invalidName_;
        internal float acceleration;
        internal float innerConeAngleDegrees;
        internal float outerConeAngleDegrees;
        internal  EffectAccelerationsBlockBase(BinaryReader binaryReader)
        {
            this.createIn = (CreateIn)binaryReader.ReadInt16();
            this.createIn0 = (CreateIn)binaryReader.ReadInt16();
            this.location = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.acceleration = binaryReader.ReadSingle();
            this.innerConeAngleDegrees = binaryReader.ReadSingle();
            this.outerConeAngleDegrees = binaryReader.ReadSingle();
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
        internal enum CreateIn : short
        
        {
            AnyEnvironment = 0,
            AirOnly = 1,
            WaterOnly = 2,
            SpaceOnly = 3,
        };
        internal enum CreateIn0 : short
        
        {
            EitherMode = 0,
            ViolentModeOnly = 1,
            NonviolentModeOnly = 2,
        };
    };
}
