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
    public partial class AdditionalNodeDataBlock : AdditionalNodeDataBlockBase
    {
        public AdditionalNodeDataBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 60, Alignment = 4)]
    public class AdditionalNodeDataBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent nodeName;
        internal OpenTK.Quaternion defaultRotation;
        internal OpenTK.Vector3 defaultTranslation;
        internal float defaultScale;
        internal OpenTK.Vector3 minBounds;
        internal OpenTK.Vector3 maxBounds;

        public override int SerializedSize
        {
            get { return 60; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public AdditionalNodeDataBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            nodeName = binaryReader.ReadStringID();
            defaultRotation = binaryReader.ReadQuaternion();
            defaultTranslation = binaryReader.ReadVector3();
            defaultScale = binaryReader.ReadSingle();
            minBounds = binaryReader.ReadVector3();
            maxBounds = binaryReader.ReadVector3();
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
                binaryWriter.Write(nodeName);
                binaryWriter.Write(defaultRotation);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultScale);
                binaryWriter.Write(minBounds);
                binaryWriter.Write(maxBounds);
                return nextAddress;
            }
        }
    };
}