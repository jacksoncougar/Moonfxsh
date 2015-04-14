// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public  partial class RenderStateBlock : RenderStateBlockBase
    {
        public  RenderStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
    };
    [LayoutAttribute(Size = 5, Alignment = 4)]
    public class RenderStateBlockBase  : IGuerilla
    {
        internal byte stateIndex;
        internal int stateValue;
        internal  RenderStateBlockBase(BinaryReader binaryReader)
        {
            stateIndex = binaryReader.ReadByte();
            stateValue = binaryReader.ReadInt32();
        }
        public int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stateIndex);
                binaryWriter.Write(stateValue);
                return nextAddress = (int)binaryWriter.BaseStream.Position;
            }
        }
    };
}
