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
    public partial class VehicleSuspensionBlock : VehicleSuspensionBlockBase
    {
        public VehicleSuspensionBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 40, Alignment = 4)]
    public class VehicleSuspensionBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent label;
        internal AnimationIndexStructBlock animation;
        internal Moonfish.Tags.StringIdent markerName;
        internal float massPointOffset;
        internal float fullExtensionGroundDepth;
        internal float fullCompressionGroundDepth;
        internal Moonfish.Tags.StringIdent regionName;
        internal float destroyedMassPointOffset;
        internal float destroyedFullExtensionGroundDepth;
        internal float destroyedFullCompressionGroundDepth;

        public override int SerializedSize
        {
            get { return 40; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public VehicleSuspensionBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            label = binaryReader.ReadStringID();
            animation = new AnimationIndexStructBlock();
            blamPointers = new Queue<BlamPointer>(blamPointers.Concat(animation.ReadFields(binaryReader)));
            markerName = binaryReader.ReadStringID();
            massPointOffset = binaryReader.ReadSingle();
            fullExtensionGroundDepth = binaryReader.ReadSingle();
            fullCompressionGroundDepth = binaryReader.ReadSingle();
            regionName = binaryReader.ReadStringID();
            destroyedMassPointOffset = binaryReader.ReadSingle();
            destroyedFullExtensionGroundDepth = binaryReader.ReadSingle();
            destroyedFullCompressionGroundDepth = binaryReader.ReadSingle();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            animation.ReadPointers(binaryReader, blamPointers);
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(label);
                animation.Write(binaryWriter);
                binaryWriter.Write(markerName);
                binaryWriter.Write(massPointOffset);
                binaryWriter.Write(fullExtensionGroundDepth);
                binaryWriter.Write(fullCompressionGroundDepth);
                binaryWriter.Write(regionName);
                binaryWriter.Write(destroyedMassPointOffset);
                binaryWriter.Write(destroyedFullExtensionGroundDepth);
                binaryWriter.Write(destroyedFullCompressionGroundDepth);
                return nextAddress;
            }
        }
    };
}