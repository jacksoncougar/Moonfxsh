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
    public partial class OldUnusedStrucurePhysicsBlock : OldUnusedStrucurePhysicsBlockBase
    {
        public OldUnusedStrucurePhysicsBlock() : base()
        {
        }
    };

    [LayoutAttribute(Size = 44, Alignment = 4)]
    public class OldUnusedStrucurePhysicsBlockBase : GuerillaBlock
    {
        internal byte[] moppCode;
        internal OldUnusedObjectIdentifiersBlock[] evironmentObjectIdentifiers;
        internal byte[] invalidName_;
        internal OpenTK.Vector3 moppBoundsMin;
        internal OpenTK.Vector3 moppBoundsMax;

        public override int SerializedSize
        {
            get { return 44; }
        }

        public override int Alignment
        {
            get { return 4; }
        }

        public OldUnusedStrucurePhysicsBlockBase() : base()
        {
        }

        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer(binaryReader, 1));
            blamPointers.Enqueue(ReadBlockArrayPointer<OldUnusedObjectIdentifiersBlock>(binaryReader));
            invalidName_ = binaryReader.ReadBytes(4);
            moppBoundsMin = binaryReader.ReadVector3();
            moppBoundsMax = binaryReader.ReadVector3();
            return blamPointers;
        }

        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            moppCode = ReadDataByteArray(binaryReader, blamPointers.Dequeue());
            evironmentObjectIdentifiers = ReadBlockArrayData<OldUnusedObjectIdentifiersBlock>(binaryReader,
                blamPointers.Dequeue());
        }

        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
            using (binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteData(binaryWriter, moppCode, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<OldUnusedObjectIdentifiersBlock>(binaryWriter,
                    evironmentObjectIdentifiers, nextAddress);
                binaryWriter.Write(invalidName_, 0, 4);
                binaryWriter.Write(moppBoundsMin);
                binaryWriter.Write(moppBoundsMax);
                return nextAddress;
            }
        }
    };
}