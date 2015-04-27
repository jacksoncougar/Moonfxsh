// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class Bsp2dReferencesBlock : Bsp2dReferencesBlockBase
    {
        public  Bsp2dReferencesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  Bsp2dReferencesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 4, Alignment = 4)]
    public class Bsp2dReferencesBlockBase : GuerillaBlock
    {
        internal short plane;
        internal short bSP2DNode;
        
        public override int SerializedSize{get { return 4; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  Bsp2dReferencesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            plane = binaryReader.ReadInt16();
            bSP2DNode = binaryReader.ReadInt16();
        }
        public  Bsp2dReferencesBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            plane = binaryReader.ReadInt16();
            bSP2DNode = binaryReader.ReadInt16();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
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
