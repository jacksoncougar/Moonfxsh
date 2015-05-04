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
    public partial class RenderModelNodeBlock : RenderModelNodeBlockBase
    {
        public RenderModelNodeBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 96, Alignment = 4)]
    public class RenderModelNodeBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
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

        public override int SerializedSize
        {
            get { return 96; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public RenderModelNodeBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            parentNode = binaryReader.ReadShortBlockIndex1();
            firstChildNode = binaryReader.ReadShortBlockIndex1();
            nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            importNodeIndex = binaryReader.ReadInt16();
            defaultTranslation = binaryReader.ReadVector3();
            defaultRotation = binaryReader.ReadQuaternion();
            inverseForward = binaryReader.ReadVector3();
            inverseLeft = binaryReader.ReadVector3();
            inverseUp = binaryReader.ReadVector3();
            inversePosition = binaryReader.ReadVector3();
            inverseScale = binaryReader.ReadSingle();
            distanceFromParent = binaryReader.ReadSingle();
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
                binaryWriter.Write(importNodeIndex);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultRotation);
                binaryWriter.Write(inverseForward);
                binaryWriter.Write(inverseLeft);
                binaryWriter.Write(inverseUp);
                binaryWriter.Write(inversePosition);
                binaryWriter.Write(inverseScale);
                binaryWriter.Write(distanceFromParent);
                return nextAddress;
            }
        }
    };
}