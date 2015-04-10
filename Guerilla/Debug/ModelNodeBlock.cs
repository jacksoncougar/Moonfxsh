// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class ModelNodeBlock : ModelNodeBlockBase
    {
        public  ModelNodeBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  ModelNodeBlockBase(System.IO.BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            parentNode = binaryReader.ReadShortBlockIndex1();
            firstChildNode = binaryReader.ReadShortBlockIndex1();
            nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            invalidName_ = binaryReader.ReadBytes(2);
            defaultTranslation = binaryReader.ReadVector3();
            defaultRotation = binaryReader.ReadQuaternion();
            defaultInverseScale = binaryReader.ReadSingle();
            defaultInverseForward = binaryReader.ReadVector3();
            defaultInverseLeft = binaryReader.ReadVector3();
            defaultInverseUp = binaryReader.ReadVector3();
            defaultInversePosition = binaryReader.ReadVector3();
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
                binaryWriter.Write(name);
                binaryWriter.Write(parentNode);
                binaryWriter.Write(firstChildNode);
                binaryWriter.Write(nextSiblingNode);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultRotation);
                binaryWriter.Write(defaultInverseScale);
                binaryWriter.Write(defaultInverseForward);
                binaryWriter.Write(defaultInverseLeft);
                binaryWriter.Write(defaultInverseUp);
                binaryWriter.Write(defaultInversePosition);
            }
        }
    };
}
