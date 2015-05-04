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
    public partial class StructureBspSoundClusterBlock : StructureBspSoundClusterBlockBase
    {
        public StructureBspSoundClusterBlock() : base()
        {
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class StructureBspSoundClusterBlockBase : GuerillaBlock
    {
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal StructureSoundClusterPortalDesignators[] enclosingPortalDesignators;
        internal StructureSoundClusterInteriorClusterIndices[] interiorClusterIndices;
        public override int SerializedSize { get { return 20; } }
        public override int Alignment { get { return 4; } }
        public StructureBspSoundClusterBlockBase() : base()
        {
        }
        public override Queue<BlamPointer> ReadFields(BinaryReader binaryReader)
        {
            var blamPointers = new Queue<BlamPointer>(base.ReadFields(binaryReader));
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureSoundClusterPortalDesignators>(binaryReader));
            blamPointers.Enqueue(ReadBlockArrayPointer<StructureSoundClusterInteriorClusterIndices>(binaryReader));
            return blamPointers;
        }
        public override void ReadPointers(BinaryReader binaryReader, Queue<BlamPointer> blamPointers)
        {
            base.ReadPointers(binaryReader, blamPointers);
            enclosingPortalDesignators = ReadBlockArrayData<StructureSoundClusterPortalDesignators>(binaryReader, blamPointers.Dequeue());
            interiorClusterIndices = ReadBlockArrayData<StructureSoundClusterInteriorClusterIndices>(binaryReader, blamPointers.Dequeue());
        }
        public override int Write(BinaryWriter binaryWriter, int nextAddress)
        {
            base.Write(binaryWriter, nextAddress);
using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<StructureSoundClusterPortalDesignators>(binaryWriter, enclosingPortalDesignators, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureSoundClusterInteriorClusterIndices>(binaryWriter, interiorClusterIndices, nextAddress);
                return nextAddress;
            }
        }
    };
}
