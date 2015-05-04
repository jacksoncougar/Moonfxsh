// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class AnimationDestinationStateStructBlock : AnimationDestinationStateStructBlockBase
    {
        public  AnimationDestinationStateStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  AnimationDestinationStateStructBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class AnimationDestinationStateStructBlockBase : GuerillaBlock
    {
        /// <summary>
        /// name of the state
        /// </summary>
        internal Moonfish.Tags.StringIdent stateName;
        /// <summary>
        /// which frame event to link to
        /// </summary>
        internal FrameEventLinkWhichFrameEventToLinkTo frameEventLink;
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
        
        public  AnimationDestinationStateStructBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stateName = binaryReader.ReadStringID();
            frameEventLink = (FrameEventLinkWhichFrameEventToLinkTo)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            indexA = binaryReader.ReadByte();
            indexB = binaryReader.ReadByte();
        }
        public  AnimationDestinationStateStructBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            stateName = binaryReader.ReadStringID();
            frameEventLink = (FrameEventLinkWhichFrameEventToLinkTo)binaryReader.ReadByte();
            invalidName_ = binaryReader.ReadBytes(1);
            indexA = binaryReader.ReadByte();
            indexB = binaryReader.ReadByte();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stateName);
                binaryWriter.Write((Byte)frameEventLink);
                binaryWriter.Write(invalidName_, 0, 1);
                binaryWriter.Write(indexA);
                binaryWriter.Write(indexB);
                return nextAddress;
            }
        }
        internal enum FrameEventLinkWhichFrameEventToLinkTo : byte
        {
            NOKEYFRAME = 0,
            KEYFRAMETYPEA = 1,
            KEYFRAMETYPEB = 2,
            KEYFRAMETYPEC = 3,
            KEYFRAMETYPED = 4,
        };
    };
}
