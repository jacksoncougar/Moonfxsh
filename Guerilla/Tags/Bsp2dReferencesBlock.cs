using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class Bsp2dReferencesBlock : Bsp2dReferencesBlockBase
    {
        public  Bsp2dReferencesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 4)]
    public class Bsp2dReferencesBlockBase
    {
        internal short plane;
        internal short bSP2DNode;
        internal  Bsp2dReferencesBlockBase(BinaryReader binaryReader)
        {
            this.plane = binaryReader.ReadInt16();
            this.bSP2DNode = binaryReader.ReadInt16();
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
