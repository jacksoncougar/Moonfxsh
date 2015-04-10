using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationTransitionBlock : AnimationTransitionBlockBase
    {
        public  AnimationTransitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class AnimationTransitionBlockBase
    {
        /// <summary>
        /// name of the mode & state of the source
        /// </summary>
        internal Moonfish.Tags.StringID fullName;
        internal AnimationTransitionStateStructBlock stateInfo;
        internal AnimationTransitionDestinationBlock[] destinationsAABBCC;
        internal  AnimationTransitionBlockBase(BinaryReader binaryReader)
        {
            this.fullName = binaryReader.ReadStringID();
            this.stateInfo = new AnimationTransitionStateStructBlock(binaryReader);
            this.destinationsAABBCC = ReadAnimationTransitionDestinationBlockArray(binaryReader);
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
        internal  virtual AnimationTransitionDestinationBlock[] ReadAnimationTransitionDestinationBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationTransitionDestinationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationTransitionDestinationBlock[blamPointer.count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationTransitionDestinationBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
