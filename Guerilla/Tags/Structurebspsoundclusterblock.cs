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
    [LayoutAttribute(Size = 20)]
    public class StructureBspSoundClusterBlockBase
    {
        internal byte[] invalidName_;
        internal byte[] invalidName_0;
        internal StructureSoundClusterPortalDesignators[] enclosingPortalDesignators;
        internal StructureSoundClusterInteriorClusterIndices[] interiorClusterIndices;
        internal  StructureBspSoundClusterBlockBase(BinaryReader binaryReader)
        {
            this.invalidName_ = binaryReader.ReadBytes(2);
            this.invalidName_0 = binaryReader.ReadBytes(2);
            this.enclosingPortalDesignators = ReadStructureSoundClusterPortalDesignatorsArray(binaryReader);
            this.interiorClusterIndices = ReadStructureSoundClusterInteriorClusterIndicesArray(binaryReader);
        }
        internal  virtual byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal  virtual StructureSoundClusterPortalDesignators[] ReadStructureSoundClusterPortalDesignatorsArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureSoundClusterPortalDesignators));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureSoundClusterPortalDesignators[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureSoundClusterPortalDesignators(binaryReader);
                }
            }
            return array;
        }
        internal  virtual StructureSoundClusterInteriorClusterIndices[] ReadStructureSoundClusterInteriorClusterIndicesArray(BinaryReader binaryReader)
        {
            var elementSize = Deserializer.SizeOf(typeof(StructureSoundClusterInteriorClusterIndices));
            var blamPointer = binaryReader.ReadBlamPointer(elementSize);
            var array = new StructureSoundClusterInteriorClusterIndices[blamPointer.Count];
            using (binaryReader.BaseStream.Pin())
            {
                for (int i = 0; i < blamPointer.Count; ++i)
                {
                    binaryReader.BaseStream.Position = blamPointer[i];
                    array[i] = new StructureSoundClusterInteriorClusterIndices(binaryReader);
                }
            }
            return array;
        }
    };
}
