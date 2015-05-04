// ReSharper disable All

using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class ModelNodeBlock : ModelNodeBlockBase
    {
        public ModelNodeBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 92, Alignment = 4)]
    public class ModelNodeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
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

        public override int SerializedSize
        {
            get { return 92; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public ModelNodeBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
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
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
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
                return nextAddress;
            }
        }
    };
}