// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class UserHintJumpBlock : UserHintJumpBlockBase
    {
        public  UserHintJumpBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class UserHintJumpBlockBase
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 geometryIndex;
        internal ForceJumpHeight forceJumpHeight;
        internal ControlFlags controlFlags;
        internal  UserHintJumpBlockBase(System.IO.BinaryReader binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            geometryIndex = binaryReader.ReadShortBlockIndex1();
            forceJumpHeight = (ForceJumpHeight)binaryReader.ReadInt16();
            controlFlags = (ControlFlags)binaryReader.ReadInt16();
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
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(geometryIndex);
                binaryWriter.Write((Int16)forceJumpHeight);
                binaryWriter.Write((Int16)controlFlags);
            }
        }
        [FlagsAttribute]
        internal enum Flags : short
        
        {
            Bidirectional = 1,
            Closed = 2,
        };
        internal enum ForceJumpHeight : short
        
        {
            NONE = 0,
            Down = 1,
            Step = 2,
            Crouch = 3,
            Stand = 4,
            Storey = 5,
            Tower = 6,
            Infinite = 7,
        };
        [FlagsAttribute]
        internal enum ControlFlags : short
        
        {
            MagicLift = 1,
        };
    };
}
