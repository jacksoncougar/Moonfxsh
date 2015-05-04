// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationTransitionStateStructBlock : AnimationTransitionStateStructBlockBase
    {
        public  AnimationTransitionStateStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationTransitionStateStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationTransitionStateStructBlockBase : GuerillaBlock
    {
        /// <summary>
        /// name of the state
        /// </summary>
        internal Moonfish.Tags.StringIdent stateName;
        internal byte[] invalidName_;
        /// <summary>
        /// first level sub-index into state
        /// </summary>
        internal byte indexA;
        /// <summary>
        /// second level sub-index into state
        /// </summary>
        internal byte indexB;
        
        public override int SerializedSize{get { return 8; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationTransitionStateStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stateName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            indexA = binaryReader.ReadByte();
            indexB = binaryReader.ReadByte();
        }
        public  AnimationTransitionStateStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            stateName = binaryReader.ReadStringID();
            invalidName_ = binaryReader.ReadBytes(2);
            indexA = binaryReader.ReadByte();
            indexB = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
