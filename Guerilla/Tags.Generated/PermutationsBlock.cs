// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class PermutationsBlock : PermutationsBlockBase
    {
        public  PermutationsBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  PermutationsBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 12, Alignment = 4)]
    public class PermutationsBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringID name;
        internal RigidBodyIndicesBlock[] rigidBodies;
        
        public override int SerializedSize{get { return 12; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  PermutationsBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            rigidBodies = Guerilla.ReadBlockArray<RigidBodyIndicesBlock>(binaryReader);
        }
        public  PermutationsBlockBase(): base()
        {
            
        }
        public void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            rigidBodies = Guerilla.ReadBlockArray<RigidBodyIndicesBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<RigidBodyIndicesBlock>(binaryWriter, rigidBodies, nextAddress);
                return nextAddress;
            }
        }
    };
}
