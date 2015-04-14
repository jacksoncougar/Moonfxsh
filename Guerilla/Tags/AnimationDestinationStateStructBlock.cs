using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationDestinationStateStructBlock : AnimationDestinationStateStructBlockBase
    {
        public  AnimationDestinationStateStructBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 8)]
    public class AnimationDestinationStateStructBlockBase
    {
        /// <summary>
        /// name of the state
        /// </summary>
        internal Moonfish.Tags.StringID stateName;
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
        internal  AnimationDestinationStateStructBlockBase(BinaryReader binaryReader)
        {
            this.stateName = binaryReader.ReadStringID();
            this.frameEventLink = (FrameEventLinkWhichFrameEventToLinkTo)binaryReader.ReadByte();
            this.invalidName_ = binaryReader.ReadBytes(1);
            this.indexA = binaryReader.ReadByte();
            this.indexB = binaryReader.ReadByte();
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.elementCount];
            if(blamPointer.elementCount > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.elementCount);
                }
            }
            return data;
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
