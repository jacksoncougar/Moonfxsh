// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderModelNodeMapBlockOLD : RenderModelNodeMapBlockOLDBase
    {
        public  RenderModelNodeMapBlockOLD(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 1, Alignment = 4)]
    public class RenderModelNodeMapBlockOLDBase  : IGuerilla
    {
        internal byte nodeIndex;
        internal  RenderModelNodeMapBlockOLDBase(BinaryReader binaryReader)
        {
            nodeIndex = binaryReader.ReadByte();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(nodeIndex);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
