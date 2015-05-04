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
    public partial class QuantizedOrientationStructBlock : QuantizedOrientationStructBlockBase
    {
        public QuantizedOrientationStructBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class QuantizedOrientationStructBlockBase : GuerillaBlock
    {
        internal short rotationX;
        internal short rotationY;
        internal short rotationZ;
        internal short rotationW;
        internal OpenTK.Vector3 defaultTranslation;
        internal float defaultScale;
        public override int SerializedSize { get { return 24; } }
        public override int Alignment { get { return 4; } }
        public QuantizedOrientationStructBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            rotationX = binaryReader.ReadInt16();
            rotationY = binaryReader.ReadInt16();
            rotationZ = binaryReader.ReadInt16();
            rotationW = binaryReader.ReadInt16();
            defaultTranslation = binaryReader.ReadVector3();
            defaultScale = binaryReader.ReadSingle();
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rotationX);
                binaryWriter.Write(rotationY);
                binaryWriter.Write(rotationZ);
                binaryWriter.Write(rotationW);
                binaryWriter.Write(defaultTranslation);
                binaryWriter.Write(defaultScale);
                return nextAddress;
            }
        }
    };
}
