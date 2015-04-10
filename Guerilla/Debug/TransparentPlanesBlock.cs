// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class TransparentPlanesBlock : TransparentPlanesBlockBase
    {
        public  TransparentPlanesBlock(System.IO.BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class TransparentPlanesBlockBase
    {
        internal short sectionIndex;
        internal short partIndex;
        internal OpenTK.Vector4 plane;
        internal  TransparentPlanesBlockBase(System.IO.BinaryReader binaryReader)
        {
            sectionIndex = binaryReader.ReadInt16();
            partIndex = binaryReader.ReadInt16();
            plane = binaryReader.ReadVector4();
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
                binaryWriter.Write(sectionIndex);
                binaryWriter.Write(partIndex);
                binaryWriter.Write(plane);
            }
        }
    };
}
