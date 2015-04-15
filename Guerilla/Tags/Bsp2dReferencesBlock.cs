// ReSharper disable All
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
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class Bsp2dReferencesBlockBase  : IGuerilla
    {
        internal short plane;
        internal short bSP2DNode;
        internal  Bsp2dReferencesBlockBase(BinaryReader binaryReader)
        {
            plane = binaryReader.ReadInt16();
            bSP2DNode = binaryReader.ReadInt16();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(plane);
                binaryWriter.Write(bSP2DNode);
                return nextAddress;
            }
        }
    };
}
