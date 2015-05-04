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
    public partial class StructureBspInstancedGeometryInstancesBlock : StructureBspInstancedGeometryInstancesBlockBase
    {
        public StructureBspInstancedGeometryInstancesBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 88, Alignment = 4)]
    public class StructureBspInstancedGeometryInstancesBlockBase : GuerillaBlock
    {
        internal float scale;
        internal OpenTK.Vector3 forward;
        internal OpenTK.Vector3 left;
        internal OpenTK.Vector3 up;
        internal OpenTK.Vector3 position;
        internal Moonfish.Tags.ShortBlockIndex1 instanceDefinition;
        internal Flags flags;
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal byte[] invalidName_1;
        internal int checksum;
        internal Moonfish.Tags.StringIdent name;
        internal PathfindingPolicy pathfindingPolicy;
        internal LightmappingPolicy lightmappingPolicy;

        public override int SerializedSize
        {
            get { return 88; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public StructureBspInstancedGeometryInstancesBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            scale = binaryReader.ReadSingle();
            forward = binaryReader.ReadVector3();
            left = binaryReader.ReadVector3();
            up = binaryReader.ReadVector3();
            position = binaryReader.ReadVector3();
            instanceDefinition = binaryReader.ReadShortBlockIndex1();
            flags = (Flags) binaryReader.ReadInt16();
            invalidName_ = binaryReader.ReadBytes(4);
            invalidName_0 = binaryReader.ReadBytes(12);
            invalidName_1 = binaryReader.ReadBytes(4);
            checksum = binaryReader.ReadInt32();
            name = binaryReader.ReadStringID();
            pathfindingPolicy = (PathfindingPolicy) binaryReader.ReadInt16();
            lightmappingPolicy = (LightmappingPolicy) binaryReader.ReadInt16();
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
                binaryWriter.Write(scale);
                binaryWriter.Write(forward);
                binaryWriter.Write(left);
                binaryWriter.Write(up);
                binaryWriter.Write(position);
                binaryWriter.Write(instanceDefinition);
                binaryWriter.Write((Int16) flags);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(invalidName_0, 0, 12);
                binaryWriter.Write(invalidName_1, 0, 4);
                binaryWriter.Write(checksum);
                binaryWriter.Write(name);
                binaryWriter.Write((Int16) pathfindingPolicy);
                binaryWriter.Write((Int16) lightmappingPolicy);
                return nextAddress;
            }
        }

        [FlagsAttribute]
        internal enum Flags : short
        {
            NotInLightprobes = 1,
        };

        internal enum PathfindingPolicy : short
        {
            Cutout = 0,
            Static = 1,
            None = 2,
        };

        internal enum LightmappingPolicy : short
        {
            PerPixel = 0,
            PerVertex = 1,
        };
    };
}