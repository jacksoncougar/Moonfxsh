// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class UserHintJumpBlock : UserHintJumpBlockBase
    {
        public  UserHintJumpBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  UserHintJumpBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class UserHintJumpBlockBase : GuerillaBlock
    {
        internal Flags flags;
        internal Moonfish.Tags.ShortBlockIndex1 geometryIndex;
        internal ForceJumpHeight forceJumpHeight;
        internal ControlFlags controlFlags;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  UserHintJumpBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            flags = (Flags)binaryReader.ReadInt16();
            geometryIndex = binaryReader.ReadShortBlockIndex1();
            forceJumpHeight = (ForceJumpHeight)binaryReader.ReadInt16();
            controlFlags = (ControlFlags)binaryReader.ReadInt16();
        }
        public  UserHintJumpBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int16)flags);
                binaryWriter.Write(geometryIndex);
                binaryWriter.Write((Int16)forceJumpHeight);
                binaryWriter.Write((Int16)controlFlags);
                return nextAddress;
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
