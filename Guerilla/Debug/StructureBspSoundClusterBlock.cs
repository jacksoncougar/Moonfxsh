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
        public  StructureBspSoundClusterBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
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
        internal  StructureBspSoundClusterBlockBase(System.IO.BinaryReader binaryReader)
        {
            invalidName_ = binaryReader.ReadBytes(2);
            invalidName_0 = binaryReader.ReadBytes(2);
            ReadStructureSoundClusterPortalDesignatorsArray(binaryReader);
            ReadStructureSoundClusterInteriorClusterIndicesArray(binaryReader);
        }
        internal  virtual byte[] ReadData(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureSoundClusterPortalDesignators[] ReadStructureSoundClusterPortalDesignatorsArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual StructureSoundClusterInteriorClusterIndices[] ReadStructureSoundClusterInteriorClusterIndicesArray(System.IO.BinaryReader binaryReader)
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureSoundClusterPortalDesignatorsArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        internal  virtual void WriteStructureSoundClusterInteriorClusterIndicesArray(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(invalidName_0, 0, 2);
                WriteStructureSoundClusterPortalDesignatorsArray(binaryWriter);
                WriteStructureSoundClusterInteriorClusterIndicesArray(binaryWriter);
            }
        }
    };
}
