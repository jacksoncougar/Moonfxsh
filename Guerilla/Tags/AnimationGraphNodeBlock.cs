using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class AnimationGraphNodeBlock : AnimationGraphNodeBlockBase
    {
        public  AnimationGraphNodeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 32)]
    public class AnimationGraphNodeBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNodeIndex;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNodeIndex;
        internal Moonfish.Tags.ShortBlockIndex1 parentNodeIndex;
        internal ModelFlags modelFlags;
        internal NodeJointFlags nodeJointFlags;
        internal OpenTK.Vector3 baseVector;
        internal float vectorRange;
        internal float zPos;
        internal  AnimationGraphNodeBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.nextSiblingNodeIndex = binaryReader.ReadShortBlockIndex1();
            this.firstChildNodeIndex = binaryReader.ReadShortBlockIndex1();
            this.parentNodeIndex = binaryReader.ReadShortBlockIndex1();
            this.modelFlags = (ModelFlags)binaryReader.ReadByte();
            this.nodeJointFlags = (NodeJointFlags)binaryReader.ReadByte();
            this.baseVector = binaryReader.ReadVector3();
            this.vectorRange = binaryReader.ReadSingle();
            this.zPos = binaryReader.ReadSingle();
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
        [FlagsAttribute]
        internal enum ModelFlags : byte
        
        {
            PrimaryModel = 1,
            SecondaryModel = 2,
            LocalRoot = 4,
            LeftHand = 8,
            RightHand = 16,
            LeftArmMember = 32,
        };
        [FlagsAttribute]
        internal enum NodeJointFlags : byte
        
        {
            BallSocket = 1,
            Hinge = 2,
            NoMovement = 4,
        };
    };
}
