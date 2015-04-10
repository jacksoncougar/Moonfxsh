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
        public  TransparentPlanesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 20)]
    public class TransparentPlanesBlockBase
    {
        internal short sectionIndex;
        internal short partIndex;
        internal OpenTK.Vector4 plane;
        internal  TransparentPlanesBlockBase(BinaryReader binaryReader)
        {
            this.sectionIndex = binaryReader.ReadInt16();
            this.partIndex = binaryReader.ReadInt16();
            this.plane = binaryReader.ReadVector4();
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
    };
}
