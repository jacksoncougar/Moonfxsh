using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationTransitionDestinationBlock : AnimationTransitionDestinationBlockBase
    {
        public  AnimationTransitionDestinationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class AnimationTransitionDestinationBlockBase
    {
        /// <summary>
        /// name of the mode & state this transitions to
        /// </summary>
        internal Moonfish.Tags.StringID fullName;
        /// <summary>
        /// name of the mode
        /// </summary>
        internal Moonfish.Tags.StringID mode;
        internal AnimationDestinationStateStructBlock stateInfo;
        internal AnimationIndexStructBlock animation;
        internal  AnimationTransitionDestinationBlockBase(BinaryReader binaryReader)
        {
            this.fullName = binaryReader.ReadStringID();
            this.mode = binaryReader.ReadStringID();
            this.stateInfo = new AnimationDestinationStateStructBlock(binaryReader);
            this.animation = new AnimationIndexStructBlock(binaryReader);
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
    };
}
