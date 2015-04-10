// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureBspPrecomputedLightingBlock : StructureBspPrecomputedLightingBlockBase
    {
        public  StructureBspPrecomputedLightingBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48)]
    public class StructureBspPrecomputedLightingBlockBase
    {
        internal int index;
        internal LightType lightType;
        internal byte attachmentIndex;
        internal byte objectType;
        internal VisibilityStructBlock visibility;
        internal  StructureBspPrecomputedLightingBlockBase(System.IO.BinaryReader binaryReader)
        {
            index = binaryReader.ReadInt32();
            lightType = (LightType)binaryReader.ReadInt16();
            attachmentIndex = binaryReader.ReadByte();
            objectType = binaryReader.ReadByte();
            visibility = new VisibilityStructBlock(binaryReader);
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
        internal  virtual void WriteData(System.IO.BinaryWriter binaryWriter)
        {
            
        }
        public void Write(System.IO.BinaryWriter binaryWriter)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                binaryWriter.Write((Int16)lightType);
                binaryWriter.Write(attachmentIndex);
                binaryWriter.Write(objectType);
                visibility.Write(binaryWriter);
            }
        }
        internal enum LightType : short
        
        {
            FreeStanding = 0,
            AttachedToEditorObject = 1,
            AttachedToStructureObject = 2,
        };
    };
}
