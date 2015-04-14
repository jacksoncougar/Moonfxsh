// ReSharper disable All
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
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class SpecialMovementBlockBase  : IGuerilla
    {
        internal SpecialMovement1 specialMovement1;
        internal  SpecialMovementBlockBase(BinaryReader binaryReader)
        {
            specialMovement1 = (SpecialMovement1)binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)specialMovement1);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
