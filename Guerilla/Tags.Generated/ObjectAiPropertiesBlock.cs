// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectAiPropertiesBlock : ObjectAiPropertiesBlockBase
    {
        public  ObjectAiPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  ObjectAiPropertiesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class ObjectAiPropertiesBlockBase : GuerillaBlock
    {
        internal AiFlags aiFlags;
        /// <summary>
        /// used for combat dialogue, etc.
        /// </summary>
        internal Moonfish.Tags.StringID aiTypeName;
        internal byte[] invalidName_;
        internal AiSize aiSize;
        internal LeapJumpSpeed leapJumpSpeed;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  ObjectAiPropertiesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            aiFlags = (AiFlags)binaryReader.ReadInt32();
            aiTypeName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            aiSize = (AiSize)binaryReader.ReadInt16();
            leapJumpSpeed = (LeapJumpSpeed)binaryReader.ReadInt16();
        }
        public  ObjectAiPropertiesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            aiFlags = (AiFlags)binaryReader.ReadInt32();
            aiTypeName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            aiSize = (AiSize)binaryReader.ReadInt16();
            leapJumpSpeed = (LeapJumpSpeed)binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32)aiFlags);
                binaryWriter.Write(aiTypeName);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int16)aiSize);
                binaryWriter.Write((Int16)leapJumpSpeed);
                return nextAddress;
            }
        }
        [FlagsAttribute]
        internal enum AiFlags : int
        {
            DetroyableCover = 1,
            PathfindingIgnoreWhenDead = 2,
            DynamicCover = 4,
        };
        internal enum AiSize : short
        {
            Default = 0,
            Tiny = 1,
            Small = 2,
            Medium = 3,
            Large = 4,
            Huge = 5,
            Immobile = 6,
        };
        internal enum LeapJumpSpeed : short
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
    };
}
