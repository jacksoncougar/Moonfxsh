// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class FlockSinkBlock : FlockSinkBlockBase
    {
        public  FlockSinkBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  FlockSinkBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 16, Alignment = 4)]
    public class FlockSinkBlockBase : GuerillaBlock
    {
        internal OpenTK.Vector3 position;
        internal float radius;
        
        public override int SerializedSize{get { return 16; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  FlockSinkBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            position = binaryReader.ReadVector3();
            radius = binaryReader.ReadSingle();
        }
        public  FlockSinkBlockBase(): base()
        {
            
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(position);
                binaryWriter.Write(radius);
                return nextAddress;
            }
        }
    };
}
