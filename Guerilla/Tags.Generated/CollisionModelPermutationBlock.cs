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
    public partial class CollisionModelPermutationBlock : CollisionModelPermutationBlockBase
    {
        public CollisionModelPermutationBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CollisionModelPermutationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal CollisionModelBspBlock[] bsps;
        internal CollisionBspPhysicsBlock[] bspPhysics;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public CollisionModelPermutationBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            name = binaryReader.ReadStringID();
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionModelBspBlock>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<CollisionBspPhysicsBlock>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            bsps = ReadBlockArrayData<CollisionModelBspBlock>(binaryReader, blamPointers.Dequeue());
            bspPhysics = ReadBlockArrayData<CollisionBspPhysicsBlock>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelBspBlock>(binaryWriter, bsps, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CollisionBspPhysicsBlock>(binaryWriter, bspPhysics, nextAddress);
                return nextAddress;
            }
        }
    };
}
