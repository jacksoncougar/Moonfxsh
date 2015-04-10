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
        public  AnimationTransitionStateStructBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  AnimationTransitionStateStructBlockBase(System.IO.BinaryReader binaryReader)
        {
            stateName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            indexA = binaryReader.ReadByte();
            indexB = binaryReader.ReadByte();
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
                binaryWriter.Write(stateName);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(indexA);
                binaryWriter.Write(indexB);
            }
        }
    };
}
