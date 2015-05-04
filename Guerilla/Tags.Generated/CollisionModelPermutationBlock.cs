// ReSharper disable All
using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    public partial class CollisionModelPermutationBlock : CollisionModelPermutationBlockBase
    {
        public  CollisionModelPermutationBlock(BinaryReader binaryReader): base(binaryReader)
        {
            
        }
        public  CollisionModelPermutationBlock(): base()
        {
            
        }
    };
    [LayoutAttribute(Size = 20, Alignment = 4)]
    public class CollisionModelPermutationBlockBase : GuerillaBlock
    {
        internal Moonfish.Tags.StringIdent name;
        internal CollisionModelBspBlock[] bsps;
        internal CollisionBspPhysicsBlock[] bspPhysics;
        
        public override int SerializedSize{get { return 20; }}
        
        
        public override int Alignment{get { return 4; }}
        
        public  CollisionModelPermutationBlockBase(BinaryReader binaryReader): base(binaryReader)
        {
            name = binaryReader.ReadStringID();
            bsps = Guerilla.ReadBlockArray<CollisionModelBspBlock>(binaryReader);
            bspPhysics = Guerilla.ReadBlockArray<CollisionBspPhysicsBlock>(binaryReader);
        }
        public  CollisionModelPermutationBlockBase(): base()
        {
            
        }
        public override void Read(BinaryReader binaryReader)
        {
            name = binaryReader.ReadStringID();
            bsps = Guerilla.ReadBlockArray<CollisionModelBspBlock>(binaryReader);
            bspPhysics = Guerilla.ReadBlockArray<CollisionBspPhysicsBlock>(binaryReader);
        }
        public override int Write(System.IO.BinaryWriter binaryWriter, Int32 nextAddress)
        {
            using(binaryWriter.BaseStream.Pin())
            {
                binaryWriter.Write(name);
                nextAddress = Guerilla.WriteBlockArray<CollisionModelBspBlock>(binaryWriter, bsps, nextAddress);
                nextAddress = Guerilla.WriteBlockArray<CollisionBspPhysicsBlock>(binaryWriter, bspPhysics, nextAddress);
                return nextAddress;
            }
        }
    };
}
