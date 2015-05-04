// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationTransitionDestinationBlock : AnimationTransitionDestinationBlockBase
    {
        public AnimationTransitionDestinationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class AnimationTransitionDestinationBlockBase : GuerillaBlock
    {
        /// <summary>
        /// name of the mode & state this transitions to
        /// </summary>
        internal Moonfish.Tags.StringIdent fullName;
        /// <summary>
        /// name of the mode
        /// </summary>
        internal Moonfish.Tags.StringIdent mode;
        internal AnimationDestinationStateStructBlock stateInfo;
        internal AnimationIndexStructBlock animation;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public AnimationTransitionDestinationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            fullName = binaryReader.ReadStringID();
            mode = binaryReader.ReadStringID();
            stateInfo = new AnimationDestinationStateStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(stateInfo.ReadFields(binaryReader)));
            animation = new AnimationIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(animation.ReadFields(binaryReader)));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            stateInfo.ReadPointers(binaryReader, blamPointers);
            animation.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fullName);
                binaryWriter.Write(mode);
                stateInfo.Write(binaryWriter);
                animation.Write(binaryWriter);
                return nextAddress;
            }
        }
    };
}
