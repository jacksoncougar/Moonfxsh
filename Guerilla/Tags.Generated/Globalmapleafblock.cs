// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class GlobalMapLeafBlock : GlobalMapLeafBlockBase
    {
        public  GlobalMapLeafBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  GlobalMapLeafBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class GlobalMapLeafBlockBase : GuerillaBlock
    {
        internal MapLeafFaceBlock[] faces;
        internal MapLeafConnectionIndexBlock[] connectionIndices;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  GlobalMapLeafBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            faces = Guerilla.ReadBlockArray<MapLeafFaceBlock>(binaryReader);
            connectionIndices = Guerilla.ReadBlockArray<MapLeafConnectionIndexBlock>(binaryReader);
        }
        public  GlobalMapLeafBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                nextAddress = Guerilla.WriteBlockArray<MapLeafFaceBlock>(binaryWriter, faces, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<MapLeafConnectionIndexBlock>(binaryWriter, connectionIndices, nextAddress);
                return nextAddress;
            }
        }
    };
}
