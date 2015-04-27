// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class StructureBspPrecomputedLightingBlock : StructureBspPrecomputedLightingBlockBase
    {
        public  StructureBspPrecomputedLightingBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  StructureBspPrecomputedLightingBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 48, Alignment = 4)]
    public class StructureBspPrecomputedLightingBlockBase : GuerillaBlock
    {
        internal int index;
        internal LightType lightType;
        internal byte attachmentIndex;
        internal byte objectType;
        internal VisibilityStructBlock visibility;
        
        public override int SerializedSize{get { return 48; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  StructureBspPrecomputedLightingBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            index = binaryReader.ReadInt32();
            lightType = (LightType)binaryReader.ReadInt16();
            attachmentIndex = binaryReader.ReadByte();
            objectType = binaryReader.ReadByte();
            visibility = new VisibilityStructBlock(binaryReader);
        }
        public  StructureBspPrecomputedLightingBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            index = binaryReader.ReadInt32();
            lightType = (LightType)binaryReader.ReadInt16();
            attachmentIndex = binaryReader.ReadByte();
            objectType = binaryReader.ReadByte();
            visibility = new VisibilityStructBlock(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(index);
                binaryWriter.Write((Int16)lightType);
                binaryWriter.Write(attachmentIndex);
                binaryWriter.Write(objectType);
                visibility.Write(binaryWriter);
                return nextAddress;
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
