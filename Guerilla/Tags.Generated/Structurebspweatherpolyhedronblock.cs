// ReSharper disable All

using Moonfish.Model;

using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspWeatherPolyhedronBlock : StructureBspWeatherPolyhedronBlockBase
    {
        public StructureBspWeatherPolyhedronBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 24, Alignment = 4)]
    public class StructureBspWeatherPolyhedronBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 boundingSphereCenter;
        internal float boundingSphereRadius;
        internal StructureBspWeatherPolyhedronPlaneBlock[] planes;

        public override int SerializedSize
        {
            get { return 24; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspWeatherPolyhedronBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            boundingSphereCenter = binaryReader.ReadVector3();
            boundingSphereRadius = binaryReader.ReadSingle();
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureBspWeatherPolyhedronPlaneBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            planes = ReadBlockArrayData<StructureBspWeatherPolyhedronPlaneBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(boundingSphereCenter);
                binaryWriter.Write(boundingSphereRadius);
                nextAddress = Guerilla.WriteBlockArray<StructureBspWeatherPolyhedronPlaneBlock>(binaryWriter, planes,
                    nextAddress);
                return nextAddress;
            }
        }
    };
}