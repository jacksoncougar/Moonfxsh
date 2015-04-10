using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelNodeBlock : RenderModelNodeBlockBase
    {
        public  RenderModelNodeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 96)]
    public class RenderModelNodeBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal short importNodeIndex;
        internal OpenTK.Vector3 defaultTranslation;
        internal OpenTK.Quaternion defaultRotation;
        internal OpenTK.Vector3 inverseForward;
        internal OpenTK.Vector3 inverseLeft;
        internal OpenTK.Vector3 inverseUp;
        internal OpenTK.Vector3 inversePosition;
        internal float inverseScale;
        internal float distanceFromParent;
        internal  RenderModelNodeBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.parentNode = binaryReader.ReadShortBlockIndex1();
            this.firstChildNode = binaryReader.ReadShortBlockIndex1();
            this.nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.importNodeIndex = binaryReader.ReadInt16();
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultRotation = binaryReader.ReadQuaternion();
            this.inverseForward = binaryReader.ReadVector3();
            this.inverseLeft = binaryReader.ReadVector3();
            this.inverseUp = binaryReader.ReadVector3();
            this.inversePosition = binaryReader.ReadVector3();
            this.inverseScale = binaryReader.ReadSingle();
            this.distanceFromParent = binaryReader.ReadSingle();
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
    };
}
