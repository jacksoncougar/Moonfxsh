using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationTransitionStateStructBlock : AnimationTransitionStateStructBlockBase
    {
        public  AnimationTransitionStateStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class AnimationTransitionStateStructBlockBase
    {
        /// <summary>
        /// name of the state
        /// </summary>
        internal Moonfish.Tags.StringID stateName;
        internal byte[] invalidName_;
        /// <summary>
        /// first level sub-index into state
        /// </summary>
        internal byte indexA;
        /// <summary>
        /// second level sub-index into state
        /// </summary>
        internal byte indexB;
        internal  AnimationTransitionStateStructBlockBase(BinaryReader binaryReader)
        {
            this.stateName = binaryReader.ReadStringID();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.indexA = binaryReader.ReadByte();
            this.indexB = binaryReader.ReadByte();
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
    };
}
