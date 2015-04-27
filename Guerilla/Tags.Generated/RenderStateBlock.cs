// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RenderStateBlock : RenderStateBlockBase
    {
        public  RenderStateBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RenderStateBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 5, Alignment = 4)]
    public class RenderStateBlockBase : GuerillaBlock
    {
        internal byte stateIndex;
        internal int stateValue;
        
        public override int SerializedSize{get { return 5; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RenderStateBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            stateIndex = binaryReader.ReadByte();
            stateValue = binaryReader.ReadInt32();
        }
        public  RenderStateBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(stateIndex);
                binaryWriter.Write(stateValue);
                return nextAddress;
            }
        }
    };
}
