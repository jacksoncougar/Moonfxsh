// ReSharper disable All
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
        public  AnimationTransitionDestinationBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationTransitionDestinationBlockBase(System.IO.BinaryReader binaryReader)
        {
            fullName = binaryReader.ReadStringID();
            mode = binaryReader.ReadStringID();
            stateInfo = new AnimationDestinationStateStructBlock(binaryReader);
            animation = new AnimationIndexStructBlock(binaryReader);
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
                binaryWriter.Write(fullName);
                binaryWriter.Write(mode);
                stateInfo.Write(binaryWriter);
                animation.Write(binaryWriter);
            }
        }
    };
}
