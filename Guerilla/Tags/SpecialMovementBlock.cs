using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class SpecialMovementBlock : SpecialMovementBlockBase
    {
        public  SpecialMovementBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class SpecialMovementBlockBase
    {
        internal SpecialMovement1 specialMovement1;
        internal  SpecialMovementBlockBase(BinaryReader binaryReader)
        {
            this.specialMovement1 = (SpecialMovement1)binaryReader.ReadInt32();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
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
        [FlagsAttribute]
        internal enum SpecialMovement1 : int
        
        {
            Jump = 1,
            Climb = 2,
            Vault = 4,
            Mount = 8,
            Hoist = 16,
            WallJump = 32,
            NA = 64,
        };
    };
}
