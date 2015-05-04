// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class RigidBodyIndicesBlock : RigidBodyIndicesBlockBase
    {
        public  RigidBodyIndicesBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  RigidBodyIndicesBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 2, Alignment = 4)]
    public class RigidBodyIndicesBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.ShortBlockIndex1 rigidBody;
        
        public override int SerializedSize{get { return 2; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  RigidBodyIndicesBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            rigidBody = binaryReader.ReadShortBlockIndex1();
        }
        public  RigidBodyIndicesBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            rigidBody = binaryReader.ReadShortBlockIndex1();
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(rigidBody);
                return nextAddress;
            }
        }
    };
}
