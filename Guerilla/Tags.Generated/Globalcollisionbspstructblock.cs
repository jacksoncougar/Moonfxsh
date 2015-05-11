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
    public partial class GlobalCollisionBspStructBlock : GlobalCollisionBspStructBlockBase
    {
        public GlobalCollisionBspStructBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 64, Alignment = 4)]
    public class GlobalCollisionBspStructBlockBase : GuerillaBlock
    {
        internal Bsp3dNodesBlock[] bSP3DNodes;
        internal PlanesBlock[] planes;
        internal LeavesBlock[] leaves;
        internal Bsp2dReferencesBlock[] bSP2DReferences;
        internal Bsp2dNodesBlock[] bSP2DNodes;
        internal SurfacesBlock[] surfaces;
        internal EdgesBlock[] edges;
        internal VerticesBlock[] vertices;

        public override int SerializedSize
        {
            get { return 64; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public GlobalCollisionBspStructBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<Bsp3dNodesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<PlanesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<LeavesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<Bsp2dReferencesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<Bsp2dNodesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<SurfacesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<EdgesBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<VerticesBlock>(binaryReader));
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bSP3DNodes = ReadBlockArrayData<Bsp3dNodesBlock>(binaryReader, blamPointers.Dequeue());
            planes = ReadBlockArrayData<PlanesBlock>(binaryReader, blamPointers.Dequeue());
            leaves = ReadBlockArrayData<LeavesBlock>(binaryReader, blamPointers.Dequeue());
            bSP2DReferences = ReadBlockArrayData<Bsp2dReferencesBlock>(binaryReader, blamPointers.Dequeue());
            bSP2DNodes = ReadBlockArrayData<Bsp2dNodesBlock>(binaryReader, blamPointers.Dequeue());
            surfaces = ReadBlockArrayData<SurfacesBlock>(binaryReader, blamPointers.Dequeue());
            edges = ReadBlockArrayData<EdgesBlock>(binaryReader, blamPointers.Dequeue());
            vertices = ReadBlockArrayData<VerticesBlock>(binaryReader, blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<Bsp3dNodesBlock>(binaryWriter, bSP3DNodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<PlanesBlock>(binaryWriter, planes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<LeavesBlock>(binaryWriter, leaves, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<Bsp2dReferencesBlock>(binaryWriter, bSP2DReferences, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<Bsp2dNodesBlock>(binaryWriter, bSP2DNodes, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<SurfacesBlock>(binaryWriter, surfaces, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<EdgesBlock>(binaryWriter, edges, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<VerticesBlock>(binaryWriter, vertices, nextAddress);
                return nextAddress;
            }
        }
    };
}