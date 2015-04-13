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
        public  StructureBspPrecomputedLightingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class StructureBspPrecomputedLightingBlockBase  : IGuerilla
    {
        internal int index;
        internal LightType lightType;
        internal byte attachmentIndex;
        internal byte objectType;
        internal VisibilityStructBlock visibility;
        internal  StructureBspPrecomputedLightingBlockBase(BinaryReader binaryReader)
        {
            index = binaryReader.ReadInt32();
            lightType = (LightType)binaryReader.ReadInt16();
            attachmentIndex = binaryReader.ReadByte();
            objectType = binaryReader.ReadByte();
            visibility = new VisibilityStructBlock(binaryReader);
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                binaryWriter.Write((Int16)lightType);
                binaryWriter.Write(attachmentIndex);
                binaryWriter.Write(objectType);
                visibility.Write(binaryWriter);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
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
