// ReSharper disable All
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
    [LayoutAttribute(Size = 32, Alignment = 4)]
    public class AnimationGraphNodeBlockBase  : IGuerilla
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
            name = binaryReader.ReadStringID();
            nextSiblingNodeIndex = binaryReader.ReadShortBlockIndex1();
            firstChildNodeIndex = binaryReader.ReadShortBlockIndex1();
            parentNodeIndex = binaryReader.ReadShortBlockIndex1();
            modelFlags = (ModelFlags)binaryReader.ReadByte();
            nodeJointFlags = (NodeJointFlags)binaryReader.ReadByte();
            baseVector = binaryReader.ReadVector3();
            vectorRange = binaryReader.ReadSingle();
            zPos = binaryReader.ReadSingle();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                binaryWriter.Write(nextSiblingNodeIndex);
                binaryWriter.Write(firstChildNodeIndex);
                binaryWriter.Write(parentNodeIndex);
                binaryWriter.Write((Byte)modelFlags);
                binaryWriter.Write((Byte)nodeJointFlags);
                binaryWriter.Write(baseVector);
                binaryWriter.Write(vectorRange);
                binaryWriter.Write(zPos);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
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
