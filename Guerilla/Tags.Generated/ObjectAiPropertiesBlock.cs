// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ObjectAiPropertiesBlock : ObjectAiPropertiesBlockBase
    {
        public ObjectAiPropertiesBlock() : base()
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
        internal Moonfish.Tags.StringIdent aiTypeName;

        internal byte[] invalidName_;
        internal AiSize aiSize;
        internal LeapJumpSpeed leapJumpSpeed;

        public override int SerializedSize
        {
            get { return 16; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ObjectAiPropertiesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            aiFlags = (AiFlags) binaryReader.ReadInt32();
            aiTypeName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(4);
            aiSize = (AiSize) binaryReader.ReadInt16();
            leapJumpSpeed = (LeapJumpSpeed) binaryReader.ReadInt16();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write((Int32) aiFlags);
                binaryWriter.Write(aiTypeName);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write((Int16) aiSize);
                binaryWriter.Write((Int16) leapJumpSpeed);
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