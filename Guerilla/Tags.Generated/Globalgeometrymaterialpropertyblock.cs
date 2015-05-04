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
    public partial class GlobalGeometryMaterialPropertyBlock : GlobalGeometryMaterialPropertyBlockBase
    {
        public GlobalGeometryMaterialPropertyBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 8, Alignment = 4)]
    public class GlobalGeometryMaterialPropertyBlockBase : GuerillaBlock
    {
        internal Type type;
        internal short intValue;
        internal float realValue;

        public override int SerializedSize
        {
            get { return 8; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalGeometryMaterialPropertyBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            type = (Type) binaryReader.ReadInt16();
            intValue = binaryReader.ReadInt16();
            realValue = binaryReader.ReadSingle();
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
                binaryWriter.Write((Int16) type);
                binaryWriter.Write(intValue);
                binaryWriter.Write(realValue);
                return nextAddress;
            }
        }

        internal enum Type : short
        {
            LightmapResolution = 0,
            LightmapPower = 1,
            LightmapHalfLife = 2,
            LightmapDiffuseScale = 3,
        };
    };
}