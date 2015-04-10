using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ObjectAiPropertiesBlock : ObjectAiPropertiesBlockBase
    {
        public  ObjectAiPropertiesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 16)]
    public class ObjectAiPropertiesBlockBase
    {
        internal AiFlags aiFlags;
        /// <summary>
        /// used for combat dialogue, etc.
        /// </summary>
        internal Moonfish.Tags.StringID aiTypeName;
        internal byte[] invalidName_;
        internal AiSize aiSize;
        internal LeapJumpSpeed leapJumpSpeed;
        internal  ObjectAiPropertiesBlockBase(BinaryReader binaryReader)
        {
            this.aiFlags = (AiFlags)binaryReader.ReadInt32();
            this.aiTypeName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(4);
            this.aiSize = (AiSize)binaryReader.ReadInt16();
            this.leapJumpSpeed = (LeapJumpSpeed)binaryReader.ReadInt16();
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
