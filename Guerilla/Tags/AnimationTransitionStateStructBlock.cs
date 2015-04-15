// ReSharper disable All
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
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationTransitionStateStructBlockBase  : IGuerilla
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
            stateName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            indexA = binaryReader.ReadByte();
            indexB = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stateName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(indexA);
                binaryWriter.Write(indexB);
                return nextAddress;
            }
        }
    };
}
