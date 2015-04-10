using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class InheritedAnimationBlock : InheritedAnimationBlockBase
    {
        public  InheritedAnimationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class InheritedAnimationBlockBase
    {
        [TagReference("jmad")]
        internal Moonfish.Tags.TagReference inheritedGraph;
        internal InheritedAnimationNodeMapBlock[] nodeMap;
        internal InheritedAnimationNodeMapFlagBlock[] nodeMapFlags;
        internal float rootZOffset;
        internal int inheritanceFlags;
        internal  InheritedAnimationBlockBase(BinaryReader binaryReader)
        {
            this.inheritedGraph = binaryReader.ReadTagReference();
            this.nodeMap = ReadInheritedAnimationNodeMapBlockArray(binaryReader);
            this.nodeMapFlags = ReadInheritedAnimationNodeMapFlagBlockArray(binaryReader);
            this.rootZOffset = binaryReader.ReadSingle();
            this.inheritanceFlags = binaryReader.ReadInt32();
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
        internal  virtual InheritedAnimationNodeMapBlock[] ReadInheritedAnimationNodeMapBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InheritedAnimationNodeMapBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InheritedAnimationNodeMapBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InheritedAnimationNodeMapBlock(binaryReader);
                }
            }
            return array;
        }
        internal  virtual InheritedAnimationNodeMapFlagBlock[] ReadInheritedAnimationNodeMapFlagBlockArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(InheritedAnimationNodeMapFlagBlock));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new InheritedAnimationNodeMapFlagBlock[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new InheritedAnimationNodeMapFlagBlock(binaryReader);
                }
            }
            return array;
        }
    };
}
