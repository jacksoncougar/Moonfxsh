// ReSharper disable All
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
        public  AnimationTransitionBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationTransitionBlockBase(System.IO.BinaryReader binaryReader)
        {
            fullName = binaryReader.ReadStringID();
            stateInfo = new AnimationTransitionStateStructBlock(binaryReader);
            ReadAnimationTransitionDestinationBlockArray(binaryReader);
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
        internal  virtual AnimationTransitionDestinationBlock[] ReadAnimationTransitionDestinationBlockArray(System.IO.BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(AnimationTransitionDestinationBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new AnimationTransitionDestinationBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new AnimationTransitionDestinationBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteAnimationTransitionDestinationBlockArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(fullName);
                stateInfo.Write(binaryWriter);
                WriteAnimationTransitionDestinationBlockArray(binaryWriter);
            }
        }
    };
}
