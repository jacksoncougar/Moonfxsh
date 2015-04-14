// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspSoundClusterBlock : StructureBspSoundClusterBlockBase
    {
        public  StructureBspSoundClusterBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class StructureBspSoundClusterBlockBase  : IGuerilla
    {
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal StructureSoundClusterPortalDesignators[] enclosingPortalDesignators;
        internal StructureSoundClusterInteriorClusterIndices[] interiorClusterIndices;
        internal  StructureBspSoundClusterBlockBase(BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            enclosingPortalDesignators = Guerilla.ReadBlockArray<StructureSoundClusterPortalDesignators>(binaryReader);
            interiorClusterIndices = Guerilla.ReadBlockArray<StructureSoundClusterInteriorClusterIndices>(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                nextAddress = Guerilla.WriteBlockArray<StructureSoundClusterPortalDesignators>(binaryWriter, enclosingPortalDesignators, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<StructureSoundClusterInteriorClusterIndices>(binaryWriter, interiorClusterIndices, nextAddress);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
