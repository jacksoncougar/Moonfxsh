// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationTransitionBlock : AnimationTransitionBlockBase
    {
        public  AnimationTransitionBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationTransitionBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class AnimationTransitionBlockBase : GuerillaBlock
    {
        /// <summary>
        /// name of the mode & state of the source
        /// </summary>
        internal Moonfish.Tags.StringID fullName;
        internal AnimationTransitionStateStructBlock stateInfo;
        internal AnimationTransitionDestinationBlock[] destinationsAABBCC;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  AnimationTransitionBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            fullName = binaryReader.ReadStringID();
            stateInfo = new AnimationTransitionStateStructBlock(binaryReader);
            destinationsAABBCC = Guerilla.ReadBlockArray<AnimationTransitionDestinationBlock>(binaryReader);
        }
        public  AnimationTransitionBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            fullName = binaryReader.ReadStringID();
            stateInfo = new AnimationTransitionStateStructBlock(binaryReader);
            destinationsAABBCC = Guerilla.ReadBlockArray<AnimationTransitionDestinationBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
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
