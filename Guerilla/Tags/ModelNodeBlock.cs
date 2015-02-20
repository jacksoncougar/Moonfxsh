using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    [LayoutAttribute(Size = 92)]
    public  partial class ModelNodeBlock : ModelNodeBlockBase
    {
        public  ModelNodeBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 92)]
    public class ModelNodeBlockBase
    {
        internal Moonfish.Tags.StringID name;
        internal Moonfish.Tags.ShortBlockIndex1 parentNode;
        internal Moonfish.Tags.ShortBlockIndex1 firstChildNode;
        internal Moonfish.Tags.ShortBlockIndex1 nextSiblingNode;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 defaultTranslation;
        internal OpenTK.Quaternion defaultRotation;
        internal float defaultInverseScale;
        internal OpenTK.Vector3 defaultInverseForward;
        internal OpenTK.Vector3 defaultInverseLeft;
        internal OpenTK.Vector3 defaultInverseUp;
        internal OpenTK.Vector3 defaultInversePosition;
        internal  ModelNodeBlockBase(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.parentNode = binaryReader.ReadShortBlockIndex1();
            this.firstChildNode = binaryReader.ReadShortBlockIndex1();
            this.nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultRotation = binaryReader.ReadQuaternion();
            this.defaultInverseScale = binaryReader.ReadSingle();
            this.defaultInverseForward = binaryReader.ReadVector3();
            this.defaultInverseLeft = binaryReader.ReadVector3();
            this.defaultInverseUp = binaryReader.ReadVector3();
            this.defaultInversePosition = binaryReader.ReadVector3();
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
