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
    public partial class AnimationTransitionBlock : AnimationTransitionBlockBase
    {
        public AnimationTransitionBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class AnimationTransitionBlockBase : GuerillaBlock
    {
        /// <summary>
        /// name of the mode & state of the source
        /// </summary>
        internal Moonfish.Tags.StringIdent fullName;
        internal AnimationTransitionStateStructBlock stateInfo;
        internal AnimationTransitionDestinationBlock[] destinationsAABBCC;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public AnimationTransitionBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            fullName = binaryReader.ReadStringID();
            stateInfo = new AnimationTransitionStateStructBlock();
            blamPointers.Concat(stateInfo.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<AnimationTransitionDestinationBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            stateInfo.ReadPointers(binaryReader, blamPointers);
            destinationsAABBCC = ReadBlockArrayData<AnimationTransitionDestinationBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fullName);
                stateInfo.Write(binaryWriter);
                nextAddress = Guerilla.WriteBlockArray<AnimationTransitionDestinationBlock>(binaryWriter, destinationsAABBCC, nextAddress);
                return nextAddress;
            }
        }
    };
}
