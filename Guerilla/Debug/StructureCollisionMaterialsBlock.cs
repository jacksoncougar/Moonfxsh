// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class StructureCollisionMaterialsBlock : StructureCollisionMaterialsBlockBase
    {
        public  StructureCollisionMaterialsBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class StructureCollisionMaterialsBlockBase
    {
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference oldShader;
        internal byte[] invalidName_;
        internal Moonfish.Tags.ShortBlockIndex1 conveyorSurfaceIndex;
        [TagReference("shad")]
        internal Moonfish.Tags.TagReference newShader;
        internal  StructureCollisionMaterialsBlockBase(System.IO.BinaryReader binaryReader)
        {
            oldShader = binaryReader.ReadTagReference();
            invalidName_ = binaryReader.ReadBytes(2);
            conveyorSurfaceIndex = binaryReader.ReadShortBlockIndex1();
            newShader = binaryReader.ReadTagReference();
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
                binaryWriter.Write(oldShader);
                binaryWriter.Write(invalidName_, 0, 2);
                binaryWriter.Write(conveyorSurfaceIndex);
                binaryWriter.Write(newShader);
            }
        }
    };
}
